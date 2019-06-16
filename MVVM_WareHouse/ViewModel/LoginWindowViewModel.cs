using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_WareHouse.Command;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.View;

namespace MVVM_WareHouse.ViewModel
{
    class LoginWindowViewModel : NotifyObject
    {
        #region Constructor && Father Object

        private LoginWindow _LoginWindow;

        public LoginWindowViewModel( LoginWindow loginWindow)
        {
            _LoginWindow = loginWindow;

            LoginCommand = new UserLoginCommand(this);
        }

        #endregion


        #region UserInput

        private string _UserIDInput;
        public string UserIDInput
        {
            get { return _UserIDInput; }
            set
            {
                _UserIDInput = value;
            }
        }

        private string _UserPasswordInput;
        public string UserPasswordInput
        {
            get { return _UserPasswordInput; }
            set
            {
                _UserPasswordInput = value;
            }
        }

        #endregion

        #region Parameters

        private string _User_ID_Error_Text;
        /// <summary>
        /// User Error warning text
        /// </summary>
        public string User_ID_Error_Text
        {
            get => _User_ID_Error_Text;
            set
            {
                _User_ID_Error_Text = value;
                OnPropertyChanged("User_ID_Error_Text");
            }
        }

        private string _User_Password_Error_Text;
        /// <summary>
        /// User Error warning text
        /// </summary>
        public string User_Password_Error_Text
        {
            get => _User_Password_Error_Text;
            set
            {
                _User_Password_Error_Text = value;
                OnPropertyChanged("User_Password_Error_Text");
                
            }
        }

        #endregion


        #region Command

        public UserLoginCommand LoginCommand { get; private set; }


        #endregion


        #region Functions

        public void JumpToMainWindow( string type)
        {
            _LoginWindow.JumpToMainWindow(type);
        }

        #endregion
    }
}
