using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IPlateService
    {
        Task<SingleResult<Plate>> InsertAsync(Plate plate);
        Task<Result> UpdateAsync(Plate plate);
        Task<SingleResult<Plate>> GetByIdAsync(int id);
        Task<DataResult<Plate>> GetAllAsync();
        Task<Result> DeleteAsync(Plate plate);

    }
}
