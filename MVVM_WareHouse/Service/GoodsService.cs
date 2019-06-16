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
    class GoodsService
    {

        private const string SQL_INSERT_GOODS = "INSERT INTO INVENTORY VALUES( @ID, @NAME ,  @TYPE ,  @STORAGEAMOUNT ,  @STORAGETIME ,  @MANUFACTURER ,  @PRICE )";

        private const string SQL_UPDATE_GOODS_AMOUNT = "UPDATE INVENTORY SET STORAGEAMOUNT=@AMOUNT WHERE ID=@ID";

        private const string SQL_QUERY_GOODS_INFO_BY_ID = "SELECT * FROM INVENTORY WHERE ID = (@ID)";

        private const string SQL_QUERY_ALL_GOODS_INFO = "SELECT * FROM INVENTORY";

        private const string SQL_DELETE_USER_BY_ID = "DELETE FROM INVENTORY WHERE ID = @ID";


        public bool AddGoods(Goods goods)
        {

            SqlCeCommand comm = new SqlCeCommand(SQL_INSERT_GOODS, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID", goods.ID);
            comm.Parameters.AddWithValue("@NAME", goods.Name);
            comm.Parameters.AddWithValue("@TYPE", goods.Type);
            comm.Parameters.AddWithValue("@STORAGEAMOUNT", goods.StorageAmount);
            comm.Parameters.AddWithValue("@STORAGETIME", goods.StorageTime);
            comm.Parameters.AddWithValue("@MANUFACTURER", goods.Manufacturer);
            comm.Parameters.AddWithValue("@PRICE", goods.Price);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool DeleteGoods( Goods goods )
        {
            SqlCeCommand comm = new SqlCeCommand(SQL_DELETE_USER_BY_ID, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID", goods.ID);

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

        /// <summary>
        /// amount is the num after update
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UpdateGoodsAmount( string goodsID , int amount )
        {
            SqlCeCommand comm = new SqlCeCommand(SQL_UPDATE_GOODS_AMOUNT, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID", goodsID);
            comm.Parameters.AddWithValue("@AMOUNT", amount );

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

        public Goods QueryGoodsByID(string id)
        {

            SqlCeCommand comm = new SqlCeCommand(SQL_QUERY_GOODS_INFO_BY_ID, SQLServerCompactConnection.SqlCeConnection);

            comm.Parameters.AddWithValue("@ID", id);

            try
            {
                SqlCeDataReader reader = comm.ExecuteReader();

                if (!reader.Read()) return null;                  //If reader didn't get a user data

                Goods goods = new Goods(reader.GetString(0), reader.GetString(1), reader.GetDouble(6),
                                        reader.GetString(2), reader.GetString(5), reader.GetInt32(3), reader.GetDateTime(4));

                return goods;
            }
            catch (Exception e)
            {
                //TODO :: Create a error message window 

                Console.WriteLine(e.Message);

                return null;
            }

        }

        public ObservableCollection<Goods> QueryAllGoods()
        {
            ObservableCollection<Goods> goodsList = new ObservableCollection<Goods>();

            SqlCeCommand comm = new SqlCeCommand(SQL_QUERY_ALL_GOODS_INFO, SQLServerCompactConnection.SqlCeConnection);

            try
            {
                SqlCeDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Goods goods = new Goods(reader.GetString(0), reader.GetString(1), reader.GetDouble(6),
                                        reader.GetString(2), reader.GetString(5), reader.GetInt32(3), reader.GetDateTime(4));

                    goodsList.Add(goods);
                }

                return goodsList;
            }
            catch (Exception e)
            {
                //TODO :: Create a error message window 

                Console.WriteLine(e.Message);

                return null;
            }
        }
    }
}
