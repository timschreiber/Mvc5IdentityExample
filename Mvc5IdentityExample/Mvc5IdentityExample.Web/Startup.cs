using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5IdentityExample.Web.Startup))]
namespace Mvc5IdentityExample.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
