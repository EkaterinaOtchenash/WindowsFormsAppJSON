using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using WindowsFormsAppJSON.DBCon;
namespace WindowsFormsAppJSON
{
	public partial class FormAddActivity: Form
	{
		public FormAddActivity()
		{
			InitializeComponent();
		}
		//список для жюри
		private List<int> Id_Juri = new List<int>();
		private void FormAddActivity_Load(object sender, EventArgs e)
		{
			eventBindingSource.DataSource = DBConst.model.Event.ToList();
			usersBindingSource.DataSource = DBConst.model. User.Where(x => x. RoleID == 1).ToList(); 
			userBindingSource2.DataSource = DBConst.model. User.Where(x => x.RoleID == 2).ToList();
		}
		private void buttonAddActivity_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(titleTextBox.Text))
			{
				MessageBox.Show("Заполните поле Название!");
				return;
			}
			try 
			{
				Convert.ToInt32(dayTextBox.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("В поле день должно стоять целочисленное значение!");
				return;
			}
			if (Id_Juri.Count <= 0)
			{
				MessageBox.Show("Добавте хотябы одного члена жюри!");
				return; 
			}
			Activity activity = new Activity();
			activity. Title = titleTextBox.Text;
			activity.EventPlanID = (int)eventPlanIDComboBox.SelectedValue; activity. Day = Convert.ToInt32(dayTextBox.Text);
			activity. StartedAt = dateTimePicker1.Value.TimeOfDay;
			activity. ModeratorID = (int)ModeratorComboBox.SelectedValue;
			activity. GroupsJury = JsonSerializer.Serialize(Id_Juri);
			DBConst.model.Activity.Add(activity);
			try
			{
				DBConst.model.SaveChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			Close();
		}
		private void buttonAddJuri_Click(object sender, EventArgs e)
		{
			int id = (int)juriComboBox.SelectedValue;
			if (!Id_Juri.Contains(id))
			{
				Id_Juri.Add(id);
				MessageBox.Show($"Пользователь с ID - {juriComboBox.SelectedValue} до6авлен!");
				return;
			}
			MessageBox.Show("Нельзя добавлять одного и того же Жюри");
		}
		private void buttonBack_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}