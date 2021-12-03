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
        protected readonly PlateContext _dbContext;

        public PlateService(PlateContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<Result> DeleteAsync(Plate plate)
        {
            return await _dbContext.DeleteAsync(plate);
        }

        public async Task<DataResult<Plate>> GetAllAsync()
        {
            return await this._dbContext.GetAllAsync();
        }

        public virtual async Task<SingleResult<Plate>> GetByIdAsync(int id)
        {
            return await this._dbContext.GetByIdAsync(id);
        }

        public virtual async Task<SingleResult<Plate>> InsertAsync(Plate plate)
        {
            var validation = this.Validate(plate);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(plate);

            return await this._dbContext.InsertAsync(plate);
        }

        public virtual async Task<DataResult<Plate>> Search(string search, int id)
        {
            if (search == null || id == 0)
                return ResultFactory.CreateFailureDataResult<Plate>();

            return await this._dbContext.SearchRestaurantPlates(search, id);
        }

        public virtual async Task<DataResult<Plate>> Search(string search)
        {
            if (search == null)
                return ResultFactory.CreateFailureDataResult<Plate>();

            return await this._dbContext.Search(search);
        }

        public async Task<DataResult<Plate>> GetPlates(Restaurant restaurant)
        {
            return await this._dbContext.GetPlates(restaurant);
        }

        public virtual async Task<Result> UpdateAsync(Plate plate)
        {
            var validation = this.Validate(plate);
            if (!validation.IsValid)
                return ResultFactory.CreateFailureSingleResult(plate);

            return await this._dbContext.UpdateAsync(plate);
        }
    }
}
