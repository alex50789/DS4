using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaginaWeb.Models;

namespace PaginaWeb.Services
{
    public class ClientService : ApiService
    {
        public async Task<List<Client>> GetAllClientsAsync()
        {
            try
            {
                return await GetAsync<List<Client>>("clients");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetAllClientsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Client> GetClientAsync(long id)
        {
            try
            {
                return await GetAsync<Client>($"clients/{id}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetClientAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            try
            {
                return await PostAsync<Client>("clients", client);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en CreateClientAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateClientAsync(long id, Client client)
        {
            try
            {
                await PutAsync<object>($"clients/{id}", client);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en UpdateClientAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteClientAsync(long id)
        {
            try
            {
                await DeleteAsync($"clients/{id}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en DeleteClientAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Client> LoginAsync(string email, string password)
        {
            try
            {
                var loginData = new
                {
                    Email = email,
                    Password = password,
                    UserType = "Client" // Agregar el tipo de usuario
                };
                System.Diagnostics.Debug.WriteLine($"Intentando login para cliente: {email}");
                var response = await PostAsync<Client>("login", loginData);
                System.Diagnostics.Debug.WriteLine($"Respuesta de login de cliente: {response != null}");
                return response;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en ClientService.LoginAsync: {ex.Message}");
                throw;
            }
        }


    }
}

