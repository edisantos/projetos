using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RefaccoSystem.Refacco.Startup))]
namespace RefaccoSystem.Refacco
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
