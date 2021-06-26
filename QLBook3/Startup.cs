using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLBook3.Startup))]
namespace QLBook3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
