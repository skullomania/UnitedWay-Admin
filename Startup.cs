using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UWA.Startup))]
namespace UWA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
