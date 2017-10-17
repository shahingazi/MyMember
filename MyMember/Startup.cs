using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMember.Startup))]
namespace MyMember
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
