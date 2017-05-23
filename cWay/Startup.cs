using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cWay.Startup))]
namespace cWay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
