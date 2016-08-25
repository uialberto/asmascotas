using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuMascota.Startup))]
namespace TuMascota
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
