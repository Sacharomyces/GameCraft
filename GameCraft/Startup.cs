using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameCraft.Startup))]
namespace GameCraft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
