using System;
using System.Linq;
using System.Configuration;
using System.IO;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.XtraReports.Web.ClientControls;
using DevExpress.XtraReports.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using DevExpress.DataAccess;
using DXAspNetCoreApp.Services;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using DevExpress.XtraReports.Web.ReportDesigner.Services;

namespace DXAspNetCoreApp {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDevExpressControls();
            services
                .AddSingleton<ReportStorageWebExtension, ReportStorageWebExtension1>()
                .AddSingleton<IWebDocumentViewerExceptionHandler, CustomWebDocumentViewerExceptionHandler>()
                .AddSingleton<IReportDesignerExceptionHandler, CustomReportDesignerExceptionHandler>()
                .AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            var connectionStringsConfiguretionSection = Configuration.GetSection("ConnectionStrings");
            DefaultConnectionStringProvider.AssignConnectionStrings(connectionStringsConfiguretionSection.AsEnumerable(true).ToDictionary(x => x.Key, y => y.Value));

            services.ConfigureReportingServices(configurator => {
                configurator.ConfigureReportDesigner(designerConfigurator => {
                    designerConfigurator.RegisterDataSourceWizardConfigurationConnectionStringsProvider(connectionStringsConfiguretionSection);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            var reportingLogger = loggerFactory.CreateLogger("Reporting");
            LoggerService.Initialize((ex, message) => {
                var errorString = string.Format("[{0}]: Exception occurred. Message: '{1}'. Exception Details:\r\n{2}", DateTime.Now, message, ex);
                reportingLogger.LogError(errorString);
            });
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(app.ApplicationServices.GetService<ReportStorageWebExtension>());
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
            app.UseDevExpressControls();
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules"
            });            
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}