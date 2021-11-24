using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<SingleResult<User>> Authenticate(User user);
        Task<SingleResult<User>> InsertAsync(User user);
        Task<Result> UpdateAsync(User usewr);
        Task<SingleResult<User>> GetByIdAsync(int id);
        Task<DataResult<User>> GetAllAsync();
        Task<SingleResult<User>> GetByEmail(string email);
    }
}
