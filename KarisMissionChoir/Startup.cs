using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KarisMissionChoir.Startup))]
namespace KarisMissionChoir
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
