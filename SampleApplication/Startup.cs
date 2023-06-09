using Microsoft.Owin;
using Owin;
using UPServiceApiClientLib;

[assembly: OwinStartup(typeof(SampleApplication.Startup))]

namespace SampleApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           AppStartup.Configuration(app);
        }
    }
}
