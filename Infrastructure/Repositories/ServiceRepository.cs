using Core.Entities;
using Core.Interfaces;

using Infarstuructre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly EServiceDbContext _context;

        public ServiceRepository(EServiceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
