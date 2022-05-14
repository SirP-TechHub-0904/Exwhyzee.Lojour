using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Exwhyzee.Lojour.Web.Areas.Identity.IdentityHostingStartup))]
namespace Exwhyzee.Lojour.Web.Areas.Identity
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