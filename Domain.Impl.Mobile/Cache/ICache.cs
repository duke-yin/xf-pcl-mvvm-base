using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodServicesOfAmerica.Domain.Cache
{
    public interface ICache
    {
        Task<T> GetObject<T>(string key);
        Task InsertObject<T>(string key, T value);
        Task InsertObject<T>(string key, T value, TimeSpan expiration);
        Task InsertObject<T>(string key, T value, DateTimeOffset absoluteExpiration);
        Task RemoveObject(string key);
    }
}
