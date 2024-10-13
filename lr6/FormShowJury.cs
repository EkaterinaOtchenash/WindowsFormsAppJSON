using lr6.DBCon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lr6.DBCon;

namespace lr6
{
    public partial class FormShowJury : Form
    {
        public FormShowJury()
        {
            InitializeComponent();
        }

        private void FormShowJury_Load(object sender, EventArgs e)
        {
            int number = 1;
            foreach (int i in MainForm.JuriList)
            {
                User user = DBConst.model.User.Find(i);
                UserControJuri usercontr = new UserControJuri(); usercontr.Fill(user, number);
                flowLayoutPanel1.Controls.Add(usercontr);
                number++;
            }
        }
    }
}
