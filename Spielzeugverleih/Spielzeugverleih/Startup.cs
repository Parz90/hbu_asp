using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Spielzeugverleih.Startup))]
namespace Spielzeugverleih
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
