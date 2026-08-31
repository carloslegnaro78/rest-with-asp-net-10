using RestWithASPNET10.Configurations;
using RestWithASPNET10.Repositories;
using RestWithASPNET10.Repositories.Impl;
using RestWithASPNET10.Services;
using RestWithASPNET10.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers()
    .AddContentNegotiation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenAPIConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddRouteConfig();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(
    builder.Configuration,
    builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IBookServices, BookServicesImpl>();
builder.Services.AddScoped<PersonServicesImplV2>();

builder.Services.AddScoped(
    typeof(IRepository<>),
    typeof(GenericRepository<>));

var app = builder.Build();

// Pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSpecification();
    app.UseScalarConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Rota para teste
app.MapGet("/", () => Results.Redirect("/scalar/v1"));

app.Run();