using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhongTot.Web.Startup))]
namespace PhongTot.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
