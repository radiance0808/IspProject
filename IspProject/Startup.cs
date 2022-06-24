using IspProject.Services;
using IspProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using IspProject.Settings;
using IspProject.Services.PotentialClient;
using IspProject.Services.Payment;

namespace IspProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string CorsPolicy = "_corsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
            builder.SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
            });

            services.AddScoped<IJWTAuthService, JWTAuthService>();
            services.AddScoped<IPotentialClientService, PotentialClientService>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidIssuer = "ispproject",
                           ValidAudience = "ispproject",
                           ClockSkew = TimeSpan.Zero,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]))
                       };
                   });

            //services.AddScoped<IDbService, DbService>();
            services.AddDbContext<AccountDbContext>(opt =>
            {
                opt.UseSqlServer("Server=tcp:ispprojectdb.database.windows.net,1433;Initial Catalog=IspProject;Persist Security Info=False;User ID=radyslavburylko;Password=ispproject_2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            /*var _jwtsettings = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(_jwtsettings);*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
           app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}