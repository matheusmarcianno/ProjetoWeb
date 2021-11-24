using Infrastructure.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValidationModel;
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
    public class UserService : UserValidationModel, IUserService
    {
        protected readonly MainContext _dbContext;

        public virtual async Task<SingleResult<User>> Authenticate(User user)
        {
            var result = this.Validate(user);
            if (!result.IsValid)
                return ResultFactory.CreateFailureSingleResult<User>();

            var userAuthenticate = await this._dbContext.Set<User>()
                .Include(u => u.Client)
                .Include(u => u.Restaurant)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Password == user.Password && u.Email == user.Email);

            if (userAuthenticate == null)
                return ResultFactory.CreateFailureSingleResult<User>();

            return ResultFactory.CreateSuccessSingleResult(userAuthenticate);
        }

        public virtual async Task<DataResult<User>> GetAllAsync()
        {
            var users = await this._dbContext.Set<User>().ToListAsync();
            return ResultFactory.CreateSuccessDataResult(users);
        }

        public virtual async Task<SingleResult<User>> GetByEmail(string email)
        {
            var user = await this._dbContext.Set<User>()
                .Include(u => u.Client)
                .Include(u => u.Restaurant)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return ResultFactory.CreateFailureSingleResult<User>();

            return ResultFactory.CreateSuccessSingleResult(user);
        }

        public virtual async Task<SingleResult<User>> GetByIdAsync(int id)
        {
            var user = await this._dbContext.Set<User>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(user);
        }

        public async Task<SingleResult<User>> InsertAsync(User user)
        {
            var validation = this.Validate(user);

            if (!validation.IsValid)
            {
                return ResultFactory.CreateSuccessSingleResult(user);
            }

            await this._dbContext.Set<User>().AddAsync(user);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(user);
        }

        public virtual async Task<Result> UpdateAsync(User user)
        {
            this._dbContext.Set<User>().Update(user);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }
}
