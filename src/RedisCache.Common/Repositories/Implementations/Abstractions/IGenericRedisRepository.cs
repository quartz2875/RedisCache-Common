/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BaseEntity.Common;
using StackExchange.Redis;

namespace RedisCache.Common.Repositories.Implementations.Abstractions
{
    public interface IGenericRedisRepository<T, TId> where T : BaseEntity<TId>
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
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> returns a value representing whether the set operation was successful.
        /// </returns>


        bool SetString(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

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
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="Task<bool>"/> returns a value representing whether the set operation was successful.
        /// </returns>
        Task<bool> SetStringAsync(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1);



        /// <summary>
        ///     Gets async the cached item by provided key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">
        ///      A <see cref="string"/> represents the cache key.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///  Try to get value the cached item by provided key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">
        ///      A <see cref="string"/> represents cache key.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <param name="item"></param>
        /// <returns></returns>
        bool TryGetValue<T>(string key, out T item, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///  Try to get value the cached item by provided key.
        /// </summary>
        /// <param name="key">
        ///      A <see cref="string"/> represents cache key.
        /// </param>
        /// <param name="value">
        ///     A <see cref="string"/> represents returned value from cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns></returns>
        bool TryGetValue(string key, out string value, CommandFlags flags = CommandFlags.None, int dbIndex = -1);



        /// <summary>
        ///     It is used to return a Value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="string"/> Represents the value returned from Redis Cache.
        /// </returns>
        string GetStringByKey(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///     Used to return a Value asynchronously in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="Task<string>"/> Represents the value returned from Redis Cache.
        /// </returns>
        Task<string> GetStringByKeyAsync(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///     It is used to remove a value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> Returns a value representing whether the value has been deleted from the Redis Cache.
        /// </returns>

        bool DeleteStringByKey(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///     It is used to save a string expression as a string in the Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <typeparam name="value">
        ///     An <see cref="T"/> Represents the value to be stored in the Redis Cache.
        /// </typeparam>
        /// <param name="expiry">
        ///     An <see cref="TimeSpan"/> It represents how long the value to be stored in the Redis Cache should remain in the Redis Cache.
        /// </param>
        /// <param name="when">
        ///     An <see cref="When"/> when: Which condition to set the value under (defaults to always).
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> returns a value representing whether the set operation was successful.
        /// </returns>
        bool Set<T>(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///     used asynchronously to save a string expression as a string in the Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="string"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <typeparam name="value">
        ///     An <see cref="T"/> Represents the value to be stored in the Redis Cache.
        /// </typeparam>
        /// <param name="expiry">
        ///     An <see cref="TimeSpan"/> It represents how long the value to be stored in the Redis Cache should remain in the Redis Cache.
        /// </param>
        /// <param name="when">
        ///     An <see cref="When"/> when: Which condition to set the value under (defaults to always).
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="Task<bool>"/> returns a value representing whether the set operation was successful.
        /// </returns>
        Task<bool> SetAsync<T>(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///     Sets a collection of items to the cache.
        /// </summary>
        /// <typeparam name="value">
        ///     An <see cref="T"/> Represents the value to be stored in the Redis Cache.
        /// </typeparam>
        /// <param name="expiry">
        ///     An <see cref="TimeSpan"/> It represents how long the value to be stored in the Redis Cache should remain in the Redis Cache.
        /// </param>
        /// <param name="when">
        ///     An <see cref="When"/> when: Which condition to set the value under (defaults to always).
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <param name="data">
        ///      A <see cref="Dictionary{TKey, TValue}"/> represents the dictionary of items that required to be cached.
        /// </param>
        void SetAll<T>(Dictionary<string, T> data, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

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
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// </returns>
        void SetHash(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None, int dbIndex = -1);
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
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// </returns>
        Task SetHashAsync(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None, int dbIndex = -1);


        /// <summary>
        /// Sets or update many collection of hash entries.
        /// </summary>
        /// <param name="entries">
        /// A <see cref="Dictionary{RedisKey, IEnumerable{HashEntry}}"/> represents the collection of hash entries.
        /// </param>
        /// <param name="commandFlag">
        /// A <see cref="CommandFlags"/> represents cache command flags, by deufalt None.
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        Task SetManyHashEntriesAsync(Dictionary<RedisKey, IEnumerable<HashEntry>> entries, CommandFlags commandFlag = CommandFlags.None, int dbIndex = -1);


        /// <summary>
        ///     It is used to return a Value in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="HashEntry[]"/> Represents the value returned from Redis Cache.
        /// </returns>

        HashEntry[] HashGetAllKey(RedisKey key, CommandFlags flags = CommandFlags.None, int dbIndex = -1);
        /// <summary>
        ///     Used to return a Value asynchronously in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="Task<HashEntry[]>"/> Represents the value returned from Redis Cache.
        /// </returns>
        Task<HashEntry[]> HashGetAllKeyAsync(RedisKey key, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

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
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="long"/> Returns the total number of affected records.
        /// </returns>
        long HashDelByKeys(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

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
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="long"/> Returns the total number of affected records.
        /// </returns>

        Task<long> HashDelByKeysAsync(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None, int dbIndex = -1);

        /// <summary>
        ///     Used to remove one or more values in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="hashField">
        ///     An <see cref="RedisValue[] "/> Represents the Key value below the Key in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="RedisValue[]"/> returns a value representing whether the set operation was successful.
        /// </returns>

        RedisValue[] GetHashValue(RedisKey key, RedisValue[] hashField, CommandFlags commandFlag = CommandFlags.None, int dbIndex = -1);
        /// <summary>
        ///     Used to asynchronously remove one or more values in Redis Cache.
        /// </summary>
        /// <param name="key">
        ///     An <see cref="RedisKey"/> It represents the Key value in Redis Cache.
        /// </param>
        /// <param name="hashField">
        ///     An <see cref="RedisValue[] "/> Represents the Key value below the Key in Redis Cache.
        /// </param>
        ///  <param name="flags">
        ///     An <see cref="CommandFlags"/> Represents which Redis Cache connection the data will communicate with (defaults to None).
        /// </param>
        /// <param name="dbIndex">
        /// A <see cref="int"/> represents which db Index to use in the Redis Cache (Default value is -1).
        /// </param>
        /// <returns>
        /// A <see cref="Task<RedisValue[]>"/> returns a value representing whether the set operation was successful.
        /// </returns>
        Task<RedisValue[]> GetHashValueAsync(RedisKey key, RedisValue[] hashField, CommandFlags commandFlag = CommandFlags.None, int dbIndex = -1);




    }
}