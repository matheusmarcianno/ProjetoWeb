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
        private readonly ClientContext _dbContext;

        public ClientService(ClientContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<DataResult<Client>> GetAllAsync()
        {
            return await _dbContext.GetAllAsync();
        }

        public virtual async Task<SingleResult<Client>> GetByIdAsync(int id)
        {
            return await this._dbContext.GetByIdAsync(id);
        }

        public virtual async Task<SingleResult<Client>> InsertAsync(Client client)
        {
            var validation = this.Validate(client);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(client);

            return await this._dbContext.InsertAsync(client);
        }

        public virtual async Task<Result> UpdateAsync(Client client)
        {
            var validation = this.Validate(client);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(client);

            return await this._dbContext.UpdateAsync(client);
        }
    }
}
