using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPTShowHtml.Startup))]
namespace PPTShowHtml
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
