using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRestaurantService
    {
        Task<SingleResult<Restaurant>> InsertAsync(Restaurant restaurant);
        Task<Result> UpdateAsync(Restaurant restaurant);
        Task<SingleResult<Restaurant>> GetByIdAsync(int id);
        Task<DataResult<Restaurant>> GetAllAsync();
        Task<DataResult<Restaurant>> GetPlates(Restaurant restaurant);

    }

}
