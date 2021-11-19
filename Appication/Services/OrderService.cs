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
    public class OrderService : IOrderService
    {
        protected readonly MainContext _dbContext;
        public virtual async Task<DataResult<Order>> GetAllAsync()
        {
            var orders = await this._dbContext.Set<Order>().ToListAsync();
            return ResultFactory.CreateSuccessDataResult(orders);
        }

        public async Task<SingleResult<Order>> GetByIdAsync(int id)
        {
            var order = await this._dbContext.Set<Order>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(order);
        }

        public virtual async Task<SingleResult<Order>> InsertAsync(Order order)
        {
            await this._dbContext.Set<Order>().AddAsync(order);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(order);
        }

        public virtual async Task<Result> UpdateAsync(Order order)
        {
            this._dbContext.Set<Order>().Update(order);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }
}
