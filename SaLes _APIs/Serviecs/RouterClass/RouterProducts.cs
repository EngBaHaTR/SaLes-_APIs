using SaLes__APIs.Serviecs.BaseClass;
using SaLes__APIs.Serviecs.RepositoryServices;

namespace SaLes__APIs.Serviecs.RouterClass
{
    public class RouterProducts : BaseRouter
    {
        public RouterProducts()
        {
            UrlFragment = "/api/Product";
            TagName = "Product";
        }
        
        public override void AddRoutes(WebApplication app)
        {
            // Get All Product
                  .Produces(200)
                  .Produces(404)
                  .Produces<List<Product>>()
            // Add new Product Route
                .Produces(200)

        }

        {
            InfoMass = "U dont have any Product";
            IResult r;
            List <Product> products  = await repo.GetAll();
            try
            {
                if (products == null || products.Count == 0) { r = Results.NotFound(InfoMass); }
                else { r = Results.Ok(products); }
            }
            catch (Exception ex){ r = Results.Problem($"{InfoMass} : {ex.Message}"); }
            return r;

        }
        {
            InfoMass = "Created Well Don!";
            IResult r;
            Product Newproduct;
            try {
                Newproduct = await repo.Insert(entity);
                if (Newproduct != null) { r = Results.BadRequest(); }
                else { r = Results.Created(); }  
            }catch (Exception ex)
            {
                r = Results.Problem($"{InfoMass} : {ex.Message}");
            }
            return r;
        }

    }
}
