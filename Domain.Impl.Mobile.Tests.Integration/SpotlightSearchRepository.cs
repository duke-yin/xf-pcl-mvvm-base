using System;
using System.Threading;
using System.Threading.Tasks;
using FoodServicesOfAmerica.Domain;
using PortableRest;

namespace Domain.Impl.Mobile.Tests.Integration
{
	public class SpotlightSearchRepository : BaseRepository, ISpotlightSearchRepository
	{
		private readonly ICache _cache;
		public static string Uri = "Search";
		private const string SearchCacheKey = "SpotlightSearch";

		private CancellationTokenSource throttleCts = new CancellationTokenSource();

		public SpotlightSearchRepository(ICache cache)
		{
			_cache = cache;

			BaseUrl = Constants.FSASearchBaseUrl;
		}

		public async Task<SearchResult> SearchAsync(string searchString)
		{
		 	SearchResult searchResult;



			//if there is no cache or the cache has expired
			if ((searchResult = await _cache.GetObject<SearchResult>(SearchCacheKey + searchString)) == null)
			{
				var request = new RestRequest(Uri);

				TimeSpan? maxAge = null;

				request.AddQueryString("searchValue", searchString);

				Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();
				await Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token) // throttle time
					.ContinueWith(
						async delegate {

							var response = await SendRequestAsync<SearchResult>(request);

							//read out the cache control max-age
							maxAge = response.HttpResponseMessage.Headers.CacheControl?.MaxAge;

							//get the categories
							searchResult = response.Content;

						},
						CancellationToken.None,
						TaskContinuationOptions.OnlyOnRanToCompletion,
						TaskScheduler.FromCurrentSynchronizationContext());
				


				//dont cache if there isn't any maxAge set
				if (maxAge == null) return searchResult;

				var expirationDate = DateTime.Now.Add(maxAge.Value);
				await _cache.InsertObject(SearchCacheKey, searchResult, expirationDate);
			}

			return searchResult;
		}
	}
}

