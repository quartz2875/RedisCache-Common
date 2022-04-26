/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
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
        /// <inheritdoc />
        public bool DeleteStringByKey(string key, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            return _db.KeyDelete(key, flags);
        }
        /// <inheritdoc />
        public T GetGenericTypeByKey(string key, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<T> GetGenericTypeByKeyAsync(string key, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public IEnumerable<T> GetGenericTypeListByKey(string key, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public Task<IEnumerable<T>> GetGenericTypeListByKeyAsync(string key, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc />
        public string GetStringByKey(string key, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();

            var result = _db.StringGet(key, flags);
            if (!string.IsNullOrEmpty(result))
                return result;

            return string.Empty;
        }
        /// <inheritdoc />
        public async Task<string> GetStringByKeyAsync(string key, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();

            var result = await _db.StringGetAsync(key, flags);
            if (!string.IsNullOrEmpty(result))
                return result;
            return string.Empty;
        }
        /// <inheritdoc />
        public bool SetGenericType(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();

        }
        /// <inheritdoc />
        public Task<bool> SetGenericTypeAsync(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool SetString(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {

            var _db = _redis.GetDatabase();
            return _db.StringSet(key, value, expiry, when, flags);
        }
        /// <inheritdoc />
        public async Task<bool> SetStringAsync(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            return await _db.StringSetAsync(key, value);
        }
        /// <inheritdoc />
        public void SetHash(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            _db.HashSet(key, value, flags: flags);
        }
        /// <inheritdoc />
        public async Task SetHashAsync(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            await _db.HashSetAsync(key, value, flags);
        }
        /// <inheritdoc />
        public HashEntry[] HashGetAllKey(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            var result = _db.HashGetAll(key, flags);
            if (result != null)
                return result;
            return default!;

        }
        /// <inheritdoc />
        public async Task<HashEntry[]> HashGetAllKeyAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            var result = await _db.HashGetAllAsync(key, flags);
            if (result != null)
                return result;
            return default!;
        }
        /// <inheritdoc />
        public long HashDelByKeys(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None)
        {
            var _db = _redis.GetDatabase();
            return _db.HashDelete(key, hashKeys, flags);

        }
        /// <inheritdoc />
        public async Task<long> HashDelByKeysAsync(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None)
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