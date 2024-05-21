using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Infarstuructre.Data;
using Core.Dots;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Infrastructure
{
    public class ServiceDetailsRepository : GenericRepository<ServiceDetails>, IServiceDetailsRepository
    {
        private readonly EServiceDbContext _context;

        public ServiceDetailsRepository(EServiceDbContext context) : base(context)
        {
            _context = context;
        }

      

     

    }
}
