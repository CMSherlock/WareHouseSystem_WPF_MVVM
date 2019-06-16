using System.Windows;
using System.Windows.Input;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.ViewModel;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            this.DataContext = new LoginWindowViewModel(this);
        }

        #region Operations for Controls

        public void JumpToMainWindow( string type)
        {
            MainWindow main = new MainWindow(type);
            main.Show();
            this.Close();
        }

        private void ForgotPassword(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact your admin to reset your password!");
        }

        #endregion

        #region Operations on window

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HideWindow(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Minimized;
            else if (WindowState == WindowState.Minimized)
                WindowState = WindowState.Normal;
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion
    }
}
