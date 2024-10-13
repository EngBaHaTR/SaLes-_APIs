using SaLes__APIs;
using SaLes__APIs.Serviecs.BaseClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Configuer SelasContext
builder.Services.ConfigerDB(builder.Configuration.GetConnectionString("Def")?? string.Empty);
//Add SCped Class
builder.Services.AddScopedClass();
//Add scoped IRepository Services
builder.Services.AddScopedIRepositoryServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var x = app.Services.CreateScope()) 
{
    var services = x.ServiceProvider.GetServices<BaseRouter>();
    // Loop through each BaseRouter class
    foreach (var item in services)
    {
        // Invoke the AddRoutes() method to add the routes
        item.AddRoutes(app);
        
    };
}
app.Run();



