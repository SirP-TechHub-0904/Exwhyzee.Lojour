using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exwhyzee.Lojour.Base.Startup))]
namespace Exwhyzee.Lojour.Base
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
