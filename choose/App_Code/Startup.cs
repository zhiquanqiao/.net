using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(choose.Startup))]
namespace choose
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
