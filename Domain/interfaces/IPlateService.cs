using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlateService
    {
        Task<SingleResult<Plate>> InsertAsync(Plate plate);
        Task<Result> UpdateAsync(Plate plate);
        Task<SingleResult<Plate>> GetByIdAsync(int id);
        Task<DataResult<Plate>> GetAllAsync();
        Task<Result> DeleteAsync(Plate plate);
        Task<DataResult<Plate>> SearchRestaurantPlates(string search, int id);
        Task<DataResult<Plate>> Search(string search);
        Task<DataResult<Plate>> GetPlates(Restaurant restaurant);
        Task<DataResult<Plate>> GetPlatesCategory(Category category);



    }
}
