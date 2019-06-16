using MVVM_WareHouse.DataBase;
using MVVM_WareHouse.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WareHouse.Service
{
    class TransactionsService
    {
        /// <summary>
        /// SQL commands
        /// </summary>
        private const string SQL_QUERY_TRANSACTION_INFO_BY_GOODS_ID = "SELECT * FROM TRANSACTIONS WHERE GOODS_ID = (@ID)";

        private const string SQL_QUERY_ALL_TRANSACTIONS = "SELECT * FROM TRANSACTIONS";

        private const string SQL_INSERT_TRANSACTIONS = "INSERT INTO TRANSACTIONS VALUES( @GOODS_ID, @USER_ID ,  @TOTAL_PRICE , " +
                                                         " @TRANSACTIONAMOUNT ,  @TRANSACTIONTIME )";

        private const string SQL_DELETE_TRANSACTION = "DELETE FROM TRANSACTIONS WHERE GOODS_ID = @GOODS_ID AND USER_ID = @USER_ID AND" +
                                                             " TOTAL_PRICE = @TOTAL_PRICE AND TRANSACTIONAMOUNT = @TRANSACTIONAMOUNT AND TRANSACTIONTIME = @TRANSACTIONTIME";


        private GoodsService goodsService;

        public TransactionsService()
        {
            goodsService = new GoodsService();
        }


        public bool AddTransaction(Transaction transaction)
        {

            SqlCeCommand addTransactionCommand = new SqlCeCommand(SQL_INSERT_TRANSACTIONS, SQLServerCompactConnection.SqlCeConnection);
            addTransactionCommand.Parameters.AddWithValue("@GOODS_ID", transaction.Goods.ID);
            addTransactionCommand.Parameters.AddWithValue("@USER_ID", transaction.User.ID);
            addTransactionCommand.Parameters.AddWithValue("@TOTAL_PRICE", transaction.Turnover);
            addTransactionCommand.Parameters.AddWithValue("@TRANSACTIONAMOUNT", transaction.TransactionAmount);
            addTransactionCommand.Parameters.AddWithValue("@TRANSACTIONTIME", transaction.TransactionTime);
            try
            {
                addTransactionCommand.ExecuteNonQuery();
                Goods goods = goodsService.QueryGoodsByID(transaction.Goods.ID);
                int amount = goods.StorageAmount - transaction.TransactionAmount;
                goodsService.UpdateGoodsAmount(transaction.Goods.ID , amount);
                return true;
            }
            catch (Exception e)
            {
                //TODO :: create a error window!
                Console.WriteLine(e.Message);
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool DeleteTransaction(Transaction transaction)
        {
            SqlCeCommand comm = new SqlCeCommand(SQL_DELETE_TRANSACTION, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@GOODS_ID", transaction.Goods.ID);
            comm.Parameters.AddWithValue("@USER_ID", transaction.User.ID);
            comm.Parameters.AddWithValue("@TOTAL_PRICE", transaction.Turnover);
            comm.Parameters.AddWithValue("@TRANSACTIONAMOUNT", transaction.TransactionAmount);
            comm.Parameters.AddWithValue("@TRANSACTIONTIME", transaction.TransactionTime);

            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                //TODO :: create a error window!

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public ObservableCollection<Transaction> QueryTransactionsByGoodsID(string id)
        {
            ObservableCollection<Transaction> transactionList = new ObservableCollection<Transaction>();

            SqlCeCommand comm = new SqlCeCommand(SQL_QUERY_TRANSACTION_INFO_BY_GOODS_ID, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID", id);

            SqlCeDataReader reader = comm.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    UsersService userInfo = new UsersService();
                    User user = userInfo.QueryUserByID(reader.GetString(1));         //TODO :: the name of the user will be init with user id

                    GoodsService goodsInfo = new GoodsService();
                    Goods goods = goodsInfo.QueryGoodsByID(reader.GetString(0));

                    Transaction trans = new Transaction(user, goods, reader.GetDouble(2), reader.GetInt32(3), reader.GetDateTime(4));

                    transactionList.Add(trans);
                }

                return transactionList;
            }
            catch (Exception e)
            {
                //TODO :: Create an error message box here
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public ObservableCollection<Transaction> QueryAllTransactions()
        {
            ObservableCollection<Transaction> transactionList = new ObservableCollection<Transaction>();

            SqlCeCommand comm = new SqlCeCommand(SQL_QUERY_ALL_TRANSACTIONS, SQLServerCompactConnection.SqlCeConnection);


            try
            {
                SqlCeDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    UsersService userInfo = new UsersService();
                    User user = userInfo.QueryUserByID(reader.GetString(1));         //TODO :: the name of the user will be init with user id

                    GoodsService goodsInfo = new GoodsService();
                    Goods goods = goodsInfo.QueryGoodsByID(reader.GetString(0));

                    Transaction trans = new Transaction(user, goods, reader.GetDouble(2), reader.GetInt32(3), reader.GetDateTime(4));

                    transactionList.Add(trans);
                }

                return transactionList;
            }
            catch (Exception e)
            {
                //TODO :: Create an error message box here
                Console.WriteLine(e.Message);

                return null;
            }

        }

    }
}
