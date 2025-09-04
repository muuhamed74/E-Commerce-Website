using Microsoft.EntityFrameworkCore;
using Store.Domain;
using Store.Domain.Models.Identity;
using Store.Domain.Services;
using Store.Domain.Specification;
using Store.Repo;
using Store.Repo.DataSeeding;
using Store.Repo.Repo;
using Store.Serv.Services;


namespace Evolve_Store.Extensions
{
    public static class StoreServiceExtension
    {
        public static async Task<IServiceCollection> AddStoreServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));



            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBasketRepository,BasketRepository>();
            services.AddScoped(typeof(ISpecification<>), typeof(BaseSpecification<>));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();


            //for redis cache
            services.AddSingleton<IResponcecasheservie, Responsecachservice>();

            //for email service
            services.Configure<EmailSetting>(config.GetSection("EmailSetting"));

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScoped<IAuthService, AuthService>();


            //services.AddScoped<IPasswordResetService, PasswordResetService>();

            services.AddScoped<ITemporaryUserRepository, TemporaryUserRepository>();
            services.AddScoped<IResetPasswordTempRepository, ResetPasswordTempRepository>();


            return services;

        }
    }
}
