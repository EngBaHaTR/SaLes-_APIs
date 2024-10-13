using Microsoft.EntityFrameworkCore;
using SaLes__APIs.EntityLayer;
using SaLes__APIs.Serviecs.InterfaceServices;

namespace SaLes__APIs.Serviecs.RepositoryServices
{
    // Min Repository Services
    public class MainRepositoryServices <T> : IRepositoryServices<T> where T : class
    {
        private readonly SelasContext _context;
        public MainRepositoryServices(SelasContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {            
         await _context.Set<T>().AddAsync(entity);
         await _context.SaveChangesAsync();  
         return entity;
        }
    }
}
