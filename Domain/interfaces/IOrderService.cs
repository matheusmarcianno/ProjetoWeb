using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IOrderService
    {
        Task<SingleResult<Order>> InsertAsync(Order order);
        //Task<SingleResult<Order>> InsertAsync(int id);
        Task<Result> UpdateAsync(Order order);
        Task<SingleResult<Order>> GetByIdAsync(int id);
        Task<DataResult<Order>> GetAllAsync();
    }
}
