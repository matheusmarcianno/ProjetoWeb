using Infrastructure.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValidationModel;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Appication.Services
{
    public class PlateService : PlateValidationModel, IPlateService
    {
        protected readonly MainContext _dbContext;

        public PlateService(MainContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<Result> DeleteAsync(Plate plate)
        {
            this._dbContext.Set<Plate>().Remove(plate);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }

        public async Task<DataResult<Plate>> GetAllAsync()
        {
            var plates = await this._dbContext.Set<Plate>().Include(p => p.Category).ToListAsync();
            return ResultFactory.CreateSuccessDataResult(plates);
        }

        public virtual async Task<SingleResult<Plate>> GetByIdAsync(int id)
        {
            var plate = await this._dbContext.Set<Plate>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(plate);
        }

        public virtual async Task<SingleResult<Plate>> InsertAsync(Plate plate)
        {
            var validation = this.Validate(plate);
            if (!validation.IsValid)
            {
                return ResultFactory.CreateFailureSingleResult(plate);
            }

            await this._dbContext.Set<Plate>().AddAsync(plate);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(plate);
        }

        public virtual async Task<DataResult<Plate>> Search(string search, int id)
        {
            var searchResult = await _dbContext.Set<Plate>().Where(p => p.Name == search && p.RestaurantId == id).ToListAsync();

            if (searchResult == null)
                return ResultFactory.CreateFailureDataResult<Plate>();

            return ResultFactory.CreateSuccessDataResult(searchResult);
        }

        public virtual async Task<DataResult<Plate>> Search(string search)
        {
            var searchResult = await _dbContext.Set<Plate>().Where(p => p.Name == search).ToListAsync();

            if (searchResult == null)
                return ResultFactory.CreateFailureDataResult<Plate>();

            return ResultFactory.CreateSuccessDataResult(searchResult);
        }

        public async Task<DataResult<Plate>> GetPlates(Restaurant restaurant)
        {
            var restaurantPlates = await _dbContext.Set<Plate>().Where(p => p.RestaurantId == restaurant.Id).ToListAsync();
            return ResultFactory.CreateSuccessDataResult(restaurantPlates);
        }

        public virtual async Task<Result> UpdateAsync(Plate plate)
        {
            this._dbContext.Set<Plate>().Update(plate);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }
}
