using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace samplemvc
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            })
                .ConfigureLogging(logging =>
                {
                  logging.ClearProviders();
                  logging.SetMinimumLevel(LogLevel.Information);
                  logging.AddAzureWebAppDiagnostics();
                })
            // .ConfigureServices(serviceCollection =>
            // {
            //     serviceCollection
            //     .Configure<AzureFileLoggerOptions>(options =>
            //     {
            //         options.FileName = "azure-diagnostics-";
            //         options.FileSizeLimit = 50 * 1024;
            //         options.RetainedFileCountLimit = 5;
            //     })
            //     .Configure<AzureBlobLoggerOptions>(options =>
            //     {
            //         options.BlobName = "log.txt";
            //     });
            // })
            .UseNLog();
  }
}
