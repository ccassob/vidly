using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly.WebApp.Startup))]
namespace Vidly.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
