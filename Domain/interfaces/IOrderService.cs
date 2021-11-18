using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    internal interface IOrderService
    {
        Task<SingleResult<Order>> InsertAsync(Order order);
        Task<Result> UpdateAsync(Order order);
        Task<SingleResult<Order>> GetByIdAsync(int id);
        Task<DataResult<Order>> GetAllAsync();
    }
}
