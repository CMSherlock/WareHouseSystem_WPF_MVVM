using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_WareHouse.ViewModel;
using MVVM_WareHouse.Service;
using MVVM_WareHouse.Model;

namespace MVVM_WareHouse.Command
{
    class AddGoodsCommand : ICommand
    {

        private InventoryListPageViewModel viewModel;

        public AddGoodsCommand( InventoryListPageViewModel viewModel )
        {
            this.viewModel = viewModel;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
             return true;
        }

        public void Execute(object parameter)
        {
            Goods goods = parameter as Goods;

            GoodsService service = new GoodsService();

            //operator on database
            service.AddGoods(goods);

            //show the change at the same time
            viewModel.ShowAllGoods();
        }

    }
}
