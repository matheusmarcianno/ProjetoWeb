using DAO.Context;
using Domain.Entities;
using Domain.interfaces;
using Shared.Factory;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.Services
{
    public class ClientService : IClientService
    {
        private readonly MainContext _dbContext;
        public virtual async Task<DataResult<Client>> GetAllAsync()
        {
            //TODO: fazer if de validação
            // mudar
            var clients = new List<Client>();
            return ResultFactory.CreateSuccessDataResult(clients);
        }

        public Task<SingleResult<Client>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResult<Client>> GetByIdAsync(Client a)
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
