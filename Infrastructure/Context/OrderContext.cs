using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infrastructure.DataBase;
using Microsoft.Data.SqlClient;
using Shared.Factory;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Context
{
    public class OrderContext : IOrderService
    {
        public virtual async Task<DataResult<Order>> GetRestaurantOrdersAsync(Restaurant restaurant)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"SELECT O.CLIENTID, O.STATUS, (C.NAME)[CLIENTID] FROM ORDERS O
                                    INNER JOIN CLIENTS C ON O.CLIENTID = C.ID WHERE RESTAURANTID = @ID";
            command.Parameters.AddWithValue("@ID", restaurant.Id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var allRestaurantOrders = new List<Order>();

                while (await reader.ReadAsync())
                {
                    allRestaurantOrders.Add(new Order()
                    {
                        Status = (Status)reader["STATUS"],
                        ClientId = (int)reader["CLIENTID"],
                    });
                }
                return ResultFactory.CreateSuccessDataResult(allRestaurantOrders);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureDataResult(new Order());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        // Esse método era pra ser o OrderDetails, mas está errado.
        public virtual async Task<SingleResult<Order>> GetByIdAsync(int id)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM ORDERS WHERE ID = @ID";

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return ResultFactory.CreateSuccessSingleResult(new Order()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Status = (Status)reader["STATUS"],
                    ClientId = Convert.ToInt32(reader["CLIENTID"]),
                    RestaurantId = Convert.ToInt32(reader["RESTAURANTID"]),
                });
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(new Order());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Order>> GetOrderDetails(Order order)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"SELECT OI.ORDERID, OI.PLATEID, OI.AMOUNT,
                                    (P.NAME) [PLATEID], P.PRICE [PLATEID] FROM ORDER_ITEMS OI
                                    INNER JOIN PLATES P ON OI.PLATEID = P.ID WHERE O.ID = @ID
                                    SELECT O.CLIENTID, (C.NAME)[CLIENTID] FROM ORDERS O
                                    INNER JOIN CLIENTS C ON O.CLIENTID = C.ID WHERE O.ID = @ID";

            command.Parameters.AddWithValue("ID", order.Id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return ResultFactory.CreateSuccessSingleResult(new Order()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Status = (Status)reader["STATUS"],
                    ClientId = Convert.ToInt32(reader["CLIENTID"]),
                    RestaurantId = Convert.ToInt32(reader["RESTAURANTID"]),
                });
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(new Order());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async  Task<SingleResult<Order>> InsertAsync(Order order)
        {
            order.Status = Domain.Enum.Status.Aceito;
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"INSERT INTO ORDERS (STATUS, CLIENTID, RESTAURANTID) 
                                    VALUES (@STATUS, @CLIENTID, @RESTAURANTID) SELECT SCOP_IDENTITY";
            command.Parameters.AddWithValue("@STATUS", order.Status);
            command.Parameters.AddWithValue("@CLIENTID", order.ClientId);
            command.Parameters.AddWithValue("@RESTAURANTID", order.RestaurantId);

            using (var scope = new TransactionScope())
            {
                try
                {
                    await connection.OpenAsync();
                    var generatedOrderId = Convert.ToInt32(command.ExecuteScalar());
                    foreach (Plate plate in order.Plates)
                    {
                        var command1 = new SqlCommand();
                        command1.Connection = connection;
                        command.CommandText = @"INSERT INTO ORDER_ITEMS (ORDERID, PLATEID, AMOUNT, TOTAL)
                                                VALUES (@ORDERID, @PLATEID, @AMOUNT, TOTAL)";
                        command.Parameters.AddWithValue("@ORDERID", generatedOrderId);
                        command.Parameters.AddWithValue("@PLATEID", plate.Id);
                        command.Parameters.AddWithValue("@AMOUNT", order.Plates.Count);
                        command.Parameters.AddWithValue("@TOTAL", plate.Price);
                        await command.ExecuteNonQueryAsync();
                    }
                    scope.Complete();
                    return ResultFactory.CreateSuccessSingleResult(order);
                }
                catch (Exception)
                {
                    return ResultFactory.CreateFailureSingleResult(order);
                }
                finally
                {
                    await connection.DisposeAsync();
                }
            }
        }
    }
}
