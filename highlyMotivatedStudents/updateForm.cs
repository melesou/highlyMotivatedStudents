using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
namespace highlyMotivatedStudents
{
    public partial class updateForm : Form
    {
        int studentId = 0;
        string studentFIO = "";
        int ageOfStudy = 0;
        string specialEducation = "";
        string[] programNames = new string[3];
        int programId = 0;
        List<string> giftedness = new List<string>();
        List<string> teachersGet = new List<string>();
        List<string> regional = new List<string>();
        List<string> russian = new List<string>();
        List<string> international = new List<string>();
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
        public string[] GetValue(string tableName, int cells)
        {
            DataTable dataTable = FillDataGridView($"SELECT * FROM [{tableName}]");
            DataColumn dc = dataTable.Columns[cells];
            string s = string.Join(",", dataTable.Rows.OfType<DataRow>().Select(r => r[dc]));
            string[] values = s.Split(',');
            return values;
        }
        public string[] teachersFullNames()
        {
            string[] names = GetValue("teachers", 1);
            string[] surname = GetValue("teachers", 2);
            string[] patronymic = GetValue("teachers", 3);
            string[] fullNames = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
                fullNames[i] += $"{surname[i]} {names[i]} {patronymic[i]}";
            return fullNames;
        }
        public int checkIndex(string[] items, string value)
        {
            for (int i = 0; i < items.Length; i++)
                if (items[i] == value)
                    return i + 1;
            return 0;
        }
        public updateForm(string[] allValues)
        {
            InitializeComponent();

            studentId = Convert.ToInt32(allValues[0]);
            studentFIO = allValues[1];
            ageOfStudy = Convert.ToInt32(allValues[2]);
            specialEducation = allValues[3];
            programNames = GetValue("learning_program", 1);
            programId = checkIndex(programNames, allValues[4]);

            giftedness.AddRange(allValues[5].Split(';'));
            teachersGet.AddRange(allValues[9].Split(';'));

            regional.AddRange(allValues[6].Split(';'));
            russian.AddRange(allValues[7].Split(';'));
            international.AddRange(allValues[8].Split(';'));
        }

        public void updateStudentsTable()
        {
            string sqlUpdate = @"update Students set full_name = @v2, year_of_study = @v3, special_education = @v4, program_id = @v5 where student_id=@v1";
            SqlConnection conn = new SqlConnection(GetSettings());
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sqlUpdate;
            command.Parameters.AddWithValue("@v1", studentId);
            command.Parameters.AddWithValue("@v2", textBox1.Text);
            command.Parameters.AddWithValue("@v3", comboBox1.Text);
            command.Parameters.AddWithValue("@v4", comboBox2.Text);
            command.Parameters.AddWithValue("@v5", comboBox3.SelectedIndex + 1);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void updateOrientationTable()
        {
            for (int i = 0; i < giftedness.Count; i++)
            {
                string sqlDelete = @"delete from orientations_students where student_id = @v1";
                SqlConnection conn = new SqlConnection(GetSettings());
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sqlDelete;
                command.Parameters.AddWithValue("@v1", studentId);
                command.ExecuteNonQuery();
                conn.Close();
            }
            string[] orientations = GetValue("orientation_of_giftedness", 1);
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string sqlInsert = @"Insert into orientations_students (student_id, giftedness_id) values (@v1, @v2)";
                SqlConnection conn = new SqlConnection(GetSettings());
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sqlInsert;
                command.Parameters.AddWithValue("@v1", studentId);
                command.Parameters.AddWithValue("@v2", checkIndex(orientations, dataGridView1.Rows[i].Cells[0].Value.ToString()));
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void updateTeachersTable()
        {
            for (int i = 0; i < teachersGet.Count; i++)
            {
                string sqlDelete = @"delete from teachers_students where student_id = @v1";
                SqlConnection conn = new SqlConnection(GetSettings());
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sqlDelete;
                command.Parameters.AddWithValue("@v1", studentId);
                command.ExecuteNonQuery();
                conn.Close();
            }
            string[] teachers = teachersFullNames();
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                string sqlInsert = @"Insert into teachers_students (student_id, teacher_id) values (@v1, @v2)";
                SqlConnection conn = new SqlConnection(GetSettings());
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sqlInsert;
                command.Parameters.AddWithValue("@v1", studentId);
                command.Parameters.AddWithValue("@v2", checkIndex(teachers, dataGridView2.Rows[i].Cells[0].Value.ToString()));
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void updateAchievementsTable()
        {
            string sqlUpdate = @"update achievements set regional_level = @v2, russian_level = @v3, international_level = @v4 where achievement_id=@v1";
            SqlConnection conn = new SqlConnection(GetSettings());
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sqlUpdate;
            command.Parameters.AddWithValue("@v1", studentId);
            command.Parameters.AddWithValue("@v2", achievementCombine(dataGridView3));
            command.Parameters.AddWithValue("@v3", achievementCombine(dataGridView4));
            command.Parameters.AddWithValue("@v4", achievementCombine(dataGridView5));
            command.ExecuteNonQuery();
            conn.Close();
        }
        public string achievementCombine(DataGridView dataGridView)
        {
            string achievement = "";
            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                achievement += dataGridView.Rows[i].Cells[0].Value.ToString();
                achievement += i + 1 == dataGridView.RowCount - 1 ? "" : ";";
            }
            return achievement;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            updateStudentsTable();
            updateOrientationTable();
            updateTeachersTable();
            updateAchievementsTable();
            this.Close();
        }

        private void updateForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = studentFIO;
            comboBox1.Text = ageOfStudy.ToString();
            comboBox2.Text = specialEducation;


            string[] learningProgram = GetValue("learning_program", 1);
            comboBox3.Items.AddRange(learningProgram);
            comboBox3.SelectedIndex = programId-1;

            dataGridView1.RowCount = giftedness.Count + 1;
            string[] orientations = GetValue("orientation_of_giftedness", 1);
            nameOfOrientation.Items.AddRange(orientations);
            for (int i = 0; i < giftedness.Count; i++)
                dataGridView1.Rows[i].Cells[0].Value = giftedness[i];

            dataGridView2.RowCount = teachersGet.Count + 1;
            string[] teachers = teachersFullNames();
            teachersNames.Items.AddRange(teachers);
            for (int i = 0; i < teachersGet.Count; i++)
                dataGridView2.Rows[i].Cells[0].Value = teachersGet[i];

            dataGridView3.RowCount = regional.Count + 1;
            for (int i = 0; i < regional.Count; i++)
                dataGridView3.Rows[i].Cells[0].Value = regional[i];

            dataGridView4.RowCount = russian.Count + 1;
            for (int i = 0; i < russian.Count; i++)
                dataGridView4.Rows[i].Cells[0].Value = russian[i];

            dataGridView5.RowCount = international.Count + 1;
            for (int i = 0; i < international.Count; i++)
                dataGridView5.Rows[i].Cells[0].Value = international[i];
        }
    }
}
