using DAO.Context;
using Domain.Entities;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.Services
{
    //TODO: fazer if's de validação em todos os métodos, implementando o FluentValidation API

    public class ClientService : IClientService
    {
        private readonly MainContext _dbContext;
        public virtual async Task<DataResult<Client>> GetAllAsync()
        {
            var clients = await this._dbContext.Set<Client>().ToListAsync();
            return ResultFactory.CreateSuccessDataResult(clients);
        }

        public virtual async Task<SingleResult<Client>> GetByIdAsync(int id)
        {
            var client = await this._dbContext.Set<Client>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(client);
        }

        public virtual async Task<SingleResult<Client>> InsertAsync(Client client)
        {
            await this._dbContext.Set<Client>().AddAsync(client);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(client);
        }

        public virtual async Task<Result> UpdateAsync(Client client)
        {
            this._dbContext.Set<Client>().Update(client);
            await this._dbContext.SaveChangesAsync();
            return ResultFactory.CreateSuccessResult();
        }
    }
}
