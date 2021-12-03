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
            return await _dbContext.GetAllAsync();
        }

        public async Task<SingleResult<Category>> GetByIdAsync(int id)
        {
            return await _dbContext.GetByIdAsync(id);
        }

        public async Task<DataResult<Plate>> GetPlates(Category category)
        {
            return await _dbContext.GetPlates(category);
        }

        public virtual async Task<SingleResult<Category>> InsertAsync(Category category)
        {
            var validation = this.Validate(category);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(category);

            return await this._dbContext.InsertAsync(category);
        }

        public virtual async Task<Result> UpdateAsync(Category category)
        {
            var validation = this.Validate(category);
            if (!validation.IsValid)
                return ResultFactory.CreateSuccessSingleResult(category);

            return await this._dbContext.UpdateAsync(category);
        }
    }

}
