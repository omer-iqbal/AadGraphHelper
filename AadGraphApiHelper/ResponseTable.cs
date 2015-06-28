using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace AadGraphApiHelper
{
    internal class ResponseTable
    {
        private const string ODataMetadataKey = @"odata.metadata";

        private const string ODataErrorKey = @"odata.error";

        private const string ODataMetadataElementKey = @"@Element";

        private const string ODataTypeKey = @"odata.type";

        private readonly DataGridView dataGridView;

        private IDictionary<string, object> deserializedObject;

        private string jsonText;

        public ResponseTable(DataGridView gridView)
        {
            this.dataGridView = gridView;
        }

        public string JsonText
        {
            get
            {
                return this.jsonText;
            }
        }

        public bool IsFormattable { get; private set; }

        public bool ShowNullValues { get; set; }

        public void SetJsonText(string text)
        {
            this.dataGridView.Hide();

            this.jsonText = text;

            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                this.deserializedObject = serializer.Deserialize<Dictionary<string, object>>(this.jsonText);
            }
            catch (Exception)
            {
                this.IsFormattable = false;
                return;
            }

            if (this.deserializedObject.ContainsKey(ODataErrorKey) || 
                !this.deserializedObject.ContainsKey(ODataMetadataKey))
            {
                this.IsFormattable = false;
                return;
            }

            this.IsFormattable = true;
        }

        public void Clear()
        {
            this.dataGridView.Hide();
            this.dataGridView.Rows.Clear();
            this.dataGridView.Columns.Clear();
        }

        public void CreateResponseTable()
        {
            this.dataGridView.SuspendLayout();
            this.Clear();

            if (this.deserializedObject == null || this.IsFormattable == false)
            {
                return;
            }

            string odataMetadata = this.deserializedObject[ODataMetadataKey] as string;

            if (String.IsNullOrWhiteSpace(odataMetadata))
            {
                return;
            }

            if (odataMetadata.Contains(ODataMetadataElementKey))
            {
                this.FormatAsObject();
            }
            else
            {
                this.FormatAsCollection();
            }

            this.dataGridView.ResumeLayout();
            this.dataGridView.Show();
        }

        public string GetCellValueOfSelectedCell()
        {
            if (this.dataGridView.SelectedRows.Count != 1 || this.dataGridView.CurrentCell == null)
            {
                return null;
            }

            return this.dataGridView.CurrentCell.Value as string;
        }

        public string GetCellValueFromSelectedRow(string columnName)
        {
            if (this.dataGridView.SelectedRows.Count != 1)
            {
                return null;
            }

            try
            {
                return this.dataGridView.SelectedRows[0].Cells[columnName].Value as string;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private void FormatAsObject()
        {
            this.dataGridView.ColumnCount = 2;
            this.dataGridView.Columns[0].Name = "Property";
            this.dataGridView.Columns[1].Name = "Value";
            this.dataGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (KeyValuePair<string, object> property in this.deserializedObject)
            {
                if (property.Value == null)
                {
                    if (this.ShowNullValues)
                    {
                        this.dataGridView.Rows.Add(property.Key, StringResources.NullValue);
                    }
                }
                else if (property.Value is ValueType || property.Value is String)
                {
                    this.dataGridView.Rows.Add(property.Key, property.Value);
                }
                else if (property.Value is IEnumerable)
                {
                    ICollection collection;

                    if (((IEnumerable)property.Value).TryConvertToTypedCollection(out collection) && collection.Count > 0 &&
                        (collection is IEnumerable<string> || collection is IEnumerable<ValueType>))
                    {
                        string value = String.Empty;
                        foreach (object o in collection)
                        {
                            if (!String.IsNullOrWhiteSpace(value))
                            {
                                value += Environment.NewLine;
                            }

                            value += o.ToString();
                        }

                        this.dataGridView.Rows.Add(property.Key, value);
                    }
                    else
                    {
                        string value = String.Empty;
                        bool itemAdded = false;
                        int itemCount = 0;

                        foreach (object obj in (IEnumerable)property.Value)
                        {
                            itemCount++;
                            if (obj is IDictionary)
                            {
                                if (itemAdded)
                                {
                                    value += Environment.NewLine;
                                }

                                value += @"{ ";
                                foreach (DictionaryEntry entry in (IDictionary)obj)
                                {
                                    if (entry.Value == null && this.ShowNullValues == false)
                                    {
                                        continue;
                                    }

                                    value += itemAdded ? @", " : String.Empty;
                                    value += String.Format(CultureInfo.InvariantCulture, 
                                        @"""{0}"": ""{1}""", 
                                        entry.Key, 
                                        entry.Value ?? StringResources.NullValue);
                                    itemAdded = true;
                                }

                                value += @" }";
                            }
                        }

                        value = itemCount == 0 ? StringResources.EmptyCollectionValue : value;
                        this.dataGridView.Rows.Add(property.Key, value);
                    }
                }
            }
        }

        private void FormatAsCollection()
        {
            ArrayList itemCollection = this.deserializedObject[@"value"] as ArrayList;
            if (itemCollection == null || itemCollection.Count == 0)
            {
                return;
            }

            IDictionary<string, int> columnNameByIndex = new Dictionary<string, int>();

            foreach (IDictionary<string, object> item in itemCollection)
            {
                foreach (KeyValuePair<string, object> property in item)
                {
                    if (IncludeProperty(property))
                    {
                        if (!columnNameByIndex.ContainsKey(property.Key))
                        {
                            columnNameByIndex.Add(property.Key, columnNameByIndex.Count);
                        }
                    }
                }
            }

            this.dataGridView.ColumnCount = columnNameByIndex.Count;
            foreach (KeyValuePair<string, int> columnPair in columnNameByIndex)
            {
                this.dataGridView.Columns[columnPair.Value].Name = columnPair.Key;
            }

            foreach (IDictionary<string, object> item in itemCollection)
            {
                object[] values = new object[columnNameByIndex.Count];
                foreach (KeyValuePair<string, object> property in item)
                {
                    if (IncludeProperty(property))
                    {
                        values[columnNameByIndex[property.Key]] = property.Value;
                    }
                }

                this.dataGridView.Rows.Add(values);
            }
        }

        private static bool IncludeProperty(KeyValuePair<string, object> property)
        {
            if (property.Key.Equals(ODataTypeKey, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (property.Value is ValueType || property.Value is String)
            {
                return true;
            }

            return false;
        }
    }
}
