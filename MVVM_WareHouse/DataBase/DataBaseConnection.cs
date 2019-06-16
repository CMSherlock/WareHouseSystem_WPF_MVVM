using System;
using System.Data.SqlServerCe;
using System.Windows;


namespace MVVM_WareHouse.DataBase
{

    public class SQLServerCompactConnection 
    {
        private static String DATASOURCE = "App_Data\\App_Data.sdf";
        private static String PASSWORD = "root";

        private static SqlCeConnection _SqlCeConnection;

        public static SqlCeConnection SqlCeConnection
        {
            get
            {
                if(_SqlCeConnection != null)
                {
                    return _SqlCeConnection;
                }
                else
                {
                    string connStr = "Data Source =" + AppDomain.CurrentDomain.BaseDirectory + DATASOURCE
                           + " ; Password = " + PASSWORD;

                    try
                    {
                        _SqlCeConnection = new SqlCeConnection(connStr);

                        _SqlCeConnection.Open();

                        return _SqlCeConnection;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("DataBase ERROR!  Contact your administrator to solve it!");

                        Application.Current.Shutdown();

                        return null;
                    }
                }
            }
        }


        public static void ClearSqlCeConnection( SqlCeConnection conn )
        {
            conn.Close();
        }
    }



    //MySQL 连接模块，暂时不需要
    //public class DataBaseConnection
    //{
    //    //database stuff
    //    private const String SERVER = "127.0.0.1";
    //    private const String DATABASE = "warehouse";
    //    private const String UID = "root";
    //    private const String PASSWORD = "root";
    //    private static MySqlConnection DBConnection;

    //    public static MySqlConnection GetSqlConnection()
    //    {
    //        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
    //        {
    //            Server = SERVER,
    //            UserID = UID,
    //            Password = PASSWORD,
    //            Database = DATABASE
    //        };

    //        DBConnection = new MySqlConnection(builder.ToString());

    //        return DBConnection;
    //    }

    //    public static void ClearSqlConnection()
    //    {
    //        DBConnection.Dispose();
    //        DBConnection = null;
    //    }

    //}

}
