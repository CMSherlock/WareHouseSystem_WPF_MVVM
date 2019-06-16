using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MVVM_WareHouse.Model;
using MVVM_WareHouse.ViewModel;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// TransactionListPage.xaml 的交互逻辑
    /// </summary>
    public partial class TransactionListPage : Page
    {
        private TransactionListPageViewModel viewModel;

        public TransactionListPage()
        {
            InitializeComponent();

            viewModel = new TransactionListPageViewModel();

            this.DataContext = viewModel;

        }

        #region Functions to reaction to user's operation

        /// <summary>
        /// show all goods when click the home button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllTransactions(object sender, MouseButtonEventArgs e)
        {
            viewModel.ShowAllTransactions();
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
                    //change the visibility mode
                    SearchInputContainer.Visibility = Visibility.Collapsed;
                }

                return;
            }

            //query transactions info by goods id
            viewModel.ShowTransactionsInfoByGoodsID(SearchInput.Text);
        }

        /// <summary>
        /// Monitor the "Enter" key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterClick(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //query transactions info by goods id
                viewModel.ShowTransactionsInfoByGoodsID(SearchInput.Text);
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

            if (Keyboard.FocusedElement != SearchButton)
            {
                SearchInputContainer.Visibility = Visibility.Collapsed;
            }
        }

        #endregion

        #region Operations on databases

        private void DeleteTransaction(object sender, RoutedEventArgs e)
        {
            if (!UserLoginInfo.IsAdmin)
            {
                MessageBox.Show("Operation denied!!!");
                return;
            }

            viewModel.DeleteTransaction(TransactionLists.SelectedItem);
        }

        #endregion
    }
}
