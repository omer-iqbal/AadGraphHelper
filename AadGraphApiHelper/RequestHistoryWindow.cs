using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AadGraphApiHelper
{
    public partial class RequestHistoryWindow : Form
    {
        BindingSource mBindingSource = new BindingSource();

        public int RowSelected { get; set; }

        public RequestHistoryWindow()
        {
            InitializeComponent();
        }

        // A copy of RequestHistoryObjects to allow modification and cancellation
        internal List<RequestHistoryObject> ViewRequestHistoryObjects { get; private set; }

        private void RequestHistoryWindow_Load(object sender, EventArgs e)
        {
            mBindingSource.DataSource = typeof(RequestHistoryObject);

            ViewRequestHistoryObjects = RequestHistoryManager.Instance.RequestHistoryObjects.ToList();
            mBindingSource.DataSource = ViewRequestHistoryObjects;

            dataGridView1.DataSource = mBindingSource;
            dataGridView1.AutoGenerateColumns = true;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dataGridView1.Columns[0].MinimumWidth = 100;
            dataGridView1.Columns[0].FillWeight = 1;

            dataGridView1.Columns[1].MinimumWidth = 200;
            dataGridView1.Columns[1].FillWeight = 8;

            dataGridView1.Columns[2].MinimumWidth = 100;
            dataGridView1.Columns[2].FillWeight = 4;
        }

        //private void FillDataFromSource()
        //{
        //    foreach (var item in RequestHistoryManager.Instance.RequestHistoryObjects)
        //    {
        //        mBindingSource.Add(item);
        //    }
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.RowSelected = e.RowIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RequestHistoryWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!ViewRequestHistoryObjects.Equals(RequestHistoryManager.Instance.RequestHistoryObjects))
            if (!AreListEqual(ViewRequestHistoryObjects, RequestHistoryManager.Instance.RequestHistoryObjects))
            {
                DialogResult dr = MessageBox.Show(
                    "You made some changes to history, do you want to save them?", 
                    "Confirm",
                    MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                     case DialogResult.Yes:
                        RequestHistoryManager.Instance.RequestHistoryObjects = ViewRequestHistoryObjects.ToList();
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        internal bool AreListEqual<T>(List<T> list1, List<T> list2)
        {
            return list1.Count == list2.Count // assumes unique values in each list
                && new HashSet<T>(list1).SetEquals(list2);

            //return Ids.Count == XmlIds.Count &&
            //    Ids.All(XmlIds.Contains) &&
            //    XmlIds.All(Ids.Contains);
        }
    }
}
