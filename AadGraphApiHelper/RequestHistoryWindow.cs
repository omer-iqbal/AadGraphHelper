using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void RequestHistoryWindow_Load(object sender, EventArgs e)
        {
            mBindingSource.DataSource = typeof(RequestHistoryObject);

            foreach (var item in RequestHistoryManager.Instance.RequestHistoryObjects)
            {
                mBindingSource.Add(item);
            }

            //dataGridView1.DataSource = mBindingSource;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.RowSelected = e.RowIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
