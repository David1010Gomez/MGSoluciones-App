using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MGSolucionesIntegrales.Startup))]
namespace MGSolucionesIntegrales
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
