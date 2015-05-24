using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NerdDinner1._4.Startup))]
namespace NerdDinner1._4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
