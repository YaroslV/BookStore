using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreDemo.Startup))]
namespace BookStoreDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
