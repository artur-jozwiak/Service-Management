using Microsoft.EntityFrameworkCore;
using Warsztat_v2.Data;

namespace Warsztat_v2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var conne = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ServiceContext>(options =>
                options.UseSqlServer(conne));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();
        }
    }
}
