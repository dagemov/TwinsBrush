using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Twins.Api.Data;
using Twins.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);//To ignoreCycles with the keys navigation on entities(get controller)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(x=> x.UseSqlServer("name=DefaultConnection"));
builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IApiService, ApiService>();


var app = builder.Build();

//Add Seedb ( OUR INYECTION !!!! ) a mano la hpta xd
SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (IServiceScope? scope = scopeFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin=>true)
    .AllowCredentials());

app.Run();
