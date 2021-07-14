using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderPlacement.Startup))]
namespace OrderPlacement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
