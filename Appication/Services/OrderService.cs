using Infrastructure.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValidationModel;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appication.Services
{
    public class OrderService : OrderValidationModel, IOrderService
    {
        protected readonly MainContext _dbContext;

        public OrderService(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<DataResult<Order>> GetAllAsync()
        {
            var orders = await this._dbContext.Set<Order>().Include(o => o.Client).ToListAsync();
            return ResultFactory.CreateSuccessDataResult(orders);
        }

        public async Task<SingleResult<Order>> GetByIdAsync(int id)
        {
            var order = await this._dbContext.Set<Order>().FindAsync(id);
            return ResultFactory.CreateSuccessSingleResult(order);
        }

        public virtual async Task<SingleResult<Order>> InsertAsync(Order order, List<Plate> plates, int clientId)
        {
            var validation = this.Validate(order);
            if (!validation.IsValid)
            {
                return ResultFactory.CreateFailureSingleResult(order);
            }

            order.ClientId = clientId;

            foreach (var plate in plates)
            {
                order.Plates.Add(plate);
            }

            await this._dbContext.Set<Order>().AddAsync(order);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessSingleResult(order);
        }

        public virtual async Task<Result> UpdateAsync(Order order, List<Plate> plates)
        {
            foreach(var plate in plates)
            {
                order.Plates.Add(plate);
            }

            this._dbContext.Set<Order>().Update(order);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }
}
