namespace WindowsFormsAppJSON
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		public static List<int> JuriList;
		private void Form1_Load(object sender, EventArgs e)
		{
			activityBindingSource.DataSource = DBConst.model.Activity.ToList();
		}
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			FormAddActivity activity = new FormAddActivity(); 
			activity.ShowDialog();
			activityBindingSource.DataSource = DBConst.model.Activity.ToList();
		}
		private void buttonShowJuri_Click(object sender, EventArgs e)
		{
			Jurilist = new List<int>();
			JuriList = JsonSerializer.Deserialize<List<int>>
			(activityDataGridView.CurrentRow.Cells[6].Value.ToString());
			FormShowJuri formShowJuri = new FormShowJuri();
			formShowJuri.ShowDialog();
		}
	}
}