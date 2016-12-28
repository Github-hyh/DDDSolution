using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDD.WebMvc.Startup))]
namespace DDD.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
