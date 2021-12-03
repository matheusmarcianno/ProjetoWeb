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
    public class PlateContext : IPlateService
    {
        public virtual async Task<Result> DeleteAsync(Plate plate)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM PLATES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", plate.Id);

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

        public virtual async Task<DataResult<Plate>> GetAllAsync()
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PLATES ORDER BY ID";

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var plates = new List<Plate>();

                while (await reader.ReadAsync())
                {
                    plates.Add(new Plate()
                    {
                        Id = Convert.ToInt32("ID"),
                        Name = Convert.ToString(reader["NAME"]),
                        Description = Convert.ToString(reader["DESCRIPTION"]),
                        Price = Convert.ToInt32(reader["PRICE"]),
                        CategoryId = Convert.ToInt32(reader["CATEGORYID"]),
                        RestaurantId = Convert.ToInt32(reader["RESTAURANTID"])
                    }); 
                }
                return ResultFactory.CreateSuccessDataResult(plates);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureDataResult<Plate>();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Plate>> GetByIdAsync(int id)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PLATES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                return ResultFactory.CreateSuccessSingleResult(new Plate()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["NAME"]),
                    Description = Convert.ToString(reader["DESCRIPTION"]),
                    Price = Convert.ToInt32(reader["PRICE"]),
                    CategoryId = Convert.ToInt32(reader["CATEGORYID"]),
                    RestaurantId = Convert.ToInt32(reader["RESTAURANTID"])
                });
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(new Plate());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<DataResult<Plate>> GetPlatesCategory(Category category)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PLATES WHERE CATEGORYID = @ID";
            command.Parameters.AddWithValue("@ID", category.Id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var platesCategory = new List<Plate>();

                while (await reader.ReadAsync())
                {
                    platesCategory.Add(new Plate
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["NAME"]),
                        Description = Convert.ToString(reader["DESCRIPTION"]),
                        Price = Convert.ToDouble(reader["PRICE"]),
                        CategoryId = Convert.ToInt32(reader["CATEGORYID"]),
                        RestaurantId = Convert.ToInt32(reader["RESTAURANTID"])
                    });
                }
                return ResultFactory.CreateSuccessDataResult(platesCategory);
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

        public virtual async Task<DataResult<Plate>> GetPlates(Restaurant restaurant)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PLATES WHERE RESTAURANTID = @ID";
            command.Parameters.AddWithValue("@ID", restaurant.Id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var restaurantPlates = new List<Plate>();
                while (await reader.ReadAsync())
                {
                    restaurantPlates.Add(new Plate()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["NAME"]),
                        Description = Convert.ToString(reader["DESCRIPTION"]),
                        Price = Convert.ToInt32(reader["PRICE"]),
                        CategoryId = Convert.ToInt32(reader["CATEGORYID"]),
                        RestaurantId = Convert.ToInt32(reader["RESTAURANTID"])
                    });
                }
                return ResultFactory.CreateSuccessDataResult(restaurantPlates);
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

        public virtual async Task<SingleResult<Plate>> InsertAsync(Plate plate)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO PLATES (NAME, DESCRIPION, PRICE, CATEGORYID, RESTAURANTID) VALUES(@NAME, @DESCRIPION, @PRICE, @CATEGORYID, @RESTAURANTID)";
            command.Parameters.AddWithValue("@NAME", plate.Name);
            command.Parameters.AddWithValue("@DESCRIPION", plate.Description);
            command.Parameters.AddWithValue("@PRICE", plate.Price);
            command.Parameters.AddWithValue("@CATEGORYID", plate.CategoryId);
            command.Parameters.AddWithValue("@RESTAURANTID", plate.RestaurantId);

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateFailureSingleResult(plate);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(plate);
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<DataResult<Plate>> SearchRestaurantPlates(string search, int id)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PLATES WHERE NAME = @NAME AND RESTAURANTID = @ID";
            command.Parameters.AddWithValue("@NAME", search);
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var restaurantPlates = new List<Plate>();

                while (await reader.ReadAsync())
                {
                    restaurantPlates.Add(new Plate()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["NAME"]),
                        Description = Convert.ToString(reader["DESCRIPTION"]),
                        Price = Convert.ToInt32(reader["PRICE"]),
                        CategoryId = Convert.ToInt32(reader["CATEGORYID"]),
                        RestaurantId = Convert.ToInt32(reader["RESTAURANTID"])
                    });
                }

                return ResultFactory.CreateSuccessDataResult(restaurantPlates);
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

        public virtual async Task<DataResult<Plate>> Search(string search)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM PLATES WHERE NAME = @NAME";
            command.Parameters.AddWithValue("@NAME", search);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var plates = new List<Plate>();

                while (await reader.ReadAsync())
                {
                    plates.Add(new Plate()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["NAME"]),
                        Description = Convert.ToString(reader["DESCRIPTION"]),
                        Price = Convert.ToInt32(reader["PRICE"]),
                        CategoryId = Convert.ToInt32(reader["CATEGORYID"]),
                        RestaurantId = Convert.ToInt32(reader["RESTAURANTID"])
                    });
                }

                return ResultFactory.CreateSuccessDataResult(plates);
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

        public virtual async Task<Result> UpdateAsync(Plate plate)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE PLATE SET NAME = @NAME, DESCRIPTION = @DESCRIPTION, PRICE = @PRICE, CATEGORYID = @CATEGORYID, ";
            command.Parameters.AddWithValue("@NAME", plate.Name);
            command.Parameters.AddWithValue("@DESCRIPTION", plate.Description);
            command.Parameters.AddWithValue("@PRICE", plate.Price);
            command.Parameters.AddWithValue("@CATEGORYID", plate.CategoryId);

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
