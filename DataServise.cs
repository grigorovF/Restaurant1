using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Restaurant
{
    public class DataServise
    {
        public event Action DataUpdated;

        private SqlConnection conn = new SqlConnection("Data Source=Grigorov\\SQLEXPRESS;Initial Catalog=restaurantManagment;Integrated Security=True;Encrypt=False; MultipleActiveResultSets=True");

        public DataTable GetUpdatedDataTable(string tableName)
        {
            var dataTable = new DataTable();

            try
            {
                conn.Open();
                string query = @"SELECT Product, Quantity, Price, (Quantity * Price) AS Total 
                         FROM Tables 
                         WHERE TableName = @TableName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TableName", tableName);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable); // Fill DataTable with the query results
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return dataTable;
        }
        public List<string> GetUserTables(string userId)
        {
            var tableNames = new List<string>();

            try
            {
                conn.Open();
                string query = "SELECT DISTINCT TableName FROM Tables WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader["TableName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return tableNames;
        }
        public void RefreshData(string userId)
        {
            try
            {
                conn.Open();

                var userTables = new Dictionary<string, DataTable>();
                string query = "SELECT * FROM Tables WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader["TableName"].ToString();
                            if (!userTables.ContainsKey(tableName))
                            {
                                DataTable table = new DataTable();
                                table.Columns.Add("Product", typeof(string));
                                table.Columns.Add("Quantity", typeof(int));
                                table.Columns.Add("Price", typeof(double));
                                table.Columns.Add("Total", typeof(double));
                                userTables[tableName] = table;
                            }

                            userTables[tableName].Rows.Add(
                                reader["Product"].ToString(),
                                Convert.ToInt32(reader["Quantity"]),
                                Convert.ToDouble(reader["Price"]),
                                Convert.ToDouble(reader["Total"])
                            );
                        }
                    }
                }

                DataUpdated?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
