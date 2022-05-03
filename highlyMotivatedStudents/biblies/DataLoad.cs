using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace highlyMotivatedStudents.biblies
{
    internal class DataLoad
    {
        static public string GetSettings()
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
        static List<string> _tables = new List<string> { "sd", "sda" };
        public List<object> GetValue(string tableName, int cells)
        {
            DataTable dataTable = FillDataGridView($"SELECT * FROM [{tableName}]");
            DataColumn dc = dataTable.Columns[cells];
            List<object> table = dataTable.Rows.OfType<DataRow>().Select(r => r[dc]).ToList();
            return table;
        }
        //public string[] GetValue(string tableName, int cells)
        //{
        //    DataTable dataTable = FillDataGridView($"SELECT * FROM [{tableName}]");
        //    DataColumn dc = dataTable.Columns[cells];
        //    string s = string.Join(",", dataTable.Rows.OfType<DataRow>().Select(r => r[dc]));
        //    string[] values = s.Split(',');
        //    return values;
        //}

        public string[] GetValue(string tableName, string searchParametr, string searchValue, int cells)
        {
            DataTable dataTable = FillDataGridView($"SELECT * FROM [{tableName}] where {searchParametr} = {searchValue}");
            DataColumn dc = dataTable.Columns[cells];
            string s = string.Join(",", dataTable.Rows.OfType<DataRow>().Select(r => r[dc]));
            string[] values = s.Split(',');
            return values;
        }
        public string GetValueSolo(string tableName, string searchParametr, string searchValue, int cells)
        {
            DataTable dataTable = FillDataGridView($"SELECT * FROM [{tableName}] where {searchParametr} = {searchValue}");
            DataColumn dc = dataTable.Columns[cells];
            string s = string.Join(",", dataTable.Rows.OfType<DataRow>().Select(r => r[dc]));
            string[] values = s.Split(',');
            return values[0];
        }
        string[] GetValueMany(string manyToManyTable, string manyKey, string endTable, string endKey, int tableSize)
        {
            string[] table = new string[tableSize];
            for (int i = 0; i < tableSize; i++)
            {
                string[] tableList = GetValue(manyToManyTable, manyKey, (i + 1).ToString(), 1);
                string[] buffer = new string[tableList.Length];
                for (int j = 0; j < buffer.Length; j++)
                {
                    buffer[j] = GetValueSolo(endTable, endKey, tableList[j], 1);
                    buffer[j] += j + 1 == buffer.Length ? "" : ";";
                }
                for (int j = 0; j < buffer.Length; j++)
                    table[i] += buffer[j];
            }
            return table;
        }
        string[] GetValueMany(string manyToManyTable, string manyKey, string endTable, string endKey, int tableSize, int glr)
        {
            string[] table = new string[tableSize];
            for (int i = 0; i < tableSize; i++)
            {
                string[] tableList = GetValue(manyToManyTable, manyKey, (i + 1).ToString(), 1);
                string[] buffer = new string[tableList.Length];
                for (int j = 0; j < buffer.Length; j++)
                {
                    buffer[j] = GetValueSolo(endTable, endKey, tableList[j], 2) + " ";
                    buffer[j] += GetValueSolo(endTable, endKey, tableList[j], 1) + " ";
                    buffer[j] += GetValueSolo(endTable, endKey, tableList[j], 3);

                    buffer[j] += j + 1 == buffer.Length ? "" : ";";
                }
                for (int j = 0; j < buffer.Length; j++)
                    table[i] += buffer[j];
            }
            return table;
        }
    }
}
