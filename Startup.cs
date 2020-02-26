using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mis4200_team15.Startup))]
namespace mis4200_team15
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
