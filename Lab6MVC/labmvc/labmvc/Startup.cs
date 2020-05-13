using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(labmvc.Startup))]
namespace labmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
