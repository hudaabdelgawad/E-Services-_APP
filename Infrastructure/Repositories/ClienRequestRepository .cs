using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Infarstuructre.Data;
using Core.Dots;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq.Expressions;


namespace Infrastructure
{
    public class ClienRequestRepository : GenericRepository<ClientRequest>, IClienRequestRepository
    {
        private readonly EServiceDbContext _context;
        private readonly IMapper _mapper;
       
        public ClienRequestRepository(EServiceDbContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
          
        }

       

        public async Task<IEnumerable<ClientRequest>> GetAllAsync(string name,params Expression<Func<ClientRequest, object>>[] includes)
        {
            var query = _context.Set<ClientRequest>().Where(x => x.Client.UserName == name).AsQueryable();
            //apply any incluede
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public Task<ClientRequest> GetByNameAsync(string name, params Expression<Func<ClientRequest, object>>[] includes)
        {
            throw new NotImplementedException();
        }

       public async Task<bool>Delete(int id)
        {
            var isDeleted = true;

            var clientrequest =  _context.ClientRequest.Find(id);

            if (clientrequest is null)
                return  isDeleted;

           _context.Remove(clientrequest);
            var effectedRows =  _context.SaveChanges();



            return  isDeleted;
        }

        public async Task<bool> UpdateAsync(int id, ClientRequestView dto)
        {
            var currentrequest = await _context.ClientRequest.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (currentrequest is not null)
            {
                //update product
                var res = _mapper.Map<ClientRequest>(dto);
              
                res.Id = id;
                _context.ClientRequest.Update(res);
               
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

       





       

    }
}
