using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using CloudFlareUtilities;

namespace HReader.Base
{
    public static class Utilities
    {
        static Utilities()
        {
            var cloudflare = new ClearanceHandler(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                UseCookies = true,
                CookieContainer = new CookieContainer(),
                MaxAutomaticRedirections = 5,
            });
            Client = new HttpClient(cloudflare);
            Client.DefaultRequestHeaders.TryAddWithoutValidation(
                "User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36");
        }

        internal static void Dispose()
        {
            Client.CancelPendingRequests();
            Client.Dispose();
        }

        private static readonly HttpClient Client;

        private static async Task<T> LoadFromHttpAsync<T>(Uri uri, string expectedContent, Func<Stream, Task<T>> handleResponse)
        {
            if (!(uri.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase)
                  || uri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Scheme '{uri.Scheme}' is not http compatible.", nameof(uri));
            }
            
            using (var response = await Client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead))
            {
                if ((response.StatusCode == HttpStatusCode.OK ||
                     response.StatusCode == HttpStatusCode.Moved ||
                     response.StatusCode == HttpStatusCode.Redirect) &&
                     response.Content.Headers.ContentType.Parameters.Any(h => h.Value.IndexOf(expectedContent, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    return await handleResponse(await response.Content.ReadAsStreamAsync());
                }
                throw new ArgumentException($"Content Type '{response.Content.Headers.ContentType.MediaType}' does not match expected '{expectedContent}'", nameof(uri));
            }
        }

        public static async Task<IHtmlDocument> GetHtmlAsync(Uri uri)
        {
            return await LoadFromHttpAsync(uri, "text/html", async stream =>
            {
                var parser = new HtmlParser(new HtmlParserOptions
                {
                    IsScripting = false,
                    IsStrictMode = false,
                    IsEmbedded = false,
                });

                return await parser.ParseAsync(stream);
            });
        }

        public static async Task ConsumeImageAsync(Uri uri, Func<Stream, Task> consumer)
        {
            await LoadFromHttpAsync(uri, "image", async stream =>
            {
                await consumer(stream);
                return true;
            });
        }
    }
}
