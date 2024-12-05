using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;    
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Api_proyecto_final.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext() : base("name=AppointmentContext")
        {
            // Disable initializer
            Database.SetInitializer<AppointmentContext>(null);
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Notice> Notices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove pluralizing table names convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Worker configuration
            modelBuilder.Entity<Worker>()
                .ToTable("workers")
                .HasKey(w => w.Id);

            modelBuilder.Entity<Worker>()
                .Property(w => w.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Worker>()
                .Property(w => w.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Worker>()
                .Property(w => w.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Worker>()
                .Property(w => w.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Worker>()
                .HasIndex(w => w.Email)
                .IsUnique();

            // Client configuration
            modelBuilder.Entity<Client>()
                .ToTable("clients")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .Property(c => c.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Client>()
                .Property(c => c.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Service configuration
            modelBuilder.Entity<Service>()
                .ToTable("services")
                .HasKey(s => s.Id);

            modelBuilder.Entity<Service>()
                .Property(s => s.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Service>()
                .Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);

            // Appointment configuration
            modelBuilder.Entity<Appointment>()
                .ToTable("appointments")
                .HasKey(a => a.Id);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.ClientId)
                .HasColumnName("client_id")
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.WorkerId)
                .HasColumnName("worker_id")
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.ServiceId)
                .HasColumnName("service_id")
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentDate)
                .HasColumnName("appointment_date")
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasColumnName("status")
                .HasMaxLength(50);

            modelBuilder.Entity<Appointment>()
                    .HasRequired(a => a.Client)
                    .WithMany()
                    .HasForeignKey(a => a.ClientId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Worker)
                .WithMany()
                .HasForeignKey(a => a.WorkerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notice>()
                .ToTable("notices");

            modelBuilder.Entity<Notice>()
                .HasKey(n => n.Id);

            modelBuilder.Entity<Notice>()
                .Property(n => n.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Notice>()
                .Property(n => n.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Notice>()
                .Property(n => n.Content)
                .HasColumnName("content")
                .IsRequired();

            modelBuilder.Entity<Notice>()
                .Property(n => n.PublishedDate)
                .HasColumnName("published_date")
                .IsRequired();

            modelBuilder.Entity<Notice>()
                .Property(n => n.IsActive)
                .HasColumnName("is_active")
                .IsRequired();


            base.OnModelCreating(modelBuilder);


        }
    }
}