﻿using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientService
    {
        Task<SingleResult<Client>> InsertAsync(Client client);
        Task<Result> UpdateAsync(Client client);
        Task<SingleResult<Client>> GetByIdAsync(int id);
        Task<DataResult<Client>> GetAllAsync();

    }
}
