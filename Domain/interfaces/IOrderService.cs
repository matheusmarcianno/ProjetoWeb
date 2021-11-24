using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderService
    {
        Task<SingleResult<Order>> InsertAsync(Order order, ICollection<Plate> plates, int clientId);
        Task<Result> UpdateAsync(Order order, ICollection<Plate> plates);
        Task<SingleResult<Order>> GetByIdAsync(int id);
        Task<DataResult<Order>> GetAllAsync();
    }
}
