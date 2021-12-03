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
    public class UserService : UserValidationModel, IUserService
    {
        protected readonly UserContext _dbContext;

        public UserService(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<SingleResult<User>> Authenticate(User user)
        {
            var result = this.Validate(user);
            if (!result.IsValid)
                return ResultFactory.CreateFailureSingleResult(user);

            var userAuthenticate = await _dbContext.Authenticate(user);

            if (userAuthenticate == null)
                return ResultFactory.CreateFailureSingleResult(user);

            return ResultFactory.CreateSuccessSingleResult(user);
        }

        public virtual async Task<DataResult<User>> GetAllAsync()
        {
            return await this._dbContext.GetAllAsync();
        }

        //public virtual async Task<SingleResult<User>> GetByEmail(string email)
        //{
        //    var user = await _dbContext.Set<User>()
        //        .Include(u => u.Client)
        //        .Include(u => u.Restaurant)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(u => u.Email == email);

        //    if (user == null)
        //        return ResultFactory.CreateFailureSingleResult<User>();

        //    return ResultFactory.CreateSuccessSingleResult(user);
        //}

        public virtual async Task<SingleResult<User>> GetByIdAsync(int id)
        {
            return await this._dbContext.GetByIdAsync(id);
        }

        public async Task<SingleResult<User>> InsertAsync(User user)
        {
            var validation = this.Validate(user);
            if (!validation.IsValid)
                return ResultFactory.CreateSuccessSingleResult(user);

            return await this._dbContext.InsertAsync(user);
        }

        public virtual async Task<Result> UpdateAsync(User user)
        {
            var validation = this.Validate(user);
            if (!validation.IsValid)
                return ResultFactory.CreateSuccessSingleResult(user);

            return await this._dbContext.UpdateAsync(user);
        }
    }
}
