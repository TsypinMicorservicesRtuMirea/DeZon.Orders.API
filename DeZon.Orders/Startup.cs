using DeZon.Orders.Extensions;
using DeZon.Orders.Infrastructure;
using DeZon.Orders.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DeZon.Orders;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        
        services
            .AddDbContext<DataContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<IRepository, DataContext>();
        
        services.AddControllers();
        
        services.AddSwaggerGen();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMigrationOfDbContext<DataContext>();
        
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
        
        app.UseRouting(); 
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}