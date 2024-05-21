using Core.Dots;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IClienRequestRepository : IGenericRepository<ClientRequest>
    {
        Task<ClientRequest> GetByNameAsync(string name, params Expression<Func<ClientRequest, object>>[] includes);
        Task<IEnumerable<ClientRequest>> GetAllAsync(string name,params Expression<Func<ClientRequest, object>>[] includes);
        Task<bool> UpdateAsync(int id,ClientRequestView dto);
        Task<bool>Delete(int id);
    }
}
