using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.DataBase;
using System.Collections.ObjectModel;

namespace MVVM_WareHouse.Service
{
    class UsersService
    {
        private const string SQL_QUERY_USER_INFO_BY_ID = "SELECT * FROM USER_DATA WHERE ID = (@ID)";

        private const string SQL_QUERY_ALL_USER_INFO = "SELECT * FROM USER_DATA";

        private const string SQL_ADD_USER = "INSERT INTO USER_DATA VALUES(@ID , @PASSWORD , @ISADMIN , @NAME)";

        private const string SQL_DELETE_USER_BY_ID = "DELETE FROM USER_DATA WHERE ID = @ID";

        public UsersService()
        {
            
        }


        public User QueryUserByID( string id )
        {
            SqlCeCommand comm = new SqlCeCommand(SQL_QUERY_USER_INFO_BY_ID, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID" , id);

            try
            {
                SqlCeDataReader reader = comm.ExecuteReader();

                if (!reader.Read()) return null;                  //If reader didn't get a user data

                User user = new User(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2), reader.GetString(3));

                return user;
            }
            catch(Exception e)
            {

                //TODO :: Cearte a MessageBox Here

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public ObservableCollection<User> QueryAllUsers()
        {
            ObservableCollection<User> usersList = new ObservableCollection<User>();

            SqlCeCommand comm = new SqlCeCommand(SQL_QUERY_ALL_USER_INFO, SQLServerCompactConnection.SqlCeConnection);

            try
            {
                SqlCeDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2), reader.GetString(3));

                    usersList.Add(user);
                }

                return usersList;
            }
            catch (Exception e)
            {
                //TODO :: Cearte a MessageBox Here

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool AddUser( User user )
        {

            SqlCeCommand comm = new SqlCeCommand(SQL_ADD_USER, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID" , user.ID);
            comm.Parameters.AddWithValue("@PASSWORD", user.Password);
            comm.Parameters.AddWithValue("@ISADMIN" , user.IsAdmin);
            comm.Parameters.AddWithValue("NAME" , user.Name);

            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                //TODO :: Cearte a MessageBox Here

                Console.WriteLine(e.Message);
                return false;
            }

        }

        public bool DeleteUserByID( string userID )
        {

            SqlCeCommand comm = new SqlCeCommand(SQL_DELETE_USER_BY_ID, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID", userID);

            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                //TODO :: Cearte a MessageBox Here

                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}
