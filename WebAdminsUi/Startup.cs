using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAdminsUi.Startup))]
namespace WebAdminsUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
