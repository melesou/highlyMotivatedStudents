using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace highlyMotivatedStudents
{
    public partial class AddForm : Form
    {
        int studentId = 0;
        public AddForm(int newStudentId)
        {
            InitializeComponent();
            studentId = newStudentId;
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
        private void addStudentTable()
        {
            string sqlInsert = @"Insert into Students (student_id, full_name, year_of_study, special_education, program_id) values (@v1, @v2, @v3, @v4, @v5)";
            SqlConnection conn = new SqlConnection(GetSettings());
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sqlInsert;
            command.Parameters.AddWithValue("@v1", studentId);
            command.Parameters.AddWithValue("@v2", textBox1.Text);
            command.Parameters.AddWithValue("@v3", comboBox1.Text);
            command.Parameters.AddWithValue("@v4", comboBox2.Text);
            command.Parameters.AddWithValue("@v5", comboBox3.SelectedIndex + 1);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public int checkIndex(string[] items, string value)
        {
            for (int i = 0; i < items.Length; i++)
                if (items[i] == value)
                    return i + 1;
            return 0;
        }
        private void addTeachersTable()
        {
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
        private void addOrientationTable()
        {
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
        private void addAchievements()
        {
            string sqlInsert = @"Insert into achievements (achievement_id, regional_level, russian_level, international_level) values (@v1, @v2, @v3, @v4)";
            SqlConnection conn = new SqlConnection(GetSettings());
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sqlInsert;
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
            addStudentTable();
            addOrientationTable();
            addTeachersTable();
            addAchievements();
            this.Close();
        }
        private void AddForm_Load(object sender, EventArgs e)
        {
            string[] learningProgram = GetValue("learning_program", 1);
            comboBox3.Items.AddRange(learningProgram);

            string[] orientations = GetValue("orientation_of_giftedness", 1);
            nameOfOrientation.Items.AddRange(orientations);

            string[] teachers = teachersFullNames();
            teachersNames.Items.AddRange(teachers);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
