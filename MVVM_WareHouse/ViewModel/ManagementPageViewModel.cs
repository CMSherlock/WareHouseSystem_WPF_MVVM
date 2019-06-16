using MVVM_WareHouse.Model;
using MVVM_WareHouse.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WareHouse.ViewModel
{
    class ManagementPageViewModel : NotifyObject
    {
        private UsersService Service;

        public ManagementPageViewModel()
        {
            Service = new UsersService();
        }

        #region Parameters

        private ObservableCollection<User> _UsersList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<User> UsersList {
            get
            {
                if (_UsersList == null) _UsersList = new ObservableCollection<User>();

                return _UsersList;
            }
            set
            {
                _UsersList = value;

                OnPropertyChanged("UsersList");
            }
        }

        #endregion


        #region Operations on database

        public void ShowAllUsers()
        {
            UsersList = Service.QueryAllUsers();
        }

        public void ShowUserByID( string userID )
        {
            UsersList.Clear();
            var user = Service.QueryUserByID(userID);
            if(user != null)
            {
                UsersList.Add(user);
            }
        }

        public void AddNewUser( string userID , string password , bool isAdmin , string userName )
        {

            User user = new User(userID , password , isAdmin , userName);

            Service.AddUser(user);

            //show all users when the usersList Update
            ShowAllUsers();
        }

        public bool DeleteUser(Object o)
        {
            var user = o as User;

            //can't delete admin user
            if (user.IsAdmin)
            {
                return false;
            }

            Service.DeleteUserByID(user.ID);
            ShowAllUsers();

            return true;
        }

        #endregion

    }
}
