using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaginaWeb.Models;

namespace PaginaWeb.Services
{
    public class AppointmentService : ApiService
    {
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await GetAsync<List<Appointment>>("appointments");
        }

        public async Task<Appointment> GetAppointmentAsync(long id)
        {
            return await GetAsync<Appointment>($"appointments/{id}");
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            return await PostAsync<Appointment>("appointments", appointment);
        }

        public async Task UpdateAppointmentAsync(long id, Appointment appointment)
        {
            await PutAsync<Appointment>($"appointments/{id}", appointment);
        }

        public async Task DeleteAppointmentAsync(long id)
        {
            await DeleteAsync($"appointments/{id}");
        }

        public async Task<List<Appointment>> GetWorkerAppointmentsAsync(long workerId)
        {
            return await GetAsync<List<Appointment>>($"appointments/worker/{workerId}");
        }

        public async Task<List<Appointment>> GetClientAppointmentsAsync(long clientId)
        {
            return await GetAsync<List<Appointment>>($"appointments/client/{clientId}");
        }

        public async Task<bool> IsTimeSlotAvailable(long workerId, DateTime appointmentDate)
        {
            var workerAppointments = await GetWorkerAppointmentsAsync(workerId);
            return !workerAppointments.Any(a =>
                a.AppointmentDate.Date == appointmentDate.Date &&
                a.AppointmentDate.Hour == appointmentDate.Hour &&
                a.AppointmentDate.Minute == appointmentDate.Minute &&
                a.Status != "Cancelada");
        }
    }
}




