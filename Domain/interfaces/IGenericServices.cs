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
        Task<SingleResult>
    }
}
