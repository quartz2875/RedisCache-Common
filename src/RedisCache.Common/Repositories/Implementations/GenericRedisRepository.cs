/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BaseEntity.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RedisCache.Common.Repositories.Implementations.Abstractions;
using StackExchange.Redis;

namespace RedisCache.Common.Repositories.Implementations
{

    public class GenericRedisRepository<T, TId> : IGenericRedisRepository<T, TId> where T : BaseEntity<TId>
    {

        public const string GenericExceptionLogMessage = "An exception occured at {0} UTC. Exception details follow:.\n\nType: {1}\nMessage: {2}\nStack trace: {3}";
        private readonly IConnectionMultiplexer _redis;
        /// <summary>
        ///      Gets or sets an  <see cref="ILogger{BaseRepository}"/> representing application logger.
        /// </summary>
        protected readonly ILogger<GenericRedisRepository<T, TId>> _logger;

        /// <summary>
        /// Constructs a new instance of <see cref="RedisCacheService" />.
        /// </summary>
        /// <param name="multiplexer">
        ///     An <see cref="IRedisConnectionMultiplexer"/> representing the redis connection multiplexer.
        /// </param>

        public GenericRedisRepository(IConnectionMultiplexer redis, ILogger<GenericRedisRepository<T, TId>> logger)
        {
            _redis = redis;
            _logger = logger;

        }
        /// <inheritdoc />
        public bool DeleteStringByKey(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            return _db.KeyDelete(key, flags);
        }

        /// <inheritdoc />
        public string GetStringByKey(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);

            var result = _db.StringGet(key, flags);
            if (!string.IsNullOrEmpty(result))
                return result;

            return string.Empty;
        }
        /// <inheritdoc />
        public async Task<string> GetStringByKeyAsync(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);

            var result = await _db.StringGetAsync(key, flags);
            if (!string.IsNullOrEmpty(result))
                return result;
            return string.Empty;
        }


        /// <inheritdoc />
        public bool SetString(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {

            var _db = _redis.GetDatabase(dbIndex);
            return _db.StringSet(key, value, expiry, when, flags);
        }
        /// <inheritdoc />
        public async Task<bool> SetStringAsync(string key, string value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            return await _db.StringSetAsync(key, value);
        }
        /// <inheritdoc />
        public void SetHash(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            _db.HashSet(key, value, flags: flags);
        }
        /// <inheritdoc />
        public async Task SetHashAsync(string key, HashEntry[] value, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            await _db.HashSetAsync(key, value, flags);
        }
        /// <inheritdoc />
        public HashEntry[] HashGetAllKey(RedisKey key, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            var result = _db.HashGetAll(key, flags);
            if (result != null)
                return result;
            return default!;

        }
        /// <inheritdoc />
        public async Task<HashEntry[]> HashGetAllKeyAsync(RedisKey key, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            var result = await _db.HashGetAllAsync(key, flags);
            if (result != null)
                return result;
            return default!;
        }
        /// <inheritdoc />
        public long HashDelByKeys(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            return _db.HashDelete(key, hashKeys, flags);

        }
        /// <inheritdoc />
        public async Task<long> HashDelByKeysAsync(RedisKey key, RedisValue[] hashKeys, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            return await _db.HashDeleteAsync(key, hashKeys, flags);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<T>(string key, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            var result = await _db.StringGetAsync(key, flags: flags).ConfigureAwait(false);

            return !result.IsNull && result.HasValue ? JsonConvert.DeserializeObject<T>(result) : default(T);

        }
        /// <inheritdoc />
        public bool TryGetValue<T>(string key, out T item, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            RedisValue cachedItem = _db.StringGetAsync(key, flags).Result;
            if (!cachedItem.IsNull && cachedItem.HasValue)
            {
                item = JsonConvert.DeserializeObject<T>(cachedItem);
                return true;
            }

            item = default(T);
            return false;
        }
        /// <inheritdoc />
        public bool TryGetValue(string key, out string value, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            RedisValue cachedItem = _db.StringGetAsync(key, flags).Result;
            if (!cachedItem.IsNull)
            {
                value = cachedItem;
                return true;
            }

            value = null;
            return false;
        }
        /// <inheritdoc />
        public bool Set<T>(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            try
            {
                var _db = _redis.GetDatabase(dbIndex);
                return _db.StringSet(key, JsonConvert.SerializeObject(value), expiry, when, flags);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(
                    GenericExceptionLogMessage,
                    DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    exception.GetType().Name,
                    exception.Message,
                    exception.StackTrace);
                return false;
            }
        }
        /// <inheritdoc />
        public async Task<bool> SetAsync<T>(string key, T value, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            return await _db.StringSetAsync(key, JsonConvert.SerializeObject(value), expiry, when, flags).ConfigureAwait(false);
        }
        /// <inheritdoc />
        public void SetAll<T>(Dictionary<string, T> data, TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);

            try
            {
                var cacheItems = new List<Task<bool>>();

                foreach (var item in data)
                {
                    string serializedObject = JsonConvert.SerializeObject(item.Value, Formatting.Indented);
                    cacheItems.Add(_db.StringSetAsync(item.Key, serializedObject, expiry, when, flags));
                }

                Task.WhenAll(cacheItems.ToArray()).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(
                    GenericExceptionLogMessage,
                    DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    exception.GetType().Name,
                    exception.Message,
                    exception.StackTrace);
            }
        }
        /// <inheritdoc />
        public async Task SetManyHashEntriesAsync(Dictionary<RedisKey, IEnumerable<HashEntry>> entries, CommandFlags commandFlag = CommandFlags.None, int dbIndex = -1)
        {
            var _db = _redis.GetDatabase(dbIndex);
            try
            {
                List<Task> cachedItems = new();
                cachedItems.AddRange(from entry in entries select _db.HashSetAsync(entry.Key, entry.Value.ToArray(), commandFlag));
                if (cachedItems.Any()) await Task.WhenAll(cachedItems).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(
                    GenericExceptionLogMessage,
                    DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    exception.GetType().Name,
                    exception.Message,
                    exception.StackTrace);
            }
        }


    }

}