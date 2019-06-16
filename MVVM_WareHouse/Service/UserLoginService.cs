using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.DataBase;
using MVVM_WareHouse.Service;

namespace MVVM_WareHouse.Service
{
    class UserLoginService
    {
        UsersService queryUserInfo;

        public UserLoginService()
        {
            queryUserInfo = new UsersService();
        }


        public string CheckUserAccount( string id , string password )
        {
            User user = queryUserInfo.QueryUserByID( id );

            if (user == null) return STATEMENTS.USER_ID_ERROR;

            if (user.Password != password) return STATEMENTS.USER_PASSWORD_ERROR;

            //init the user info in static method
            UserLoginInfo.InitUserInfo(user.ID , user.Name , user.IsAdmin);

            if (user.IsAdmin) return STATEMENTS.USER_ADMIN_ACCOUNT;

            return STATEMENTS.USER_NORMAL_ACCOUNT;
        }

    }
}
