using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KTGiuaKi.Startup))]
namespace KTGiuaKi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
