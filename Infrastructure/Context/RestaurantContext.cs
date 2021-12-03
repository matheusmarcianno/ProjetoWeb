using Domain.Entities;
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

namespace Infrastructure.Context
{
    public class RestaurantContext : IRestaurantService
    {
        public virtual async Task<DataResult<Restaurant>> GetAllAsync()
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM RESTAURANTS ORDER BY ID";

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var restaurants = new List<Restaurant>();

                while (await reader.ReadAsync())
                {
                    restaurants.Add(new Restaurant()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Cnpj = Convert.ToString(reader["CNPJ"]),
                        PhoneNumber = Convert.ToString(reader["PHONENUMBER"])
                    });
                }
                return ResultFactory.CreateSuccessDataResult(restaurants);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureDataResult<Restaurant>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Restaurant>> GetByIdAsync(int id)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM RESTAURANTS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return ResultFactory.CreateSuccessSingleResult(new Restaurant()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["Name"]),
                    Cnpj = Convert.ToString(reader["CNPJ"]),
                    PhoneNumber = Convert.ToString(reader["PHONENUMBER"])
                });
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Restaurant>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Restaurant>> InsertAsync(Restaurant restaurant)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO RESTAURANTS (NAME, CNPJ, PHONENUMBER) VALUES(@NAME, @CNPJ, @PHONENUMBER)";
            command.Parameters.AddWithValue("@NAME", restaurant.Name);
            command.Parameters.AddWithValue("@CNPJ", restaurant.Cnpj);
            command.Parameters.AddWithValue("@PHONENUMBER", restaurant.PhoneNumber);

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateSuccessSingleResult(restaurant);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Restaurant>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<Result> UpdateAsync(Restaurant restaurant)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE RESTAURANTS SET NAME = @NAME, CNPJ = @CNPJ, PHONENUMBER = @PHONENUMBER WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", restaurant.Id);
            command.Parameters.AddWithValue("@NAME", restaurant.Name);
            command.Parameters.AddWithValue("@CNPJ", restaurant.Cnpj);
            command.Parameters.AddWithValue("@PHONENUMBER", restaurant.PhoneNumber);
            command.Parameters.AddWithValue("@PHONENUMBER", restaurant.PhoneNumber);

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateSuccessSingleResult(restaurant);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Restaurant>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }
    }
}
