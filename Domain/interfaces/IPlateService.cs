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
        Task<DataResult<Plate>> Search(string search, int id);


    }
}
