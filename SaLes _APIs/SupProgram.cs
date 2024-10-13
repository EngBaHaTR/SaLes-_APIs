using Microsoft.EntityFrameworkCore;
using SaLes__APIs.EntityLayer;
using SaLes__APIs.Serviecs.BaseClass;
using SaLes__APIs.Serviecs.InterfaceServices;
using SaLes__APIs.Serviecs.RepositoryServices;
using SaLes__APIs.Serviecs.RouterClass;

namespace SaLes__APIs
{
    public static class SupProgram
    {
        public static IServiceCollection ConfigerDB(this IServiceCollection x , string con) 
        {
           
         return  x.AddDbContext<SelasContext>(u=>u.UseSqlServer(con));
        }
        public static void AddScopedClass (this IServiceCollection X ) 
        {
            X.AddScoped<BaseRouter, RouterCustomer>();
            X.AddScoped<BaseRouter, RouterInvoice>();
            X.AddScoped<BaseRouter, RouterProducts>();
        }
        public static void AddScopedIRepositoryServices(this IServiceCollection x) 
        {
            x.AddScoped<CustomerRepository>();
            x.AddScoped<InvoiceRepository>();
            x.AddScoped<ProductRepository>();
        }

    }
}
