using System.Net.Http;

namespace ShopTemplateAPI.Controllers.FrequentlyUsed
{
    /// <summary>
    /// Во множестве статей указывалось что если создавать множество новых HttpClient то можно исчерпать количество сокетов
    /// </summary>
    public class HttpClientSingleton
    {
        private static object lockObj = new object(); //Избегаем проблем от параллельных вызовов

        private static HttpClient httpClient;
        public static HttpClient HttpClient 
        {
            get 
            {
                lock (lockObj)
                {
                    if (httpClient == null)
                    {
                        httpClient = new HttpClient();
                    }
                }
                return httpClient;
            }
        }
    }
}
