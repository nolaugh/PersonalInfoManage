using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalInfoManage.SqlLiteClass
{
    public class DataClass
    {
        public static  SQLiteConnection m_dbConnection;

        //创建数据库
        public void createNewDatabase()
        {
            string databasePath = "MyDatabase.db";
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }
        }

        public static SQLiteConnection connectToDatabase()
        {
            if (m_dbConnection == null || m_dbConnection.State != ConnectionState.Open)
            {
                m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;");
                m_dbConnection.Open();
            }

            return m_dbConnection;

        }

        public SQLiteDataReader selectData(string sqlQuery)
        {
            connectToDatabase();
            SQLiteCommand command = m_dbConnection.CreateCommand();
            command.CommandText = sqlQuery;
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;  
        }

        public void getsqlcom(string SQLstr)
        {
            connectToDatabase();
            SQLiteCommand Sqlcon = new SQLiteCommand(SQLstr, m_dbConnection);
            Sqlcon.ExecuteNonQuery();
            Sqlcon.Dispose();
        }

        public DataSet getDataSet(string SQLstr, string tableName)
        {
            SQLiteDataAdapter SQLda = new SQLiteDataAdapter(SQLstr, m_dbConnection);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet, tableName);
            return My_DataSet;
        }

        public void UpdateImage(byte[] imageData)
        {
            try
            {
                string sqlQuery = "UPDATE tb_SelfInfo SET Picture = @Photo WHERE ID = 1";
                using (SQLiteCommand command = new SQLiteCommand(sqlQuery, m_dbConnection))
                {
                    command.Parameters.Add("@Photo", DbType.Binary).Value = imageData;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("更新图片出错：" + ex.Message);
            }
        }

        public Image GetImage()
        {
            try
            {
                string sqlQuery = "SELECT Picture FROM tb_SelfInfo WHERE ID = 1";
                using (SQLiteCommand command = new SQLiteCommand(sqlQuery, m_dbConnection))
                {
                    byte[] imageData = (byte[])command.ExecuteScalar();

                    if (imageData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            ms.Position = 0;
                            return Image.FromStream(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取图片出错：" + ex.Message);
            }

            return null;
        }
    }
}
