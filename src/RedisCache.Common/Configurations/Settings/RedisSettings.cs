using RedisCache.Common.Configurations.Settings.Abstractions;

namespace RedisCache.Common.Configurations.Settings
{
    public class RedisSettings : IRedisSettings
    {
        public string HostName { get; set; } = default!;
        public int HostPort { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int Database { get; set; }
        public int CacheDurationMinutes { get; set; }
        public bool Ssl { get; set; }
    }


}