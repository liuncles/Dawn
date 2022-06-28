namespace Dawn.Commons.Redis
{
    public interface IRedis
    {
        string Get(string key);
        void Set(string key, object t, DateTime? expiresSec = null);
        T Get<T>(string key) where T : new();
        Task<string> GetAsync(string key);
        Task SetAsync(string key, object t, DateTime? expiresSec = null);
        Task<T> GetAsync<T>(string key);
        bool SetDate(string key, DateTime date);
        Task<bool> SetDateAsync(string key, DateTime date);
        Task<bool> DeleteAsync(string key);
        bool Delete(string key);
        bool HSetNx(string key, string field, object value);
        Task<long> SAdd<T>(string key, params T[] obj);
        Task<long> SRemAsync<T>(string key, params T[] obj);
        Task<T[]> SMembersAsync<T>(string key);
        Task<bool> IsExist(string key);
        Task<long> SCardAsync(string key);
    }
}
