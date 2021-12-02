using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataBase;
using Microsoft.Data.SqlClient;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class OrderContext //: IOrderService
    {
        //public virtual async Task<DataResult<Order>> GetAllAsync()
        //{
        //    var connection = SqlDataBase.GetSqlConnection();

        //    var command = new SqlCommand();
        //    command.Connection = connection;
        //    command.CommandText = "SELECT * FROM ORDERS ORDER BY ID";

        //    try
        //    {
        //        connection.Open();
        //        var reader = await command.ExecuteReaderAsync();
        //        var orders = new List<Order>();
        //        while (reader.Read())
        //        {
        //            orders.Add(new Order()
        //            {

        //            });
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public Task<SingleResult<Order>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public Task<SingleResult<Order>> InsertAsync(Order order)
        //{
        //    var connection = SqlDataBase.GetSqlConnection();

        //    var command = new SqlCommand();
        //    command.Connection = connection;
        //    command.CommandText = "INSERT INTO ORDERS (STATUS, CLIENTID, RESTAURANTID)";

        //}

        public Task<Result> UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
