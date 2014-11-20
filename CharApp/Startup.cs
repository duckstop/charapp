using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharApp.Startup))]
namespace CharApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
