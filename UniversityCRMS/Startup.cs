using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityCRMS.Startup))]
namespace UniversityCRMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
