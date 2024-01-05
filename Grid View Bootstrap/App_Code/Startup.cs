using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Grid_View_Bootstrap.Startup))]
namespace Grid_View_Bootstrap
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
