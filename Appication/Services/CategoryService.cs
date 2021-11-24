using Infrastructure.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValidationModel;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;

namespace Appication.Services
{
    public class CategoryService : CategoryValidationModel, ICategoryService
    {
        protected readonly MainContext _dbContext;

        public virtual async Task<DataResult<Category>> GetAllAsync()
        {
            var categories = await _dbContext.Set<Category>().Include(c => c.Plates).ToListAsync();
            return ResultFactory.CreateSuccessDataResult(categories);
        }

        public virtual async Task<SingleResult<Category>> InsertAsync(Category category)
        {
            await this._dbContext.Set<Category>().AddAsync(category);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(category);
        }

        public virtual async Task<Result> UpdateAsync(Category category)
        {
            this._dbContext.Set<Category>().Update(category);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }

}
