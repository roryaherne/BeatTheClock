using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeatTheClock.Startup))]
namespace BeatTheClock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
