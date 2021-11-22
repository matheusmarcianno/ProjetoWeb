using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IUserService
    {
        Task<SingleResult<User>> InsertAsync(User user, int clientId);
        Task<Result> UpdateAsync(User usewr);
        Task<SingleResult<User>> GetByIdAsync(int id);
        Task<DataResult<User>> GetAllAsync();
    }
}
