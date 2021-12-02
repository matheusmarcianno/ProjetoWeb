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
    public class ClientContext : IClientService
    {
        public virtual async Task<DataResult<Client>> GetAllAsync()
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM CLIENTS ORDER BY ID";

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                var clients = new List<Client>();

                while (await reader.ReadAsync()) 
                {
                    clients.Add(new Client()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["NAME"]),
                        Cpf = Convert.ToString(reader["CPF"]),
                        Cep = Convert.ToString(reader["CEP"]),
                        BirthDate = Convert.ToDateTime(reader["BIRTHDATE"]),
                        PhoneNumber = Convert.ToString(reader["PHONENUMBER"])
                    });
                }
                return ResultFactory.CreateSuccessDataResult(clients);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureDataResult(new Client());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Client>> GetByIdAsync(int id)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM CLIENTS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                return ResultFactory.CreateSuccessSingleResult(new Client()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["NAME"]),
                    Cpf = Convert.ToString(reader["CPF"]),
                    Cep = Convert.ToString(reader["CEP"]),
                    BirthDate = Convert.ToDateTime(reader["BIRTHDATE"]),
                    PhoneNumber = Convert.ToString(reader["PHONENUMBER"])
                });
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(new Client());
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public virtual async Task<SingleResult<Client>> InsertAsync(Client client)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO CLIENTS (NAME, CPF, CEP, BITHDATE, PHONENUMBER) VALUES(@NAME, @CPF, @CEP, @BITHDATE, @PHONENUMBER)";
            command.Parameters.AddWithValue("@NAME", client.Name);
            command.Parameters.AddWithValue("@CPF", client.Cpf);
            command.Parameters.AddWithValue("@CEP", client.Cep);
            command.Parameters.AddWithValue("@BIRTHDATE", client.BirthDate);
            command.Parameters.AddWithValue("@PHONENUMBER", client.PhoneNumber);

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateSuccessSingleResult(client);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(client);
            }
        }

        public virtual async Task<Result> UpdateAsync(Client client)
        {
            var connection = SqlDataBase.GetSqlConnection();

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE CLIENTS SET NAME = @NAME, CPF = @CPF, CEP = @CEP, BITHDATE = @BITHDATE, PHONENUMBER = @PHONENUMBER WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", client.Id);
            command.Parameters.AddWithValue("@NAME", client.Name);
            command.Parameters.AddWithValue("@CPF", client.Cpf);
            command.Parameters.AddWithValue("@CEP", client.Cep);
            command.Parameters.AddWithValue("@BIRTHDATE", client.BirthDate);
            command.Parameters.AddWithValue("@PHONENUMBER", client.PhoneNumber);

            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return ResultFactory.CreateFailureSingleResult(client);
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult(client);
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }
    }
}
