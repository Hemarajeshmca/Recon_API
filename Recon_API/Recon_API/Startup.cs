using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Recon_API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<confmodal>(Configuration.GetSection("AppSettings"));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:42374")
                            .AllowAnyHeader()
                            .AllowAnyMethod(); //THIS LINE RIGHT HERE IS WHAT YOU NEED
                    });
            });
            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    }

    internal class confmodal
    {
        private string Secret { get; set; }
}
}
