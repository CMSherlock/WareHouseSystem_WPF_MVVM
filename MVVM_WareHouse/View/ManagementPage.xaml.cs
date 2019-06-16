using MVVM_WareHouse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// ManagementPage.xaml 的交互逻辑
    /// </summary>
    public partial class ManagementPage : Page
    {
        private ManagementPageViewModel ViewModel;

        private DispatcherTimer dispatcherTimer;

        public ManagementPage()
        {
            InitializeComponent();

            ViewModel = new ManagementPageViewModel();

            this.DataContext = ViewModel;

            //Init the Clock
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(); // 当间隔时间过去时发生的事件 
            dispatcherTimer.Tick += new EventHandler(ShowCurrentTime);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();

        }

        #region Clock
        /// <summary>
        /// Clock code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowCurrentTime(object sender, EventArgs e)
        {
            //获得时分秒
            this.tBlockTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        #endregion

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Normal_AddGridStateContainer.AddHandler(Grid.MouseRightButtonUpEvent, new MouseButtonEventHandler(Grid_MouseLeftButtonUp), true);
        //    SearchContainer.AddHandler(Grid.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Grid_MouseLeftButtonUp), true);
        //    QueryContainer.AddHandler(Grid.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Grid_MouseLeftButtonUp), true);
        //}

        //private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    System.Windows.MessageBox.Show("asdasdasd");
        //}

        #region Operations on databases

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.DeleteUser(UserList.SelectedItem))
            {
                MessageBox.Show("You can't delete admin user!");
            }
        }

        private void QueryAllUsers(object sender, MouseButtonEventArgs e)
        {
            ViewModel.ShowAllUsers();
        }


        /// <summary>
        /// Add a new user by the info the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitUserInfo(object sender, MouseButtonEventArgs e)
        {

            //Check if the input is legal
            if (string.IsNullOrWhiteSpace(IDInput.Text))
            {
                WarningText.Text = "ID can't be null or white space!";
                return;
            }
            else if (string.IsNullOrWhiteSpace(NameInput.Text))
            {
                WarningText.Text = "Name can't be null or white space!";
                return;
            }
            else if (string.IsNullOrWhiteSpace(PasswordInput.Text))
            {
                WarningText.Text = "Password can't be null or white space!";
                return;
            }

            //for now , the admin user can only create and delete the normal user account

            //Operate in database
            ViewModel.AddNewUser(IDInput.Text, PasswordInput.Text, false, NameInput.Text);

            //Clear all info the user input
            IDInput.Text = null;
            NameInput.Text = null;
            PasswordInput.Text = null;

            //reset the warning text
            WarningText.Text = null;

            //Change the geid back to Clock
            ChangeAddUserGridState(sender, e);

        }

        #endregion

        #region Operations to react the users operations

        private void OnEnterClick(object sender, KeyEventArgs e)
        {
            //Block Tab at the same time
            BlockTabKey(sender,e);

            if (e.Key == Key.Enter)
            {
                //query goods info by id
                ViewModel.ShowUserByID(SearchInput.Text);
            }
        }

        private void OnSearchInputLostFocus(object sender, RoutedEventArgs e)
        {
            SearchInput.Text = null;

            if (Keyboard.FocusedElement != SearchInputContainer)
            {
                SearchInputContainer.Visibility = Visibility.Collapsed;
            }
        }

        private void ChangeSearchInputBoxState(object sender, MouseButtonEventArgs e)
        {
            if (SearchInputContainer.Visibility == Visibility.Collapsed)
            {
                //change the visibility mode
                SearchInputContainer.Visibility = Visibility.Visible;

                //let the input box get the focus
                Keyboard.Focus(SearchInput);
            }
            else
            {

                SearchInputContainer.Visibility = Visibility.Collapsed;
                SearchInput.Text = null;
            }
        }

        
        private void ChangeAddUserGridState(object sender, MouseButtonEventArgs e)
        {
            //show the add user grid
            if (NormalGrid.Visibility == Visibility.Visible)
            {
                Normal_AddGridTrigger.Text = "Clock";
                NormalGrid.Visibility = Visibility.Collapsed;
                AddUserGrid.Visibility = Visibility.Visible;
            }
            else
            {
                Normal_AddGridTrigger.Text = "Add";
                NormalGrid.Visibility = Visibility.Visible;
                AddUserGrid.Visibility = Visibility.Collapsed;
            }
        }


        //Block the Tab key
        private void BlockTabKey(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Tab)
            {
                e.Handled = true;
                return;
            }
        }

        private void CollapsedSearchInputBox(object sender, MouseButtonEventArgs e)
        {
            if (SearchInputContainer.Visibility != Visibility.Collapsed)
            {
                SearchInputContainer.Visibility = Visibility.Collapsed;
            }
        }

        private void GirdClickEffect(object sender , MouseButtonEventArgs e)
        {
            var grid = sender as Grid;

            Thickness thickness = new Thickness();

            thickness.Top = 10;
            thickness.Bottom = 10;
            thickness.Left = 10;
            thickness.Right = 10;

            grid.Margin = thickness;
        }

        private void GirdClickEffectReCover(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;

            Thickness thickness = new Thickness();

            thickness.Top = 5;
            thickness.Bottom = 5;
            thickness.Left = 5;
            thickness.Right = 5;

            grid.Margin = thickness;
        }
        #endregion

    }
}
