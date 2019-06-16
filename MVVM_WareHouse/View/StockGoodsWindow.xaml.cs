using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MVVM_WareHouse.ViewModel;
using MVVM_WareHouse.Model;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// StockGoodsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StockGoodsWindow : Window
    {
        public StockGoodsWindow( object viewModel )
        {
            InitializeComponent();

            this.DataContext = viewModel as InventoryListPageViewModel;
        }

        #region Submit

        private void SubmitCheck(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDInput.Text) || string.IsNullOrWhiteSpace(NameInput.Text)
                || string.IsNullOrWhiteSpace(TypeInput.Text) || string.IsNullOrWhiteSpace(ManufacturalInput.Text)
                || string.IsNullOrWhiteSpace(StorageAmountInput.Text) || string.IsNullOrWhiteSpace(PriceInput.Text))
            {
                SubmitButton.IsEnabled = false;
                return;
            }

            SubmitButton.IsEnabled = true;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            Goods goods = new Goods(IDInput.Text, NameInput.Text, System.Convert.ToDouble(PriceInput.Text), TypeInput.Text,
                                    ManufacturalInput.Text, Convert.ToInt32(StorageAmountInput.Text), DateTime.Now);

            var context = this.DataContext as InventoryListPageViewModel;

            if (context.AddCommand.CanExecute(goods))
            {
                context.AddCommand.Execute(goods);
            }

            //close this window after add the goods
            this.Close();
        }

        #endregion

        #region prevent user input characters at particular place

        private void TxtIndex_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal || e.Key.ToString() == "Tab")
            {
                if (txt.Text.Contains(".") && e.Key == Key.Decimal)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod) &&
                     e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Text.Contains(".") && e.Key == Key.OemPeriod)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //屏蔽中文输入和非法字符粘贴输入
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }

            //同时检测是否可以提交
            SubmitCheck(sender , e);
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
