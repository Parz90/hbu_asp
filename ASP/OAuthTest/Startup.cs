using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OAuthTest.Startup))]
namespace OAuthTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
