using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections; // Sử dụng Lớp ArrayList để lưu kết quả
using System.Data.SqlClient;// Sử dụng các lớp tương tác CSDL

namespace CHTAN.Models
{
    public class DataModel
    {
        public static string connectionString = "Server=DESKTOP-L0CSEBK;Database=cnpmnc;Trusted_Connection=True";

        public ArrayList get(String sql)
        {
            ArrayList datalist = new ArrayList();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    ArrayList row = new ArrayList();
                    for (int i = 0; i < reader.FieldCount; i++) 
                    {
                    
                    row.Add(reader.GetValue(i).ToString());
                    }
                    datalist.Add(row);
                }

            }
            connection.Close();
            return datalist;

        }
    }
}