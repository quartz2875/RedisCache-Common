/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using RedisCache.Common.Enums;
using RedisCache.Common.Repositories.Application;
using StackExchange.Redis;

namespace RedisCache.Common.Repositories.Persistence
{

    public class GenericRedisRepository<T> : IGenericRedisRepository<T> where T : class
    {
        private IConnectionMultiplexer _redis;

        public GenericRedisRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public bool DeleteStringByKey(string key)
        {
            var _db = _redis.GetDatabase();
            return _db.KeyDelete(key);
        }

        public T GetGenericTypeByKey(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetGenericTypeByKeyAsync(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetGenericTypeListByKey(string key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetGenericTypeListByKeyAsync(string key)
        {
            throw new NotImplementedException();
        }

        public string GetStringByKey(string key)
        {
            var _db = _redis.GetDatabase();

            var result = _db.StringGet(key);
            if (!string.IsNullOrEmpty(result))
                return result;

            return string.Empty;
        }

        public async Task<string> GetStringByKeyAsync(string key)
        {
            var _db = _redis.GetDatabase();

            var result = await _db.StringGetAsync(key);
            if (!string.IsNullOrEmpty(result))
                return result;
            return string.Empty;
        }

        public bool SetGenericType(string key, T value)
        {
            throw new NotImplementedException();

        }

        public Task<bool> SetGenericTypeAsync(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool SetString(string key, string value)
        {

            var _db = _redis.GetDatabase();
            return _db.StringSet(key, value);
        }

        public async Task<bool> SetStringAsync(string key, string value)
        {
            var _db = _redis.GetDatabase();
            return await _db.StringSetAsync(key, value);
        }

        public void SetHash(CacheSegment segment, string key, HashEntry[] value, string cacheServerKey = "", bool segmentKey = true, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            _db.HashSet(key, value, flags);
        }

        public async Task SetHashAsync(CacheSegment segment, string key, HashEntry[] value, string cacheServerKey = "", bool segmentKey = true, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            await _db.HashSetAsync(key, value, flags);
        }

        public HashEntry[] HashGetAllKey(CacheSegment segment, RedisKey key, string cacheServerKey = "", CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            var result = _db.HashGetAll(key, flags);
            if (result != null)
                return result;
            return default!;

        }

        public async Task<HashEntry[]> HashGetAllKeyAsync(CacheSegment segment, RedisKey key, string cacheServerKey = "", CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            var result = await _db.HashGetAllAsync(key, flags);
            if (result != null)
                return result;
            return default!;
        }

        public long HashDelByKeys(CacheSegment segment, RedisKey key, RedisValue[] hashKeys, string cacheServerKey = "", CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            return _db.HashDelete(key, hashKeys, flags);

        }

        public async Task<long> HashDelByKeysAsync(CacheSegment segment, RedisKey key, RedisValue[] hashKeys, string cacheServerKey = "", CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            return await _db.HashDeleteAsync(key, hashKeys, flags);
        }

        public string FormatKey(string key)
        {
            throw new NotImplementedException();
        }
    }

}