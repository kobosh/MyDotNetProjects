using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MessageBoards.Startup))]
namespace MessageBoards
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
