
/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
namespace RedisCache.Common.Configurations.Settings.Abstractions
{
    /// <summary>
    ///     Represents the relevant settings required to set redis connections.
    /// </summary>
    public interface IRedisSettings
    {
        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the redis host name.
        /// </summary>
        string HostName { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the redis host port.
        /// </summary>
        int HostPort { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the redis user name.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the redis user password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="int"/> representing the redis db index.
        /// </summary>
        int Database { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="int"/> representing the redis cache duration in minutes.
        /// </summary>
        int CacheDurationMinutes { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="bool"/> representing the ssl of the redis connection.
        /// </summary>
        bool Ssl { get; set; }
    }
}