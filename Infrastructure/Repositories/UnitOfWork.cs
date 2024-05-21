
using Core.Entities;
using Core.Interfaces;
using Infarstuructre.Data;
using AutoMapper;




namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EServiceDbContext _context;
        private readonly IMapper _mapper;

        public IServiceRepository ServiceRepository { get; }
        public IClienRequestRepository clienRequestRepository { get; }
        public IServiceDetailsRepository ServiceDetailsRepository { get; }

        public UnitOfWork(EServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
            ServiceRepository = new ServiceRepository(_context);
            ServiceDetailsRepository = new ServiceDetailsRepository(_context);
            clienRequestRepository = new ClienRequestRepository(_context,_mapper);

        }

    }
}
