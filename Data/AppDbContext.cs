using HospitalManagementServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HospitalManagementServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, Name = "Dr. Smith", Specialty = "Cardiology" },
                new Doctor { DoctorId = 2, Name = "Dr. Johnson", Specialty = "Neurology" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, Name = "John Doe", Age = 30, Diagnosis = "Flu", DoctorId = 1 },
                new Patient { PatientId = 2, Name = "Jane Roe", Age = 25, Diagnosis = "Fracture", DoctorId = 2 }
            );
        }

        public DbSet<Doctor> Doctors { get; set; } = default!;
        public DbSet<Patient> Patients { get; set; } = default!;

    }
}
