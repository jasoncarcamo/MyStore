using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyStore
{
    public class Startup
    {

        private readonly string _secretString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this._secretString = "MySecretsmlkmfwlemfmeewjhevryqbouhtipuhaoifbreuafbuafieunquuenfu";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://localhost:5000",
                        ValidAudience = "http://localhost:5000",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretString))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("auth",
                    policy => policy.RequireClaim("authorize")
                    );
            });

            services.AddCors();

            services.AddDbContext<MyStoreContext>(opt => opt.UseInMemoryDatabase("MyStore"));

            services.AddMvc();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseCors("*");
            app.UseDefaultFiles();
            app.UseStaticFiles();
           

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
