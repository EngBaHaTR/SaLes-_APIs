

using SaLes__APIs.EntityLayer;
using SaLes__APIs.Serviecs.BaseClass;
using SaLes__APIs.Serviecs.InterfaceServices;
using SaLes__APIs.Serviecs.RepositoryServices;

namespace SaLes__APIs.Serviecs.RouterClass
{
    public class RouterCustomer  : BaseRouter
    {
        public RouterCustomer()
        {
            UrlFragment = "/api/Customer";
            TagName = "Customer";
                   
        }
        public override void AddRoutes(WebApplication app) 
        {     //Get All Customers
            app.MapGet($"{UrlFragment}/GetAll", (CustomerRepository repo) => GetAll(repo)).WithTags(TagName)
                .Produces(200)
                .Produces<List<Customer>>()
                .Produces(404)
                .Produces(500);
            //Get Customer By Id
            app.MapGet($"{UrlFragment}/{{id:Guid}}", (CustomerRepository repo , Guid id)=>GetById(repo,id)).WithTags(TagName)
                .Produces(200)
                .Produces<Customer>()
                .Produces(404)
                .Produces(500); ;
            // Add new Customer
            app.MapPost($"{UrlFragment}/Post", (CustomerRepository repo, Customer customer) => Insert(repo, customer)).WithTags(TagName)
                .Produces(200)
                .Produces(500);
        }

        protected virtual async Task<IResult> GetAll(CustomerRepository repo)
        {
            InfoMass = "Not Fund Any Customer";
            IResult r;
            List<Customer> result;
            
            try
            {
                result = await repo.GetAll();
                if (result == null || result.Count == 0) { r = Results.NotFound(InfoMass); }
                else { r = Results.Ok(result); }    
            }
            catch (Exception ex) 
            {
                r = Results.Problem($"{InfoMass} : {ex.Message}");
            }
            
            return r;
        }
        protected virtual async Task<IResult> GetById (CustomerRepository repo, Guid id)
        {
            InfoMass = $"Not Fund Customer with ID : {id}";
            IResult r;
            Customer? customer;
            try
            { 
                customer = await repo.GetById(id);
                if (customer == null) { r = Results.NotFound(InfoMass); }
                else { r = Results.Ok(customer);}
            }
            catch(Exception ex) 
            {
                r = Results.Problem(ex.Message);
            }
            return r;
        }
        protected virtual async Task<IResult> Insert(CustomerRepository repo, Customer customer)
        {
            InfoMass = "Created Well Don!";
            IResult r;
            Customer NewCustomer;
            try
            {
                NewCustomer = await repo.Insert(customer);
                if (customer == null) { r = Results.BadRequest("Error in Data for new Customer"); } 
                else  { r = Results.Created();} 
            }
            catch (Exception ex) 
            {
                r= Results.Problem(ex.Message);
            }
            return r;
        }
    }
}
