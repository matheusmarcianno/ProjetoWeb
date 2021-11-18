using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IGenericServices<TEntity> where TEntity : EntityBase
    {
        Task<SingleResult<TEntity>> InsertAsync(TEntity entity);
        Task<Result> UpdateAsync(TEntity entity); 
        Task<Result> DeleteAsync(TEntity entity);
        Task<Result> DeleteAsync(int id);
        Task<SingleResult<TEntity>> GetByIdAsync(int id);
        Task<DataResult<TEntity>> GetAllAsync();
    }
}
