using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.Service;

namespace MVVM_WareHouse.ViewModel
{
    class TransactionListPageViewModel : NotifyObject
    {

        public TransactionListPageViewModel()
        {

            Service = new TransactionsService();

            this.ShowAllTransactions();
        }


        #region parameters

        private TransactionsService Service;

        private ObservableCollection<Transaction> _TransactionList;
        /// <summary>
        /// List contains all the transaction details
        /// </summary>
        public ObservableCollection<Transaction> TransactionList
        {
            get
            {
                if(_TransactionList == null)
                {
                    _TransactionList = new ObservableCollection<Transaction>();
                }
                return _TransactionList;
            }
            set
            {
                _TransactionList = value;
                this.UpdateTurnover();
                OnPropertyChanged("TransactionList");
            }

        }

        private double _Turnover;
        /// <summary>
        /// the turnover of the list
        /// </summary>
        public double Turnover {
            get => _Turnover;
            set
            {
                _Turnover = value;
                OnPropertyChanged("Turnover");
            }
        }

        #endregion


        #region Operations

        public void ShowAllTransactions()
        {
            TransactionList = Service.QueryAllTransactions();
        }

        public void ShowTransactionsInfoByGoodsID(string id)
        {
            TransactionList.Clear();

            TransactionList = Service.QueryTransactionsByGoodsID(id);
        }

        public void DeleteTransaction(Object o)
        {

            Service.DeleteTransaction(o as Transaction);
            this.ShowAllTransactions();
        }

        private void UpdateTurnover()
        {
            Turnover = 0;

            foreach(Transaction transaction in TransactionList)
            {
                Turnover += transaction.Turnover;
            }
        }
        #endregion

    }
}
