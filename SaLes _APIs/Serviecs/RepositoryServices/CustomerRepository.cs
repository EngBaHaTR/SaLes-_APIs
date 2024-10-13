using Microsoft.EntityFrameworkCore;
using SaLes__APIs.EntityLayer;
using SaLes__APIs.Serviecs.InterfaceServices;

namespace SaLes__APIs.Serviecs.RepositoryServices
{
    public class CustomerRepository : MainRepositoryServices<Customer>
    {
        public CustomerRepository(SelasContext context) : base(context)
        {
        }
    }
}
