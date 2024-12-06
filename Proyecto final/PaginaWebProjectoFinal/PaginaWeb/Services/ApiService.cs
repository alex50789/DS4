using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PaginaWeb.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:44385/api/"; // URL de la API

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                var fullUrl = $"{_baseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
                System.Diagnostics.Debug.WriteLine($"GET request a {fullUrl}");
                var response = await _httpClient.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"GET response de {fullUrl}: {content}");
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GET {endpoint}: {ex.Message}");
                throw;
            }
        }

        protected async Task<T> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var fullUrl = $"{_baseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
                System.Diagnostics.Debug.WriteLine($"POST request a {fullUrl} con datos: {json}");
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(fullUrl, content);
                System.Diagnostics.Debug.WriteLine($"Status code: {response.StatusCode}");

                var responseContent = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"Response content: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                {
                    throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}. Detalles: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in PostAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<T> PutAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var fullUrl = $"{_baseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
                System.Diagnostics.Debug.WriteLine($"PUT request a {fullUrl} con datos: {json}");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(fullUrl, content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"PUT response de {fullUrl}: {responseContent}");
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en PUT {endpoint}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string endpoint)
        {
            try
            {
                var fullUrl = $"{_baseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
                System.Diagnostics.Debug.WriteLine($"DELETE request a {fullUrl}");
                var response = await _httpClient.DeleteAsync(fullUrl);
                response.EnsureSuccessStatusCode();
                System.Diagnostics.Debug.WriteLine($"DELETE response de {fullUrl}: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en DELETE {endpoint}: {ex.Message}");
                throw;
            }
        }
    }
}

