using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaginaWeb.Models;

namespace PaginaWeb.Services
{
    public class WorkerService : ApiService
    {
        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            return await GetAsync<List<Worker>>("workers");
        }

        public async Task<Worker> GetWorkerAsync(long id)
        {
            return await GetAsync<Worker>($"workers/{id}");
        }

        public async Task<Worker> CreateWorkerAsync(Worker worker)
        {
            return await PostAsync<Worker>("workers", worker);
        }

        public async Task UpdateWorkerAsync(long id, Worker worker)
        {
            await PutAsync<object>($"workers/{id}", worker);
        }

        public async Task DeleteWorkerAsync(long id)
        {
            await DeleteAsync($"workers/{id}");
        }

        public async Task<Worker> LoginAsync(string email, string password)
        {
            try
            {
                var loginData = new { Email = email, Password = password };
                System.Diagnostics.Debug.WriteLine($"Intentando login para trabajador: {email}");
                var response = await PostAsync<Worker>("workers/login", loginData);
                System.Diagnostics.Debug.WriteLine($"Respuesta de login de trabajador: {response != null}");
                return response;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en WorkerService.LoginAsync: {ex.Message}");
                throw;
            }
        }
    }
}





