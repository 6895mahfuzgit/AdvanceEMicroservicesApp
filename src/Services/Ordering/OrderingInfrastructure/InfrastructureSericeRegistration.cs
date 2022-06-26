using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderingApplication.Contracts.Infrastructure;
using OrderingApplication.Contracts.Presistence;
using OrderingApplication.Models;
using OrderingInfrastructure.Mail;
using OrderingInfrastructure.Presistence;
using OrderingInfrastructure.Repositories;

namespace OrderingInfrastructure
{
    public static class InfrastructureSericeRegistration
    {

        public static IServiceCollection AddInfrastructureSerices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<OrderContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c=>configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}
