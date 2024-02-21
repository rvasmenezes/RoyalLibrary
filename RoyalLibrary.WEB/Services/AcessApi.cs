namespace RoyalLibrary.WEB.Services
{
    public class AcessApi
    {
        static async Task<T> GetApiData<T>(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<T>();
                else
                {
                    Console.WriteLine($"Erro na solicitação: {response.StatusCode}");
                    return default;
                }
            }
        }
    }
}
