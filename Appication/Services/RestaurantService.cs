using Infrastructure.Context;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Threading.Tasks;

namespace Appication.Services
{
    public class RestaurantService : AbstractValidator<Restaurant>, IRestaurantService
    {
        protected readonly RestaurantContext _dbContext;

        public RestaurantService(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<DataResult<Restaurant>> GetAllAsync()
        {
            return await this._dbContext.GetAllAsync();
        }

        public virtual async Task<SingleResult<Restaurant>> GetByIdAsync(int id)
        {
            return await this._dbContext.GetByIdAsync(id);

        }

        //public async Task<DataResult<Restaurant>> GetPlates(Restaurant restaurant)
        //{
        //    var restaurantPlates = await _dbContext.Set<Restaurant>().Include(r => r.Plates).FirstOrDefaultAsync(r => r.Id == restaurant.Id);
        //    return ResultFactory.CreateSuccessDataResult(restaurantPlates);
        //}

        public virtual async Task<SingleResult<Restaurant>> InsertAsync(Restaurant restaurant)
        {
            var validation = this.Validate(restaurant);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(restaurant);

            return await this._dbContext.InsertAsync(restaurant);
        }

        public virtual async Task<Result> UpdateAsync(Restaurant restaurant)
        {
            var validation = this.Validate(restaurant);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(restaurant);

            await this._dbContext.UpdateAsync(restaurant);
        }
    }
}
