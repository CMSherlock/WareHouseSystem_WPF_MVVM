using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.ViewModel;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        ///// <summary>
        ///// Only use this function to debug the program
        ///// </summary>
        //public MainWindow()
        //{
        //    InitializeComponent();
        //    UserLoginInfo.InitUserInfo("admin" , "admin" , false);
        //    this.DataContext = new MainWindowViewModel(STATEMENTS.USER_ADMIN_ACCOUNT);
        //}

        public MainWindow(string type)
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(type);
        }

        #endregion

        #region Log out

        private void LogoutHandler(object sender, RoutedEventArgs e)
        {
            //change the window
            LoginWindow window = new LoginWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();

            //clear the user info
            UserLoginInfo.ClearUserInfo();
        }

        #endregion

        #region Get in touch with MainWindowViewModel  (Functions to keep MVVM)

        private void ChangeInnerPage(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MainWindowViewModel;

            var para = (sender as ListViewItem).Name;

            if (context.ChangeInnerPageCommand.CanExecute(para))
            {
                context.ChangeInnerPageCommand.Execute(para);
            }
        }

        #endregion

        #region  Operations on window   Didn't contain logic codes

        private void ButtonOpenMenuClick(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenuClick(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion

    }
}
