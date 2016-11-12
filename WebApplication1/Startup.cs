using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EriZoo.Startup))]
namespace EriZoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
