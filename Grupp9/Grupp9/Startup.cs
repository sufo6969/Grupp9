using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Grupp9.Startup))]
namespace Grupp9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
