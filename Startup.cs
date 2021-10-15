using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using nursery.context;


namespace nursery
{
    public class Startup
    {
        private readonly string corsPolicy = "allowCorsPolicy";

        public static Assembly Assembly { get; } = typeof(Startup).Assembly;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddContexts(services);

            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options =>
            //     {
            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateIssuer = true,
            //             ValidateAudience = true,
            //             ValidateLifetime = true,
            //             ValidateIssuerSigningKey = true,
            //             ValidIssuer = Configuration["Jwt:Issuer"],
            //             ValidAudience = Configuration["Jwt:Audience"],
            //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
            //             ClockSkew = TimeSpan.Zero
            //         };
            //     });


            services.AddControllers();
            // services.AddControllers().AddNewtonsoftJson();

        }

        /// <summary>Add all the databases context for the DI</summary>
        /// <param name="services">Element to which we add the contexts</param>
        private void AddContexts(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<MyDbContext>(options =>
                options.UseMySQL(
                    connectionString,
                    b => b.MigrationsAssembly("AspNetCoreMultipleProject")
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            // app.UseMiddleware<SerilogMiddleware>();

            // app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(corsPolicy);

            app.UseRouting();
            // app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}