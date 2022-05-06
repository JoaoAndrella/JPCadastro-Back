using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace JPCadastro
{
    public static class Setup
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JPCadastros.WebAPI", Version = "v1" });
            });
        }

        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<JPCadastroContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
