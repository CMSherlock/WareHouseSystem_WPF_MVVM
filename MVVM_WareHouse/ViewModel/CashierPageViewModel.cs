using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_WareHouse.Service;
using MVVM_WareHouse.Model;

namespace MVVM_WareHouse.ViewModel
{
    class CashierPageViewModel : NotifyObject
    {
        private GoodsService _GoodsService;
        private TransactionsService _TransactionService;

        

        public CashierPageViewModel(  )
        {
            _GoodsService = new GoodsService();
            _TransactionService = new TransactionsService();

            UserID = UserLoginInfo.UserID;
            UserName = UserLoginInfo.UserName;

            //fill two comboBox list
            this.InitComboBoxList();
            
        }

        #region Parameters

        public string UserID { get; set; }
        public string UserName { get; set; }

        private ObservableCollection<Goods> _GoodsList;
        /// <summary>
        /// The goods list to
        /// </summary>
        public ObservableCollection<Goods> GoodsList {
            get
            {
                if (_GoodsList == null) _GoodsList = _GoodsService.QueryAllGoods();

                return _GoodsList;
            }
            set => _GoodsList = value;
        }


        private List<string> _GoodsIDList;
        /// <summary>
        /// the list to work with the combobox
        /// </summary>
        public List<string> GoodsIDList {
            get
            {
                if(_GoodsIDList == null) _GoodsIDList = new List<string>();

                return _GoodsIDList;
            }
            set => _GoodsIDList = value;
        }

        private List<string> _GoodsNameList;
        /// <summary>
        /// the list to work with the combobox
        /// </summary>
        public List<string> GoodsNameList
        {
            get
            {
                if (_GoodsNameList == null) _GoodsNameList = new List<string>();

                return _GoodsNameList;
            }
            set => _GoodsNameList = value;
        }

        private Goods _TargetGoods;
        /// <summary>
        /// the goods that was chosed in comboBox
        /// </summary>
        public Goods TargetGoods {
            get => _TargetGoods;
            set
            {
                _TargetGoods = value;

                OnPropertyChanged("TargetGoods");
            } 
        }


        private ObservableCollection<Transaction> _TransactionsList;
        /// <summary>
        /// store the goods that are going to be sold
        /// </summary>
        public ObservableCollection<Transaction> TransactionsList {
            get
            {
                if (_TransactionsList == null) _TransactionsList = new ObservableCollection<Transaction>();

                return _TransactionsList;
            }
            set
            {
                _TransactionsList = value;
                UpdateTurnover();
                OnPropertyChanged("TransactionsList");
            }
        }

        private double _Turnover;
        /// <summary>
        /// the total turnover in this transaction
        /// </summary>
        public double Turnover {
            get => _Turnover;
            set
            {
                this._Turnover = value;
                OnPropertyChanged("Turnover");
            }
        }

        #endregion

        #region Operations

        public void SettlementAll()
        {
            foreach(Transaction transaction in TransactionsList)
            {
                //operate in database
                _TransactionService.AddTransaction(transaction);
            }

            TransactionsList.Clear();
            Turnover = 0;
        }

        public void AddNewTransaction( int amount )
        {
            string userID = UserLoginInfo.UserID;
            User user = new UsersService().QueryUserByID( userID );
            Goods goods = _GoodsService.QueryGoodsByID(TargetGoods.ID);
            Transaction transaction = new Transaction(user , goods, amount * goods.Price , amount , DateTime.Now);

            //show the list
            TransactionsList.Add(transaction);

            //update total price
            UpdateTurnover();

            //update the storageAmount 
            CorrectTargetGoodsAmount();
            
        }
        
        public void ClearTransactionsList()
        {
            Turnover = 0;
            TransactionsList.Clear();
            TargetGoods = _GoodsService.QueryGoodsByID(TargetGoods.ID);
        }

        /// <summary>
        /// Update Target goods when user change the comboBox selection
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isName"></param>
        public void UpdateTargetGoods(string input , bool isID)
        {

            foreach(var goods in GoodsList)
            {
                if (isID)
                {
                    //change targetgoods by goods id
                    if (input == goods.ID)
                    {
                        TargetGoods = goods;
                        CorrectTargetGoodsAmount();
                        return;
                    }
                }
                else
                {
                    //change targetgoods by goods name
                    if (input == goods.Name)
                    {
                        TargetGoods = goods;
                        CorrectTargetGoodsAmount();
                        return;
                    }
                }
            }

        }

        private void CorrectTargetGoodsAmount()
        {
            Goods goods = _GoodsService.QueryGoodsByID(TargetGoods.ID);

            foreach(Transaction transaction in TransactionsList)
            {
                if(transaction.Goods.ID == TargetGoods.ID)
                {
                    goods.StorageAmount -= transaction.TransactionAmount;
                }
            }

            TargetGoods = goods;
        }


        public void UpdateTurnover()
        {
            //reset the turnover
            Turnover = 0;

            foreach(Transaction transaction in TransactionsList)
            {
                Turnover += transaction.Turnover;
            }

        }

        /// <summary>
        /// Use by GoodsIDList and GoodsNameList 
        /// </summary>
        public void InitComboBoxList()
        {
            foreach(var goods in GoodsList)
            {
                GoodsIDList.Add(goods.ID);
                GoodsNameList.Add(goods.Name);
            }
        }

        #endregion
    }
}
