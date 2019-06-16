using MVVM_WareHouse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_WareHouse.Command
{
    class ChangeInnerPageCommand : ICommand
    {
        private MainWindowViewModel mainWindow;

        public ChangeInnerPageCommand(MainWindowViewModel main = null)
        {
            this.mainWindow = main;
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
            if (mainWindow != null && !string.IsNullOrWhiteSpace(parameter as string)) return true;
            else return false;
        }

        public void Execute(object parameter)
        {
            mainWindow.InnerPageUri = new Uri("/View/" + parameter as string + "Page.xaml", UriKind.Relative); 
        }
    }
}
