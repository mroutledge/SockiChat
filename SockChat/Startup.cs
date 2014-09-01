using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SockChat.Startup))]
namespace SockChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
