using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaLes__APIs.EntityLayer;
using SaLes__APIs.Serviecs.InterfaceServices;

namespace SaLes__APIs.Serviecs.RepositoryServices
{
    public class InvoiceRepository : MainRepositoryServices<Invoice>
    {
        private readonly SelasContext _context;
        public InvoiceRepository(SelasContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetByCustomer(Guid id) 
        {
            //var customer = await _context.Customer
            // .Include(c => c.Invoices)
            // .FirstOrDefaultAsync(c => c.CustomId == id );
            Customer? customer = await _context .Customer .FindAsync(id);
            if (customer == null) { return null; }
            else {
                List<Invoice> invo = await _context.Invoice.Include(c => c.CustomerNavigation).Where(o => o.Customer == id).ToListAsync();
                return invo;
            }


        }
    }
}
