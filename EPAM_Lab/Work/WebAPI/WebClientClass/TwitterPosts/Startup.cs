using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterPosts.Startup))]
namespace TwitterPosts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
