using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudMahasiswa.Startup))]
namespace CrudMahasiswa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
