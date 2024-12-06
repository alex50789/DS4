using System.Collections.Generic;
using System.Threading.Tasks;
using PaginaWeb.Models;

namespace PaginaWeb.Services
{
    public class ServiceService : ApiService
    {
        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await GetAsync<List<Service>>("services");
        }

        public async Task<Service> GetServiceAsync(long id)
        {
            return await GetAsync<Service>($"services/{id}");
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            return await PostAsync<Service>("services", service);
        }

        public async Task UpdateServiceAsync(long id, Service service)
        {
            await PutAsync<object>($"services/{id}", service);
        }

        public async Task DeleteServiceAsync(long id)
        {
            await DeleteAsync($"services/{id}");
        }
    }

}