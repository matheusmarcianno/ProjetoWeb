using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRestaurantService
    {
        Task<SingleResult<Restaurant>> InsertAsync(Restaurant restaurant);
        Task<Result> UpdateAsync(Restaurant restaurant);
        Task<SingleResult<Restaurant>> GetByIdAsync(int id);
        Task<DataResult<Restaurant>> GetAllAsync();
    }

}
