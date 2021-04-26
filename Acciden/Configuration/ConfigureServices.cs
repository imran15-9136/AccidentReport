using Accident.BLL.Abstraction.Accident;
using Accident.BLL.Accident;
using Accident.Database;
using Accident.Repo.Abstraction.Accident;
using Accident.Repo.Accident;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acciden.Configuration
{
    public static class ConfigureServices
    {
        public static void Configure(IServiceCollection services, IConfiguration configruation)
        {
            //DB Connection
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configruation.GetConnectionString("DefaultConnection")));

            //Dependency Injection
            services.AddTransient<IAccidentBLL, AccidentBLL>();
            services.AddTransient<IAccidentRepo, AccidentRepo>();
        }
    }
}
