using ContactsWebApp.API.Validators;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.BLL.Repository;
using ContactsWebApp.BLL.Services;
using ContactsWebApp.DAL;
using ContactsWebApp.DAL.Repository;
using ContactsWebApp.Shared.Dto;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsWebApp.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                        b.MigrationsAssembly("ContactsWebApp.API")));

        public static void ConfigureUnitOfWork(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterRequestDto>, RegisterRequestValidator>();
            services.AddScoped<IValidator<CreateContactDto>, CreateContactValidator>();
        }
    }
}
