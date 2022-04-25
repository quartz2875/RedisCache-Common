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

        bool SetString(string key, string value);
        Task<bool> SetStringAsync(string key, string value);

        string GetStringByKey(string key);
        Task<string> GetStringByKeyAsync(string key);

        bool DeleteStringByKey(string key);


        bool SetGenericType(string key, T value);
        Task<bool> SetGenericTypeAsync(string key, T value);

        T GetGenericTypeByKey(string key);
        Task<T> GetGenericTypeByKeyAsync(string key);

        IEnumerable<T> GetGenericTypeListByKey(string key);
        Task<IEnumerable<T>> GetGenericTypeListByKeyAsync(string key);

        //hash

        void SetHash(CacheSegment segment, string key, HashEntry[] value, string cacheServerKey = "", bool segmentKey = true, CommandFlags flags = CommandFlags.None);
        Task SetHashAsync(CacheSegment segment, string key, HashEntry[] value, string cacheServerKey = "", bool segmentKey = true, CommandFlags flags = CommandFlags.None);
        HashEntry[] HashGetAllKey(CacheSegment segment, RedisKey key, string cacheServerKey = "", CommandFlags flags = CommandFlags.None);
        Task<HashEntry[]> HashGetAllKeyAsync(CacheSegment segment, RedisKey key, string cacheServerKey = "", CommandFlags flags = CommandFlags.None);
        long HashDelByKeys(CacheSegment segment, RedisKey key, RedisValue[] hashKeys, string cacheServerKey = "", CommandFlags flags = CommandFlags.None);

        Task<long> HashDelByKeysAsync(CacheSegment segment, RedisKey key, RedisValue[] hashKeys, string cacheServerKey = "", CommandFlags flags = CommandFlags.None);

        string FormatKey(string key);
    }
}