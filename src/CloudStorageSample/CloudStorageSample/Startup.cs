using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloudStorageSample.Startup))]
namespace CloudStorageSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
