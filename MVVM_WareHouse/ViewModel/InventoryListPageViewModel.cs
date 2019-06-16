using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_WareHouse.Command;
using MVVM_WareHouse.Model;
using MVVM_WareHouse.Service;

namespace MVVM_WareHouse.ViewModel
{
    class InventoryListPageViewModel : NotifyObject
    {

        public InventoryListPageViewModel()
        {
            AddCommand = new AddGoodsCommand( this );

            Service = new GoodsService();

            this.ShowAllGoods();
        }

        #region Parameters

        private GoodsService Service;

        private ObservableCollection<Goods> _GoodsList;
        /// <summary>
        /// the list to show the goods the user need
        /// </summary>
        public ObservableCollection<Goods> GoodsList {
            get
            {
                if (_GoodsList == null) _GoodsList = new ObservableCollection<Goods>();

                return _GoodsList;
            }
            set
            {
                _GoodsList = value;
                OnPropertyChanged("GoodsList");
            }
        }

        #endregion


        #region Commands

        public AddGoodsCommand AddCommand { get; set; }


        #endregion

        #region Operations


        public void DeleteGoods( Object o )
        {

            Service.DeleteGoods( o as Goods );
            this.ShowAllGoods();
        }

        public void ShowAllGoods()
        {
            GoodsList = Service.QueryAllGoods();
        }

        public void ShowGoodsInfoByID( string id )
        {

            GoodsList.Clear();

            Goods goods = Service.QueryGoodsByID(id);

            if(goods != null)
            {
                GoodsList.Add( goods );
            }
            
        }

        #endregion
    }
}
