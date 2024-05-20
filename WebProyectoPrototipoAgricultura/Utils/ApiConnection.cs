using System.Net.Http.Headers;

namespace WebProyectoPrototipoAgricultura.Utils
{
    public static class ApiConnection
    {
        public static HttpClient Initial()
        {
            return new HttpClient
            {
                //BaseAddress = new Uri("https://10.17.25.6:44306/")
                BaseAddress = new Uri("http://localhost:8080/")
            };
        }

        public static HttpClient InitialWithBearerToken(string accessToken)
        {
            HttpClient client = Initial();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return client;
        }
    }
}
