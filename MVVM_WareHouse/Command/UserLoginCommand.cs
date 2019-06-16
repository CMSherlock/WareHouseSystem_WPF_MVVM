using MVVM_WareHouse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.Service;

namespace MVVM_WareHouse.Command
{
    class UserLoginCommand : ICommand
    {
        private LoginWindowViewModel loginWindow;

        private UserLoginService loginService;


        public UserLoginCommand(LoginWindowViewModel viewModel)
        {
            this.loginWindow = viewModel;

            loginService = new UserLoginService();
        }

        public event System.EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (loginWindow == null) return false;

            return !string.IsNullOrWhiteSpace(loginWindow.UserIDInput)
                && !string.IsNullOrWhiteSpace(loginWindow.UserPasswordInput);
        }

        public void Execute(object parameter)
        {
            loginWindow.User_ID_Error_Text = null;
            loginWindow.User_Password_Error_Text = null;

            string state = loginService.CheckUserAccount(loginWindow.UserIDInput , loginWindow.UserPasswordInput);
            
            switch (state)
            {
                case STATEMENTS.USER_ID_ERROR:
                    loginWindow.User_ID_Error_Text = STATEMENTS.USER_ID_ERROR;
                    break;
                case STATEMENTS.USER_PASSWORD_ERROR:
                    loginWindow.User_Password_Error_Text = STATEMENTS.USER_PASSWORD_ERROR;
                    break;
                default:
                    loginWindow.JumpToMainWindow(state);
                    break;
            }
            
        }
    }
}
