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
    public class PlateService : PlateValidationModel, IPlateService
    {
        protected readonly MainContext _dbContext;

        public virtual async Task<Result> DeleteAsync(Plate plate)
        {
            this._dbContext.Set<Plate>().Remove(plate);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }

        public async Task<DataResult<Plate>> GetAllAsync()
        {
            var plates = await this._dbContext.Set<Plate>().ToListAsync();
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

        public virtual async Task<Result> UpdateAsync(Plate plate)
        {
            var r = this._dbContext.Set<Plate>().Update(plate);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }
}
