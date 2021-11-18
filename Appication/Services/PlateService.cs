using DAO.Context;
using Domain.Entities;
using Domain.interfaces;
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
    //TODO: implementar os if's de validação utilizando da FluentValidation API

    public class PlateService : IPlateService
    {
        protected readonly MainContext _dbContext;

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
            await this._dbContext.Set<Plate>().AddAsync(plate);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(plate);

        }

        //public Task<Result> UpdateAsync(Plate plate)
        //{
        //    var r = await new Result();
        //    return r;
        //}
    }
}
