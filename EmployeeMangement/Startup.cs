using EmployeeMangement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Read a connection string from appsettings.json
        string connectionString = Configuration.GetConnectionString("DefaultConnection");

        // Use the connection string to configure a DbContext, for example
        services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Other services and configurations
        // ...
    }

    // Other methods in the Startup class
    // ...
}

