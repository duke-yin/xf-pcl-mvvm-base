using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BaseSolution.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using ModernHttpClient;
using Plugin.Connectivity.Abstractions;
using PortableRest;

namespace BaseSolution.Domain
{
    public class BaseRepository : RestClient
    {

        protected IConnectivity Connectivity;
        protected IApplicationService _applicationService;
        protected bool IsAnonymous { get; set; } = false;

        public BaseRepository()
        {
            Connectivity = ServiceLocator.Current.GetInstance<IConnectivity>();
            _applicationService = ServiceLocator.Current.GetInstance<IApplicationService>();

            //set the modernhttpclient handler
            this.HttpHandler = new MyHandler(this);
        }

        public class MyHandler : NativeMessageHandler
        {
            BaseRepository _repo;

            public MyHandler(BaseRepository repo)
            {
                _repo = repo;
            }

            protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                _repo.SetHeaders(request);

                HttpResponseMessage result;

                DateTime requestStart = DateTime.UtcNow;

                Debug.WriteLine($"Request: {request.RequestUri} {request.Method.Method})");

                result = await base.SendAsync(request, cancellationToken);

                return result;
            }
        }

        protected void SetHeaders(HttpRequestMessage request)
        {

        }

        public async Task<RestResponse<T>> SendRequestAsync<T>(RestRequest request) where T : class
        {
            // Set global request headers
            SetRequestHeaders(request);

            SetUserAgent<T>("BaseSolution");

            RestResponse<T> response = null;

            // Create a timeout CancellationTokenSource that will be cancelled after 30 seconds
            var timeoutTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 60));

            string requestedUri = string.Empty;

            try
            {
                //only do a call if there is a connection
                if (Connectivity.IsConnected)
                {

                    // Send the request
                    response = await SendAsync<T>(request, timeoutTokenSource.Token);
                    try
                    {
                        requestedUri = response.HttpResponseMessage.RequestMessage.RequestUri.ToString();
                    }
                    catch (Exception ex)
                    {
                        if (response != null && response.HttpResponseMessage != null)
                        {
                            var result = response.HttpResponseMessage;
                            Debug.WriteLine($"Response: {result.StatusCode}: {result.ReasonPhrase}");
                        }
                        else
                        {
                            Debug.WriteLine($"ERROR logging Requested URI and Response in SendRequestAsync()\n{ex}");
                        }
                    }
                }
                else
                {
                    return response;
                }

            }
            catch (OperationCanceledException)
            {
                // Handle situation where timeout CancellationTokenSource token cancellation throws an exception
                ErrorHandling(WellKnown.FriendlyApiError404, requestedUri);
            }

            // Check if the timeout CancellationTokenSource token was cancelled
            if (timeoutTokenSource.Token.IsCancellationRequested)
            {
                ErrorHandling(WellKnown.FriendlyApiErrorTimeout, requestedUri);
            }

            // Check for 500 Internal Server Error or 503 Service Unavailable
            else if (response.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError ||
                response.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
            {
                ErrorHandling(WellKnown.FriendlyApiError50X, requestedUri);
            }

            // Check for 404 Not Found
            else if (response.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ErrorHandling(WellKnown.FriendlyApiError404, requestedUri);
            }

            // Check for 401 Unauthorized
            else if (response.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ErrorHandling(WellKnown.FriendlyApiError401, requestedUri);
            }

            // Check for 400 Bad Request
            else if (response.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ErrorHandling(WellKnown.FriendlyApiError400, requestedUri);
            }

            // Check for other errors (status codes other than 200/201/202)
            else if (response.HttpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK &&
                response.HttpResponseMessage.StatusCode != System.Net.HttpStatusCode.Created &&
                response.HttpResponseMessage.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                ErrorHandling(WellKnown.FriendlyApiErrorOther, requestedUri);
            }

            return response;
        }

        private void ErrorHandling(string ex, string url = null)
        {

        }

        private void SetRequestHeaders(RestRequest request)
        {
            // Remove the Accept/Authorization headers if they're already set
            request.Headers.Remove("Accept");
            request.Headers.Remove("Authorization");

            // Request JSON response content
            request.AddHeader("Accept", "application/json");
            request.ContentType = ContentTypes.Json;

        }
    }
}