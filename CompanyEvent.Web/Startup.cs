using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyEvent.Web.Startup))]
namespace CompanyEvent.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
