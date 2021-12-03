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
        protected readonly CategoryContext _dbContext;

        public CategoryService(CategoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<DataResult<Category>> GetAllAsync()
        {
            //var categories = await _dbContext.Set<Category>().Include(c => c.Plates).ToListAsync();
            var categories = await _dbContext.GetAllAsync();
            return ResultFactory.CreateSuccessDataResult(categories);
        }

        public async Task<SingleResult<Category>> GetByIdAsync(int id)
        {
            var category = await _dbContext.Set<Category>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(category);
        }

        public async Task<DataResult<Plate>> GetPlates(Category category)
        {
            // Esse método, neste contexo, retornar uma Category e tinha um .Include(c => c.Plates) antes do FirstOrDefault
            var categoryPlates = await _dbContext.Set<Plate>().FirstOrDefaultAsync(c => c.Id == category.Id);
            return ResultFactory.CreateSuccessDataResult(categoryPlates);
        }

        public virtual async Task<SingleResult<Category>> InsertAsync(Category category)
        {
            var validation = this.Validate(category);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(category);

            await this._dbContext.InsertAsync(category);

            return ResultFactory.CreateSuccessSingleResult(category);
        }

        public virtual async Task<Result> UpdateAsync(Category category)
        {
            var validation = this.Validate(category);
            if (!validation.IsValid)
                return ResultFactory.CreateSuccessResult();

            this._dbContext.Set<Category>().Update(category);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }

}
