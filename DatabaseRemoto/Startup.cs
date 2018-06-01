using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatabaseRemoto.Startup))]
namespace DatabaseRemoto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
