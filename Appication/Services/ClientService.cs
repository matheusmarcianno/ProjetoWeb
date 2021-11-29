using Infrastructure.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValidationModel;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Threading.Tasks;

namespace Appication.Services
{
    public class ClientService : ClientValidationModel, IClientService
    {
        private readonly MainContext _dbContext;

        public ClientService(MainContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<DataResult<Client>> GetAllAsync()
        {
            var clients = await _dbContext.Set<Client>().Include(c => c.Orders).ToListAsync();
            return ResultFactory.CreateSuccessDataResult(clients);
        }

        public virtual async Task<SingleResult<Client>> GetByIdAsync(int id)
        {
            var client = await _dbContext.Set<Client>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(client);
        }

        public virtual async Task<SingleResult<Client>> InsertAsync(Client client)
        {
            var validation = this.Validate(client);
            if (!validation.IsValid)
            {
                return ResultFactory.CreateFailureSingleResult(client);
            }

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
