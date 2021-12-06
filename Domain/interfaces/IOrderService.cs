using Domain.Entities;
using Shared.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderService
    {
        Task<SingleResult<Order>> InsertAsync(Order order);
        Task<SingleResult<Order>> GetByIdAsync(int id);
        Task<DataResult<Order>> GetRestaurantOrdersAsync(Restaurant restaurant);
    }
}
