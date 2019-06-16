using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WareHouse.Model
{
    public class Goods : INotifyPropertyChanged
    {

        private string id;              //由用户自己定义或者系统自动指定  以方便查找
        private string name;            //品名
        private double price;           //价格
        private string type;            //产品类型
        private string manufacturer;//产品提供厂家名称
        private int storageAmount;      //库存余量
        private DateTime storageTime;   //最近的入库时间

        public Goods(string id, string name , double price , string type, string manufacturer,  int storageAmount , DateTime storageTime)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Type = type;
            this.Manufacturer = manufacturer;
            this.StorageAmount = storageAmount;
            this.StorageTime = storageTime;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int StorageAmount { get => storageAmount; set => storageAmount = value; }
        public DateTime StorageTime { get => storageTime; set => storageTime = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public double Price { get => price; set => price = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return "ID = " + ID + "   Name = " + Name + "    Price = " + Price + "   Type = " + Type + "   StorageAmount = " + StorageAmount.ToString()
                + "   Manufacturer = " + Manufacturer + "   StorageTime = " + StorageTime.ToString();

        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   id == goods.id &&
                   name == goods.name &&
                   price == goods.price &&
                   type == goods.type &&
                   manufacturer == goods.manufacturer &&
                   storageAmount == goods.storageAmount &&
                   storageTime == goods.storageTime;
        }

        public override int GetHashCode()
        {
            var hashCode = 2068536636;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + storageAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + storageTime.GetHashCode();
            return hashCode;
        }
    }
}
