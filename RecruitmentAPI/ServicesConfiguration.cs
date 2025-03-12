using DataAccess;
using Microsoft.EntityFrameworkCore;

using Application;
using DataAccess.Repositories;
using FluentValidation;
using RecruitmentAPI.Validators;
using RecruitmentAPI.Contracts;

namespace BalanceAPI
{
    public static class ServicesConfiguration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<ICandidatesService, CandidatesService>();
            var connectionString = configuration.GetConnectionString("PsqlConnection");
            services.AddDbContext<DbAccess>(options => options.UseNpgsql(connectionString));

            services.AddTransient<IValidator<RegisterCandidateRequest>, UserRegistrationValidator>();
        }
    }
}
