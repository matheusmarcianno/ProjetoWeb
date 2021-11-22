﻿using DAO.Context;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
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
    public class RestaurantService : AbstractValidator<Restaurant>, IRestaurantService
    {
        protected readonly MainContext _dbContext;

        public virtual async Task<DataResult<Restaurant>> GetAllAsync()
        {
            var restaurants =  await this._dbContext.Set<Restaurant>().ToListAsync();
            return ResultFactory.CreateSuccessDataResult(restaurants);
        }

        public virtual async Task<SingleResult<Restaurant>> GetByIdAsync(int id)
        {
            var restaurant = await this._dbContext.Set<Restaurant>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(restaurant);
        }

        public virtual async Task<SingleResult<Restaurant>> InsertAsync(Restaurant restaurant)
        {
            var validation = this.Validate(restaurant);
            if (!validation.IsValid)
            {
                return ResultFactory.CreateFailureSingleResult(restaurant);
            }

            await this._dbContext.Set<Restaurant>().AddAsync(restaurant);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(restaurant);
        }

        public virtual async Task<Result> UpdateAsync(Restaurant restaurant)
        {
            this._dbContext.Set<Restaurant>().Update(restaurant);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }
}