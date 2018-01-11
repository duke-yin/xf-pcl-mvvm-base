using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ModernHttpClient;
using Newtonsoft.Json;

namespace FoodServicesOfAmerica.Domain
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ICache _cache;
        public static string Uri = "ProductCatalog";
        private const string CatalogCacheKey = "Catalog";

        public CatalogRepository(ICache cache)
        {
            _cache = cache;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                using (var client = CreateClient())
                {
                    IEnumerable<Category> categories;

                    //if there is no cache or the cache has expired
                    if ((categories = await _cache.GetObject<IEnumerable<Category>>(CatalogCacheKey)) == null)
                    {
                        var response = await client.GetAsync("Categories?type=idfa");
						//read out the cache control max-age

						var maxAge = response.Headers.CacheControl.MaxAge;

                        //convert to json
                        var jsonContent = await response.Content.ReadAsStringAsync();
                        categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonContent);
                        
                        //dont cache if there isn't any maxAge set
						if (!maxAge.HasValue) return categories;

						var expirationDate = DateTime.Now.Add(maxAge.Value);
                        await _cache.InsertObject(CatalogCacheKey, categories, expirationDate);
                    }

                    return categories;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
				throw;
            }

            return null;
        }

        /// <summary>
        /// Configure the Http client
        /// </summary>
        /// <param name="client"></param>
        /// 
        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(Constants.RestUrl + Uri + "/")
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
