using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace net_core_api
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IAppBuilder app, IHostingEnvironment env, IApplicationBuilder application)
        {
            if (env.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application.UseMvc();
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Audience = "https://hockeyman62hotmail.onmicrosoft.com/api-service",
                    Tenant = "hockeyman62hotmail.onmicrosoft.com"
                });
        }
    }
}
