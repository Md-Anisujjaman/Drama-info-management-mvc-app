using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DramaManagement.Startup))]
namespace DramaManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
