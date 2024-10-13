using lr6.DBCon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using lr6.DBCon;

namespace lr6
{
    public partial class MainForm : Form
    {
        public static List<int> JuriList;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonShowJuri_Click(object sender, EventArgs e)
        {
            JuriList = new List<int>();
            JuriList = JsonSerializer.Deserialize<List<int>>
            (activityDataGridView.CurrentRow.Cells[6].Value.ToString());
            FormAddActivity formShowJuri = new FormAddActivity();
            formShowJuri.ShowDialog();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddActivity activity = new FormAddActivity();
            activity.ShowDialog();
            activityBindingSource.DataSource = DBConst.model.Activity.ToList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            activityBindingSource.DataSource = DBConst.model.Activity.ToList();
        }
    }
}
