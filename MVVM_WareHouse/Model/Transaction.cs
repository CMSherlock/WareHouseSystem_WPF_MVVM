using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WareHouse.Model
{
    class Transaction
    {
        private User user;                      // the one who operate this transaction
        private Goods goods;                    // the goods info
        private int transactionAmount;          //how many goods was sold in this transaction
        private DateTime transactionTime;       //operation time
        private double turnover;              //total price of this transaction

        public Transaction(User user, Goods goods, double turnover , int transactionAmount, DateTime transactionTime )
        {
            this.User = user;
            this.Goods = goods;
            this.Turnover = turnover;
            this.TransactionAmount = transactionAmount;
            this.TransactionTime = transactionTime;
        }

        public Goods Goods { get => goods; set => goods = value; }
        public int TransactionAmount { get => transactionAmount; set => transactionAmount = value; }
        public DateTime TransactionTime { get => transactionTime; set => transactionTime = value; }
        public User User { get => user; set => user = value; }
        public double Turnover { get => turnover; set => turnover = value; }

        public override string ToString()
        {
            return "Operator = " + User.Name + "    Goods = " + Goods.Name + "Transaction Amount: " + TransactionAmount.ToString()
                               + "Total Price: " + Turnover.ToString() + "Transaction Time = " + TransactionTime.ToString();
        }

        public override bool Equals(object obj)
        {
            var transaction = obj as Transaction;
            return transaction != null &&
                   EqualityComparer<User>.Default.Equals(user, transaction.user) &&
                   EqualityComparer<Goods>.Default.Equals(goods, transaction.goods) &&
                   transactionAmount == transaction.transactionAmount &&
                   turnover == transaction.turnover &&
                   transactionTime == transaction.transactionTime;
        }

        public override int GetHashCode()
        {
            var hashCode = -393097060;
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(user);
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(goods);
            hashCode = hashCode * -1521134295 + transactionAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + turnover.GetHashCode();
            hashCode = hashCode * -1521134295 + transactionTime.GetHashCode();
            return hashCode;
        }
    }
}
