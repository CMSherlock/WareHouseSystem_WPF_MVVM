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
using MVVM_WareHouse.ViewModel;

namespace MVVM_WareHouse.View
{
    /// <summary>
    /// CashierPage.xaml 的交互逻辑
    /// </summary>
    public partial class CashierPage : Page
    {
        private bool IfChanged = false;

        private CashierPageViewModel ViewModel;

        private DispatcherTimer dispatcherTimer;

        public CashierPage()
        {
            InitializeComponent();

            ViewModel = new CashierPageViewModel();

            this.DataContext = ViewModel;

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

        #region Operators on list

        private void UpdateTargetGoods(object sender, SelectionChangedEventArgs e)
        {
            if(GoodsID.SelectedValue == null)
            {
                return;
            }

            switch((sender as ComboBox).Name)
            {
                case "GoodsID":
                    if (!IfChanged)
                    {
                        Console.WriteLine("ASDASD");
                        IfChanged = true;
                        var str1 = GoodsID.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        ViewModel.UpdateTargetGoods(str1, true);
                    }
                    else
                    {
                        IfChanged = false;
                    }
                    break;
                case "GoodsName":
                    if (!IfChanged)
                    {
                        IfChanged = true;
                        var str2 = GoodsName.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        ViewModel.UpdateTargetGoods(str2, false);
                    }
                    else
                    {
                        IfChanged = false;
                    }
                    break;
                default:
                    break;
            }

        }

        private void SubmitCheck(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StorageAmountTextBlock.Text))
            {
                SubmitButton.IsEnabled = false;
            }
            else
            {
                SubmitButton.IsEnabled = true;
            }

        }

        private void ClearTransactionsList(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearTransactionsList();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            if (int.Parse(AmountInput.Text) > int.Parse(StorageAmountTextBlock.Text))
            {
                //set the amount to the same as the StorageAmount
                WarningText.Text = "Amount is larger than StorageAmount!";
            }
            else
            {
                //execute the add oper
                ViewModel.AddNewTransaction(int.Parse(AmountInput.Text));

                //Clear all input
                WarningText.Text = null;
                AmountInput.Text = null;
                SubmitButton.IsEnabled = false;
            }
        }

        private void SettlementAll(object sender, RoutedEventArgs e)
        {
            ViewModel.SettlementAll();
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
            SubmitCheck(sender, e);
        }

        private void OnEnterClick(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //submit
                Submit(sender , e);
            }
        }


        #endregion

        
    }
}
