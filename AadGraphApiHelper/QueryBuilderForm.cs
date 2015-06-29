using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AadGraphApiHelper
{
    public partial class QueryBuilderForm : Form
    {
        private const string LogicalOperatorColumnName = "And/Or";

        private const string PropertyColumnName = "Property";

        private const string ComparisonOperatorColumnName = "Operator";

        private const string ValueColumnName = "Value";

        private readonly int allowedWidth;

        private DataGridViewComboBoxColumn propertyColumn;

        public QueryBuilderForm()
        {
            this.InitializeComponent();
            this.allowedWidth = this.Width;
        }

        internal GraphApiUrlBuilder UrlBuilder { get; set; }

        private void QueryBuilderForm_Load(object sender, EventArgs args)
        {
            this.resourceComboBox.Items.AddRange(GraphApiEntityType.Entities.Select(e => e.Name).ToArray());
            DataGridViewComboBoxColumn andOrColumn = new DataGridViewComboBoxColumn();
            andOrColumn.Name = LogicalOperatorColumnName;
            andOrColumn.FlatStyle = FlatStyle.Flat;
            andOrColumn.Items.AddRange(GraphApiUrlFilterComponent.AllowedLogicalOperators);
            this.queryGridView.Columns.Add(andOrColumn);

            this.propertyColumn = new DataGridViewComboBoxColumn();
            this.propertyColumn.Name = PropertyColumnName;
            this.propertyColumn.FlatStyle = FlatStyle.Flat;
            this.propertyColumn.Width = (this.allowedWidth - andOrColumn.Width) / 4;

            this.queryGridView.Columns.Add(this.propertyColumn);

            DataGridViewComboBoxColumn operatorColumn = new DataGridViewComboBoxColumn();
            operatorColumn.Name = ComparisonOperatorColumnName;
            operatorColumn.FlatStyle = FlatStyle.Flat;
            operatorColumn.Width = (this.allowedWidth - andOrColumn.Width - this.propertyColumn.Width) / 4;
            this.queryGridView.Columns.Add(operatorColumn);

            DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.Name = ValueColumnName;
            valueColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.queryGridView.Columns.Add(valueColumn);

            this.queryGridView.EnableHeadersVisualStyles = false;
            this.queryGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            this.queryGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xf7, 0xf7, 0xf7);

            DataGridViewCell firstAndOrColumn = this.queryGridView.Rows[0].Cells[LogicalOperatorColumnName];
            firstAndOrColumn.ReadOnly = true;
            firstAndOrColumn.Style = new DataGridViewCellStyle { BackColor = Color.LightGray };
            this.queryGridView.CurrentCell = this.queryGridView.Rows[0].Cells[PropertyColumnName];
            this.queryGridView.RowValidating += this.queryGridView_RowValidating;

            this.queryGridView.CellValueChanged += this.queryGridView_CellValueChanged;

            this.PopulateDataGridViewFromUrlBuilder();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void queryGridView_CellValueChanged(object sender, DataGridViewCellEventArgs args)
        {
            if (args.ColumnIndex == this.queryGridView.Columns[PropertyColumnName].Index)
            {
                DataGridViewRow row = this.queryGridView.Rows[args.RowIndex];
                this.SetComparisonOperators(row);
            }
        }

        private void queryGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs args)
        {
            DataGridViewRow row = this.queryGridView.Rows[args.RowIndex];
            string andOr = row.Cells[LogicalOperatorColumnName].Value as string;
            string op = row.Cells[ComparisonOperatorColumnName].Value as string;
            string property = row.Cells[PropertyColumnName].Value as string;
            string value = row.Cells[ValueColumnName].Value as string;

            if (args.RowIndex != this.queryGridView.Rows.Count - 1)
            {
                if (args.RowIndex != 0 && String.IsNullOrWhiteSpace(andOr))
                {
                    row.Cells[LogicalOperatorColumnName].Style = new DataGridViewCellStyle { BackColor = Color.LightCoral };
                    args.Cancel = true;
                }

                if (String.IsNullOrWhiteSpace(property))
                {
                    row.Cells[PropertyColumnName].Style = new DataGridViewCellStyle { BackColor = Color.LightCoral };
                    args.Cancel = true;
                }

                if (String.IsNullOrWhiteSpace(op))
                {
                    row.Cells[ComparisonOperatorColumnName].Style = new DataGridViewCellStyle { BackColor = Color.LightCoral };
                    args.Cancel = true;
                }

                if (String.IsNullOrWhiteSpace(value))
                {
                    row.Cells[ValueColumnName].Style = new DataGridViewCellStyle { BackColor = Color.LightCoral };
                    args.Cancel = true;
                }
            }

            if (args.Cancel == false)
            {
                row.Cells[LogicalOperatorColumnName].Style = new DataGridViewCellStyle { BackColor = Color.White };
                row.Cells[PropertyColumnName].Style = new DataGridViewCellStyle { BackColor = Color.White };
                row.Cells[ComparisonOperatorColumnName].Style = new DataGridViewCellStyle { BackColor = Color.White };
                row.Cells[ValueColumnName].Style = new DataGridViewCellStyle { BackColor = Color.White };
            }
        }

        private void createRequestButton_Click(object sender, EventArgs e)
        {
            this.UpdateUrlBuilder();
            this.Close();
        }

        private void createAndExecuteButton_Click(object sender, EventArgs e)
        {
            this.UpdateUrlBuilder();
            this.Close();
        }

        private void UpdateUrlBuilder()
        {
            this.UrlBuilder.ResourceFirst = this.resourceComboBox.Text;
            this.UrlBuilder.ResourceSecond = null;
            this.UrlBuilder.ResourceId = null;

            this.UrlBuilder.FilterComponents.Clear();
            for (int index = 0; index < this.queryGridView.Rows.Count; index++)
            {
                DataGridViewRow row = this.queryGridView.Rows[index];
                if (row.IsNewRow)
                {
                    continue;
                }

                string logicalOperator = row.Cells[LogicalOperatorColumnName].Value as string;
                string comparisonOperator = row.Cells[ComparisonOperatorColumnName].Value as string;
                string propertyName = row.Cells[PropertyColumnName].Value as string;
                string value = row.Cells[ValueColumnName].Value as string;

                if ((index != 0 && String.IsNullOrWhiteSpace(logicalOperator) ||
                    String.IsNullOrWhiteSpace(comparisonOperator) ||
                    String.IsNullOrWhiteSpace(propertyName) ||
                    String.IsNullOrWhiteSpace(value)))
                {
                    return;
                }

                GraphApiEntityType entity = GetEntityType(this.resourceComboBox.Text);
                if (entity == null)
                {
                    return;
                }

                GraphApiProperty property = entity.Properties.SingleOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
                if (property == null)
                {
                    return;
                }

                GraphApiUrlFilterComponent filterComponent = new GraphApiUrlFilterComponent
                {
                    LogicalOperator = index > 0 ? logicalOperator : null,
                    Property = property,
                    ComparisonOperator = comparisonOperator,
                    Value = value
                };

                this.UrlBuilder.FilterComponents.Add(filterComponent);
            }
        }

        private void PopulateDataGridViewFromUrlBuilder()
        {
            if (this.resourceComboBox.Items.Contains(this.UrlBuilder.ResourceFirst))
            {
                this.resourceComboBox.Text = this.UrlBuilder.ResourceFirst;
            }

            this.AssignProperties();

            foreach (GraphApiUrlFilterComponent filterComponent in this.UrlBuilder.FilterComponents)
            {
                int rowIndex = this.queryGridView.Rows.Add();
                DataGridViewRow row = this.queryGridView.Rows[rowIndex];
                row.Cells[LogicalOperatorColumnName].Value = filterComponent.LogicalOperator;
                row.Cells[PropertyColumnName].Value = filterComponent.Property.Name;
                this.SetComparisonOperators(row);
                row.Cells[ComparisonOperatorColumnName].Value = filterComponent.ComparisonOperator;
                row.Cells[ValueColumnName].Value = filterComponent.Value;
            }
        }

        private void SetComparisonOperators(DataGridViewRow row)
        {
            string propertyName = (string)row.Cells[PropertyColumnName].Value;

            GraphApiEntityType entity = GetEntityType(this.resourceComboBox.Text);
            GraphApiProperty property = entity.Properties.Single(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
            DataGridViewComboBoxCell operatorCell = (DataGridViewComboBoxCell)row.Cells[ComparisonOperatorColumnName];
            string operatorValue = operatorCell.Value as string;
            operatorCell.Items.Clear();
            string[] operators = property.GetAllowedComparisonOperators();
            operatorCell.Items.AddRange(operators);

            if (!operators.Contains(operatorValue))
            {
                operatorCell.Value = null;
            }
        }

        private void resourceComboBox_SelectedIndexChanged(object sender, EventArgs args)
        {
            this.AssignProperties();
        }

        private void AssignProperties()
        {
            this.propertyColumn.Items.Clear();
            GraphApiEntityType entity = GetEntityType(this.resourceComboBox.Text);

            if (entity == null)
            {
                return;
            }

            this.propertyColumn.Items.AddRange(entity.Properties.Where(p => p.Filterable).Select(p => p.Name).ToArray());
        }

        private static GraphApiEntityType GetEntityType(string entityName)
        {
            if (String.IsNullOrWhiteSpace(entityName))
            {
                return null;
            }

            return GraphApiEntityType.Entities.SingleOrDefault(e => e.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
