/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RedisCache.Common.Configurations.Settings;
using RedisCache.Common.Configurations.Settings.Abstractions;
using RedisCache.Common.Repositories.Implementations;
using RedisCache.Common.Repositories.Implementations.Abstractions;

namespace RedisCache.Common
{

    public static class RedisServiceExtensions
    {
        public static IServiceCollection AddRedisService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IRedisSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<RedisSettings>>().Value);

            services.AddScoped(typeof(IGenericRedisRepository<,>), typeof(GenericRedisRepository<,>));
            return services;
        }
    }
}