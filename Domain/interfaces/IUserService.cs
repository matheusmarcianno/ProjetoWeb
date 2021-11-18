using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    internal interface IUserService
    {
        Task<SingleResult<User>> InsertAsync(User user);
        Task<SingleResult<User>> GetByIdAsync(int id);
        Task<DataResult<User>> GetAllAsync();
    }
}
