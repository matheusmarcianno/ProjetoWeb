using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IClientService
    {
        Task<SingleResult<Client>> InsertAsync(Client client);
        Task<Result> UpdateAsync(Client client);
        Task<SingleResult<Client>> GetByIdAsync(int id);
        Task<DataResult<Client>> GetAllAsync();

    }
}
