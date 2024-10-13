using SaLes__APIs.EntityLayer;
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
            app.MapGet($"{UrlFragment}/GetAll", (ProductRepository repo) => GetAll(repo)).WithTags(TagName)
                  .Produces(200)
                  .Produces(404)
                  .Produces<List<Product>>()
                  .Produces(500);
            // Add new Product Route
            app.MapPost($"{UrlFragment}/Post", (ProductRepository repo, Product entity) => Insert(repo, entity)).WithTags(TagName)
                .Produces(200)
                .Produces(500);

        }

        protected virtual async Task<IResult> GetAll(ProductRepository repo )
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
        protected virtual async Task<IResult> Insert(ProductRepository repo, Product entity)
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
