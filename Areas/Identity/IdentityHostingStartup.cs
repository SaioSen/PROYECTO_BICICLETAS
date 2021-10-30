using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PROYECTO_BICICLETAS.Areas.Identity.IdentityHostingStartup))]
namespace PROYECTO_BICICLETAS.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}