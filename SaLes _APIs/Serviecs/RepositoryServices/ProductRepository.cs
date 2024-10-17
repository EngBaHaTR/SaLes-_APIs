using SaLes__APIs.EntityLayer;

namespace SaLes__APIs.Serviecs.RepositoryServices
{
    public class ProductRepository : MainRepositoryServices<Product>
    {
        public ProductRepository(SelasContext selasContext): base(selasContext) 
        {            
        }
    }
}
