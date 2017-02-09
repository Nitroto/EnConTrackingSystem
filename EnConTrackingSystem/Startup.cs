using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnConTrackingSystem.Startup))]
namespace EnConTrackingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
