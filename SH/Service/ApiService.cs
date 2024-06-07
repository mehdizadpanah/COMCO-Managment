using SH.Data.ViewModel;
using System.Net.Http.Json;

namespace SH.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> PostValuesAsync(string controllerName,object data)
        {
            try
            {
                var controller = new UriBuilder("http", GlobalSettings.ApiAddress, GlobalSettings.ApiPort, controllerName).ToString();
                var response = await _httpClient.PostAsJsonAsync(controller, data);
             //   response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
