using Domain.Entities;
using Shared.Results;

using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<SingleResult<Category>> InsertAsync(Category category);
        Task<Result> UpdateAsync(Category category);
        Task<DataResult<Category>> GetAllAsync();
    }
}
