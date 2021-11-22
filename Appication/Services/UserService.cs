using DAO.Context;
using Domain.Entities;
using Domain.interfaces;
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
    //TODO: Verificar com o Carlitos se a maneira com que fiz a validação na Service está correta.
    public class UserService : UserValidationModel, IUserService
    {
        protected readonly MainContext _dbContext;

        public virtual async Task<DataResult<User>> GetAllAsync()
        {
            var users = await this._dbContext.Set<User>().ToListAsync();
            return ResultFactory.CreateSuccessDataResult(users);
        }

        public virtual async Task<SingleResult<User>> GetByIdAsync(int id)
        {
            var user = await this._dbContext.Set<User>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(user);
        }

        public async Task<SingleResult<User>> InsertAsync(User user, int clientId)
        {
            var validation = this.Validate(user);

            if (!validation.IsValid)
            {
                return ResultFactory.CreateSuccessSingleResult(user);
            }

            user.ClientId = clientId;
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
