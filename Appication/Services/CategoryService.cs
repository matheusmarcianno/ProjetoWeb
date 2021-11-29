using Infrastructure.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValidationModel;
using Shared.Results;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;

namespace Appication.Services
{
    public class CategoryService : CategoryValidationModel, ICategoryService
    {
        protected readonly MainContext _dbContext;

        public CategoryService(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<DataResult<Category>> GetAllAsync()
        {
            var categories = await _dbContext.Set<Category>().Include(c => c.Plates).ToListAsync();
            return ResultFactory.CreateSuccessDataResult(categories);
        }

        public async Task<SingleResult<Category>> GetByIdAsync(int id)
        {
            var category = await _dbContext.Set<Category>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(category);
        }

        public async Task<DataResult<Category>> GetPlates(Category category)
        {
            var categoryPlates = await _dbContext.Set<Category>().Include(c => c.Plates).FirstOrDefaultAsync(c => c.Id == category.Id);
            return ResultFactory.CreateSuccessDataResult(categoryPlates);
        }

        public virtual async Task<SingleResult<Category>> InsertAsync(Category category)
        {
            var validation =  this.Validate(category);
            if (!validation.IsValid)
            {
                return ResultFactory.CreateFailureSingleResult(category);
            }

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
