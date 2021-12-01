using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataBase;
using Microsoft.Data.SqlClient;
using Shared.Factory;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class CategoryContext : IClientService
    {
        public async Task<DataResult<Client>> GetAllAsync()
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM CATEGORY ORDER BY ID";

            try
            {
                await connection.OpenAsync();
                SqlDataReader reader = command.ExecuteReader(); 
                var categories = new List<Category>();

                while (await reader.ReadAsync())
                {
                    categories.Add(new Category() { Id = Convert.ToInt32(reader["ID"]), Name = Convert.ToString(reader["Name"]) });
                }
                return ResultFactory.CreateSuccessDataResult(categories);
            } 
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public Task<SingleResult<Client>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResult<Client>> InsertAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
