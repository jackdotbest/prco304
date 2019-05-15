using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cesmvc.Startup))]
namespace cesmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
