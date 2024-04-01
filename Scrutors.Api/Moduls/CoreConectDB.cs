using Microsoft.EntityFrameworkCore;
using ShopShopMeneger.Data.Context;

namespace ShopMeneger.Api.Moduls
{
    public static class CoreConectDB
    {
        public static IServiceCollection AddConectDb(this IServiceCollection services, ConfigurationManager configuration)
        {
            configuration.AddUserSecrets<ShopContext>().Build();

            services.AddDbContext<ShopContext>(options =>
            {
                var conectionString = configuration
                .GetConnectionString("EfCoreShopDataBase");

                options.UseSqlServer(conectionString);
            });

            return services;
        }
    }
}
