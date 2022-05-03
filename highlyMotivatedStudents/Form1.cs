using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using highlyMotivatedStudents.biblies;
namespace highlyMotivatedStudents
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        string GetSettings()
        {
            string machineName = Environment.MachineName;
            string databaseName = "hightly_motivated_students";
            string connectionSettings = $"Data Source={machineName}\\SQLEXPRESS;Initial Catalog={databaseName};Integrated Security=True";
            return connectionSettings;
        }
        DataTable FillDataGridView(string sqlSelect)
        {
            SqlConnection connection = new SqlConnection(GetSettings());
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlSelect;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        private void MainMenuLoad(object sender, EventArgs e)
        {
            load();
        }

        private void AddRequest(object sender, EventArgs e)
        {
            int newStudentId = dataGridView.RowCount;
            AddForm addForm = new AddForm(newStudentId);
            addForm.Show();
        }

        private void ChangeRequest(object sender, EventArgs e)
        {
            string[] allValues = new string[10];
            for (int i = 0; i < dataGridView.ColumnCount; i++)
                allValues[i] = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[i].Value.ToString();
            updateForm updateForm = new updateForm(allValues);
            updateForm.Show();
        }

        private void DeleteRequest(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string[] tables = { "achievements", "orientations_students", "teachers_students", "students" };
                string[] allValues = new string[10];
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                    allValues[i] = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[i].Value.ToString();
                for (int i = 0; i < 1; i++)
                {
                    string sqlDelete = $@"delete from achievements where achievement_id = @v1";
                    SqlConnection conn = new SqlConnection(GetSettings());
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = sqlDelete;
                    command.Parameters.AddWithValue("@v1", allValues[0]);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                string[] giftedness = allValues[5].Split(';');

                for (int i = 0; i < giftedness.Length; i++)
                {
                    string sqlDelete = $@"delete from orientations_students where student_id = @v1";
                    SqlConnection conn = new SqlConnection(GetSettings());
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = sqlDelete;
                    command.Parameters.AddWithValue("@v1", allValues[0]);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                string[] teachersGet = allValues[9].Split(';');
                for (int i = 0; i < teachersGet.Length; i++)
                {
                    string sqlDelete = $@"delete from teachers_students where student_id = @v1";
                    SqlConnection conn = new SqlConnection(GetSettings());
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = sqlDelete;
                    command.Parameters.AddWithValue("@v1", allValues[0]);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                for (int i = 0; i < 1; i++)
                {
                    string sqlDelete = $@"delete from students where student_id = @v1";
                    SqlConnection conn = new SqlConnection(GetSettings());
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = sqlDelete;
                    command.Parameters.AddWithValue("@v1", allValues[0]);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        void LoadData(List<object> dataName, int cellsIndex)
        {
            for (int i = 0; i < dataName.Count; i++)
                dataGridView.Rows[i].Cells[cellsIndex].Value = dataName[i];
        }
        public void load()
        {
            DataLoad dataLoad = new DataLoad();
            List<object> studentId = dataLoad.GetValue("students", 0);
            List<object> studentFIO = dataLoad.GetValue("students", 1);
            List<object> yearOfStudy = dataLoad.GetValue("students", 2);
            List<object> specialEducation = dataLoad.GetValue("students", 3);

            List<object> programId = dataLoad.GetValue("students", 4);
            List<object> learningPrograms = dataLoad.GetValue("learning_program", 1);
            //string[] learningProgram = new string[studentId.Length];
            //for (int i = 0; i < studentId.Length; i++)
            //    learningProgram[i] = GetValueSolo("learning_program", "program_id", programId[i], 1);

            //string[] orientationOfGiftedness = GetValueMany("orientations_students", "student_id", "orientation_of_giftedness", "giftedness_id", studentId.Length);

            //string[] regionalAchivements = GetValue("achievements", 1);
            //string[] russianAchivements = GetValue("achievements", 2);
            //string[] internationalAchivements = GetValue("achievements", 3);
            //string[] teachers = GetValueMany("teachers_students", "student_id", "teachers", "teacher_id", studentId.Length, 1);

            dataGridView.RowCount = studentId.Count;
            //dataGridView.RowCount = studentId.Length + 1;

            LoadData(studentId, 0);
            LoadData(studentFIO, 1);
            LoadData(yearOfStudy, 2);
            LoadData(specialEducation, 3);
            LoadData(programId, 4);
            //LoadData(learningProgram, 4);
            //LoadData(orientationOfGiftedness, 5);
            //LoadData(regionalAchivements, 6);
            //LoadData(russianAchivements, 7);
            //LoadData(internationalAchivements, 8);
            //LoadData(teachers, 9);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
