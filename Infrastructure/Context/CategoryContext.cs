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
    public class CategoryContext : ICategoryService
    {
        public virtual async Task<DataResult<Category>> GetAllAsync()
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM CATEGORYS ORDER BY ID";

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var categories = new List<Category>();

                while (await reader.ReadAsync())
                {
                    categories.Add(new Category()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["NAME"])
                    });
                }
                return ResultFactory.CreateSuccessDataResult(categories);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureDataResult(new Category());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Category>> GetByIdAsync(int id)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM CATEGORYS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                connection.Open();
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                return ResultFactory.CreateSuccessSingleResult((new Category()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["NAME"])
                }));
            }
            catch (Exception ex)
            {
                return ResultFactory.CreateFailureSingleResult(new Category());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        // TODO: Esse método deve estar aqui retornando um DataResult<Plate> ou
        // deve estar no PlateContext passando uma Category como parametro?
        public virtual async Task<DataResult<Plate>> GetPlates(Category category)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT NAME, DESCRIPSTION, PRICE FROM PLATE WHERE CATEGORYID = @ID";
            command.Parameters.AddWithValue("@Id,", category.Id);

            try
            {
                connection.Open();
                var reader = await command.ExecuteReaderAsync();
                var categoryPlates = new List<Plate>();

                while (await reader.ReadAsync())
                {
                    categoryPlates.Add(new Plate()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["NAME"]),
                        Description = Convert.ToString(reader["DESCRIPTIO"]),
                        Price = Convert.ToInt32(reader["PRICE"]),
                        CategoryId = Convert.ToInt32(reader["CATEGORYID"]),
                        RestaurantId = Convert.ToInt32(reader["RESTAURANTID"])
                    });
                }
                return ResultFactory.CreateSuccessDataResult(categoryPlates);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureDataResult(new Plate());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Category>> InsertAsync(Category category)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO CATEGORYS (NOME) VALUES (@NOME)";
            command.Parameters.AddWithValue("@NOME", category.Name);

            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateSuccessSingleResult(category);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(category);
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public async Task<Result> UpdateAsync(Category category)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE CATEGORYS SET NAME = @NAME WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", category.Name);
            command.Parameters.AddWithValue("@ID", category.Id);

            try
            {
                connection.Open();
                var reader = await command.ExecuteNonQueryAsync();
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
