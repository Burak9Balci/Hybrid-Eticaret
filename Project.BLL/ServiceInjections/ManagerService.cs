using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project.BLL.ServiceInjections
{
    public static class ManagerService
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services)
        {
          //  Scoped Services: Bir Request'te Scope'un parammtre kümesinde aynı tipte birden fazla parametre olsa bile 1 instance üzerinden calısırsınız...Ancak bu Singleton degildir...Cünkü Request'in işi bittigi zaman garbage collector Ram'den o instance'i kaldırır...Bir Request'in scope'unda aynı tipte birden fazla instance repository'ler ve Manager'lar icin gerekli degildir...O yüzden Scoped tercih edilir...

            services.AddScoped(typeof(IManager<>),typeof(BaseManager<>));
            services.AddScoped<IProductManager,ProductManager>();
            services.AddScoped<ICategoryManager,CategoryManager>();
            services.AddScoped<IOrderDetailManager,OrderDetailManager>();
            services.AddScoped<IOrderManager,OrderManager>();
            services.AddScoped<IAppRoleManager,AppRoleManager>();
            services.AddScoped<IAppUserManager,AppUserManager>();
            services.AddScoped<IUserProfileManager,UserProfileManager>();
            services.AddScoped<IAppUserRoleManager,AppUserRoleManager>();
            return services;
        }
    }
}
