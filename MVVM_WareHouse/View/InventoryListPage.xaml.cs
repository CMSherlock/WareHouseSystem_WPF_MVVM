using System;
using System.Collections.Generic;
using System.Data;
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
using MVVM_WareHouse.ViewModel;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// InventoryListPage.xaml 的交互逻辑
    /// </summary>
    public partial class InventoryPage : Page
    {
        private InventoryListPageViewModel viewModel;

        public InventoryPage()
        {
            InitializeComponent();

            viewModel = new InventoryListPageViewModel();

            this.DataContext = viewModel;

        }


        #region Functions to reaction to user's operation

        /// <summary>
        /// Open Stock window to add new goods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenStockWindow(object sender, MouseButtonEventArgs e)
        {

            var stockWindow = new StockGoodsWindow(this.DataContext as InventoryListPageViewModel);

            stockWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Current choose the way that the user can only create one stock window at the same time , and the user can't operate
            //on the main window while the new window is still open
            stockWindow.ShowDialog();

        }


        /// <summary>
        /// Monitor the "Enter" key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterClick(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                //query goods info by id
                viewModel.ShowGoodsInfoByID(SearchInput.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSearchInputLostFocus(object sender, RoutedEventArgs e)
        {
            SearchInput.Text = null;

            if(Keyboard.FocusedElement != SearchButton)
            {
                SearchInputContainer.Visibility = Visibility.Collapsed;
            }
        }


        #endregion

        #region Operations on databases


        /// <summary>
        /// show all goods when click the home button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllGoods(object sender, MouseButtonEventArgs e)
        {
            viewModel.ShowAllGoods();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteGoods(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteGoods(GoodsList.SelectedItem);
        }

        /// <summary>
        /// Use when user click the Search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBegin(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchInput.Text))
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
                }

                return;
            }

            //query goods info by id
            viewModel.ShowGoodsInfoByID(SearchInput.Text);
        }


        #endregion
    }
}
