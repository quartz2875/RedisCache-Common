/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using RedisCache.Common.Enums;
using StackExchange.Redis;

namespace RedisCache.Common.Repositories.Application
{
    public interface IGenericRedisRepository<T> where T : class
    {

        /// <summary>
        ///     It is used to save a string expression as a string in the Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="value">
        ///     An <see cref="string"/> Represents the value to be stored in the Redis Cache.
        /// </param>
        /// <param name="expiry">
        ///     An <see cref="TimeSpan"/> It represents how long the value to be stored in the Redis Cache should remain in the Redis Cache.
        /// </param>
        /// <param name="when">
        ///     An <see cref="When"/> when: Which condition to set the value under (defaults to always).
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> returns a value representing whether the set operation was successful.
        /// </returns>
        bool SetString(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     used asynchronously to save a string expression as a string in the Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="value">
        ///     An <see cref="string"/> Represents the value to be stored in the Redis Cache.
        /// </param>
        /// <param name="expiry">
        ///     An <see cref="TimeSpan"/> It represents how long the value to be stored in the Redis Cache should remain in the Redis Cache.
        /// </param>
        /// <param name="when">
        ///     An <see cref="When"/> when: Which condition to set the value under (defaults to always).
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="Task<bool>"/> returns a value representing whether the set operation was successful.
        /// </returns>
        Task<bool> SetStringAsync(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     It is used to return a Value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="string"/> Represents the value returned from Redis Cache.
        /// </returns>
        string GetStringByKey(string key, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     Used to return a Value asynchronously in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="Task<string>"/> Represents the value returned from Redis Cache.
        /// </returns>
        Task<string> GetStringByKeyAsync(string key, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     It is used to remove a value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> Returns a value representing whether the value has been deleted from the Redis Cache.
        /// </returns>

        bool DeleteStringByKey(string key, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     It is used to save a string expression as a string in the Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="value">
        ///     An <see cref="T"/> Represents the value to be stored in the Redis Cache.
        /// </param>
        /// <param name="expiry">
        ///     An <see cref="TimeSpan"/> It represents how long the value to be stored in the Redis Cache should remain in the Redis Cache.
        /// </param>
        /// <param name="when">
        ///     An <see cref="When"/> when: Which condition to set the value under (defaults to always).
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> returns a value representing whether the set operation was successful.
        /// </returns>
        bool SetGenericType(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None);
        /// <summary>
        ///     used asynchronously to save a string expression as a string in the Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="value">
        ///     An <see cref="T"/> Represents the value to be stored in the Redis Cache.
        /// </param>
        /// <param name="expiry">
        ///     An <see cref="TimeSpan"/> It represents how long the value to be stored in the Redis Cache should remain in the Redis Cache.
        /// </param>
        /// <param name="when">
        ///     An <see cref="When"/> when: Which condition to set the value under (defaults to always).
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="Task<bool>"/> returns a value representing whether the set operation was successful.
        /// </returns>
        Task<bool> SetGenericTypeAsync(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None);
        /// <summary>
        ///     It is used to return a Value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="T"/> Represents the value returned from Redis Cache.
        /// </returns>
        T GetGenericTypeByKey(string key, CommandFlags flags = CommandFlags.None);
        /// <summary>
        ///     Used to return a Value asynchronously in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="Task<T>"/> Represents the value returned from Redis Cache.
        /// </returns>
        Task<T> GetGenericTypeByKeyAsync(string key, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     It is used to return a Value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="IEnumarable<T>"/> Represents the value returned from Redis Cache.
        /// </returns>
        IEnumerable<T> GetGenericTypeListByKey(string key, CommandFlags flags = CommandFlags.None);
        /// <summary>
        ///     Used to return a Value asynchronously in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="Task<IEnumarable<T>>"/> Represents the value returned from Redis Cache.
        /// </returns>
        Task<IEnumerable<T>> GetGenericTypeListByKeyAsync(string key, CommandFlags flags = CommandFlags.None);


        /// <summary>
        ///     It is used to save as HashEntry[] in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="value">
        ///     An <see cref="HashEntry[]"/> Represents the value to be stored in the Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// </returns>
        void SetHash(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None);
        /// <summary>
        ///    Used to save HashEntry[] asynchronously in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="value">
        ///     An <see cref="HashEntry[]"/> Represents the value to be stored in the Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// </returns>
        Task SetHashAsync(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     It is used to return a Value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="HashEntry[]"/> Represents the value returned from Redis Cache.
        /// </returns>

        HashEntry[] HashGetAllKey(RedisKey key, CommandFlags flags = CommandFlags.None);
        /// <summary>
        ///     Used to return a Value asynchronously in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="Task<HashEntry[]>"/> Represents the value returned from Redis Cache.
        /// </returns>
        Task<HashEntry[]> HashGetAllKeyAsync(RedisKey key, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     It is used to remove one or more values in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="hashKeys">
        ///     An <see cref="RedisValue[] "/> Represents the Key value below the Key in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="long"/> Returns the total number of affected records.
        /// </returns>
        long HashDelByKeys(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None);

        /// <summary>
        ///     Used to asynchronously remove one or more values in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="hashKeys">
        ///     An <see cref="RedisValue[] "/> Represents the Key value below the Key in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <returns>
        /// A <see cref="long"/> Returns the total number of affected records.
        /// </returns>

        Task<long> HashDelByKeysAsync(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None);

        string FormatKey(string key);
    }
}