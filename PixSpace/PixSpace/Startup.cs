using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PixSpace.Startup))]
namespace PixSpace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
