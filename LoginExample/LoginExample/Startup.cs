using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginExample.Startup))]
namespace LoginExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
