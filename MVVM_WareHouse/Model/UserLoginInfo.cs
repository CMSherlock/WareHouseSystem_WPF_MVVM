using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WareHouse.Model
{
    class UserLoginInfo
    {

        private static bool _IfLogin;
        private static bool _IsAdmin;
        private static string _UserID;
        private static string _UserName;
        private static DateTime _LoginTime;

        public static bool IfLogin { get => _IfLogin; set => _IfLogin = value; }
        public static string UserID { get => _UserID; set => _UserID = value; }
        public static string UserName { get => _UserName; set => _UserName = value; }
        public static DateTime LoginTime { get => _LoginTime; set => _LoginTime = value; }
        public static bool IsAdmin { get => _IsAdmin; set => _IsAdmin = value; }

        public static void InitUserInfo( string userID , string userName , bool isAdmin)
        {
            IfLogin = true;
            IsAdmin = isAdmin;
            UserID = userID;
            UserName = userName;
            LoginTime = DateTime.Now;
        }

        public static void ClearUserInfo()
        {
            IfLogin = false;
            UserID = null;
            UserName = null;
        }
    }
}
