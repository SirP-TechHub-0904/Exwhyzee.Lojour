using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Exwhyzee.Lojour.Website.Areas.Identity.IdentityHostingStartup))]
namespace Exwhyzee.Lojour.Website.Areas.Identity
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