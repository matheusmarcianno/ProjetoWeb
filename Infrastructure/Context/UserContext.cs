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
    public class UserContext : IUserService
    {
        public virtual async Task<SingleResult<User>> Authenticate(User user)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM USERS WHERE EMAIL = @EMAIL AND PASSWORD = @PASSWORD";
            command.Parameters.AddWithValue("@EMAIL", user.Email);
            command.Parameters.AddWithValue("@PASSWORD", user.Password);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                return ResultFactory.CreateSuccessSingleResult(new User()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Email = Convert.ToString(reader["@EMAIL"]),
                    Password = Convert.ToString(reader["PASSWORD"])
                });
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<User>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<DataResult<User>> GetAllAsync()
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM USERS ORDER BY ID";

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var users = new List<User>();

                while (await reader.ReadAsync())
                {
                    users.Add(new User()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Email = Convert.ToString(reader["@EMAIL"]),
                        Password = Convert.ToString(reader["PASSWORD"])
                    });
                }

                return ResultFactory.CreateSuccessDataResult(users);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureDataResult<User>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<User>> GetByIdAsync(int id)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM USERS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return ResultFactory.CreateSuccessSingleResult(new User()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Email = Convert.ToString(reader["@EMAIL"]),
                    Password = Convert.ToString(reader["PASSWORD"])
                });
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<User>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<User>> InsertAsync(User user)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO USERS (EMAIL, PASSWORD, RESTAURANTID, CLIENTID) VALUES(@EMAIL, @PASSWORD, @RESTAURANTID, @CLIENTID)";
            command.Parameters.AddWithValue("@EMAIL", user.Id);
            command.Parameters.AddWithValue("@PASSWORD", user.Password);
            command.Parameters.AddWithValue("@RESTAURANTID", user?.RestaurantId);
            command.Parameters.AddWithValue("@CLIENTID", user?.ClientId);

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateSuccessSingleResult(user);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<User>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<Result> UpdateAsync(User user)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE USERS SET EMAIL = @EMAIL, PASSWORD = @PASSWORD WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", user.Id);
            command.Parameters.AddWithValue("@EMAIL", user.Email);
            command.Parameters.AddWithValue("@PASSWORD", user.Password);

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureResult();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }
    }
}
