﻿using ShopMeneger.Service;

namespace ShopMeneger.Api.Moduls
{
    public static  class CoreScrutor
    {
        public static IServiceCollection AddScrutor(this IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromAssembliesOf(typeof(IRequestHendler<>))
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<,,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
