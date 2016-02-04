using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnitityLocator.Startup))]
namespace EnitityLocator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
