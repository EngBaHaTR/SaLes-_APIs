

using SaLes__APIs.Serviecs.BaseClass;
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
                .Produces(200)
                .Produces<List<Customer>>()
                .Produces(404)
            //Get Customer By Id
                .Produces(200)
                .Produces<Customer>()
                .Produces(404)
            // Add new Customer
                .Produces(200)
        }

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
