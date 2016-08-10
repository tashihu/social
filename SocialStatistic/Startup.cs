using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialStatistic.Startup))]
namespace SocialStatistic
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
