using PaginaWeb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaginaWeb.Services
{
    public class NoticeService : ApiService
    {
        public async Task<List<Notice>> GetAllNoticesAsync()
        {
            return await GetAsync<List<Notice>>("notices");
        }

        public async Task<Notice> CreateNoticeAsync(Notice notice)
        {
            return await PostAsync<Notice>("notices", notice);
        }

        public async Task UpdateNoticeAsync(long id, Notice notice)
        {
            await PutAsync<Notice>($"notices/{id}", notice);
        }

        public async Task DeleteNoticeAsync(long id)
        {
            await DeleteAsync($"notices/{id}");
        }

        public async Task CreateAppointmentNoticeAsync(string clientName, DateTime appointmentDate, long workerId)
        {
            var notice = new Notice
            {
                Title = "Nueva cita",
                Content = $"Tiene una cita con {clientName} el día {appointmentDate:dd/MM/yyyy HH:mm}",
                IsActive = true,
                UserId = workerId,
                Type = "NewAppointment"
            };
            await CreateNoticeAsync(notice);
        }

        public async Task CreateCancellationNoticeAsync(string clientName, string reason, long workerId)
        {
            var notice = new Notice
            {
                Title = "Cancelación de cita",
                Content = $"El cliente {clientName} ha cancelado su cita. Motivo: {reason}",
                IsActive = true,
                UserId = workerId,
                Type = "Cancellation"
            };
            await CreateNoticeAsync(notice);
        }

        public async Task CreateStatusUpdateNoticeAsync(string clientName, string newStatus, long workerId)
        {
            var notice = new Notice
            {
                Title = "Actualización de estado de cita",
                Content = $"El estado de tu cita con {clientName} ha sido actualizado a {newStatus}.",
                IsActive = true,
                UserId = workerId,
                Type = "StatusUpdate"
            };
            await CreateNoticeAsync(notice);
        }
    }
}



