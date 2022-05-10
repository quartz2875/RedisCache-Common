/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisCache.Common.Repositories.Implementations;
using RedisCache.Common.Repositories.Implementations.Abstractions;
using StackExchange.Redis;

namespace RedisCache.Common
{

    public static class RedisServiceExtensions
    {
        public static IServiceCollection AddRedisService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(opt =>
                       ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")));

            services.AddScoped(typeof(IGenericRedisRepository<,>), typeof(GenericRedisRepository<,>));
            return services;
        }
    }
}