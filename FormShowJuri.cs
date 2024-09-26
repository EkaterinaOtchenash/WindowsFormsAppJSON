
using System;
using System.Windows.Forms;
using WindowsFormsAppJSON.DBCon;
namespace WindowsFormsAppJSON
{


	public partial class FormShowJuri : Form
	{
		public FormShowJuri()
		{
		InitializeComponent();
		}

		private void FormShowJuri_Load(object sender, EventArgs e)
		{
			int number = 1;
			foreach (int i in MainForm. Jurilist)
			{
				User user = DBConst.model. User.Find(i);
				UserControJuri usercontr = new UserControJuri(); usercontr.Fill(user, number);
				flowLayoutPanel1.Controls.Add(usercontr);
				number++;
			}
		}
	}
}