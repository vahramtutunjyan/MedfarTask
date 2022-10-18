using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medfar.Interview.Web.Startup))]
namespace Medfar.Interview.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
