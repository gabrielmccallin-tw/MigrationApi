using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PatientDelta;
using PdsLookup;

namespace Api
{
    public class Startup
    {
        private readonly string _fakePatientsPath;
        
        public Startup(IConfiguration configuration)
        {
            _fakePatientsPath = ApplicationEnvironment.ApplicationBasePath + "/Data/FakePatients.json";
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
            //controllers
            services.AddControllers();

            //pds lookup
            services.AddSingleton<IPdsRetreiver>(x => new PdsRetreiver(_fakePatientsPath));

            //patient delta
            services.AddDbContext<PatientsContext>();
            services.AddScoped<IDeltaOrchestrator, DeltaOrchestrator>();
            services.AddSingleton<IIncomingTransferPatientMapper, IncomingTransferPatientMapper>();

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
            
            app.UseCors(
                options => 
                    options
                        .SetIsOriginAllowed(x => _ = true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
