using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extension;

public static class ApplicationServiceEstensions
{
    public static IServiceCollection AddApplicationServics(this IServiceCollection services,
         IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt => 
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        return services;

    }
}