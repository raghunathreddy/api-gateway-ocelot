using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

//builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
 //   .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
 //   .AddEnvironmentVariables();
// Add Ocelot services
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// Use Ocelot middleware
app.UseOcelot().Wait();

app.Run();

//var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
//    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
//    .AddEnvironmentVariables();

//builder.Services.AddOcelot(builder.Configuration);

//var app = builder.Build();

// app.UseOcelot().Wait();

//app.Run();
