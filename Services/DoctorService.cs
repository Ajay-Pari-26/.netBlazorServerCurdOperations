using HospitalManagementServer.Data;
using HospitalManagementServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementServer.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            var result = await _context.Doctors.ToListAsync();
            return result;
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            return doctor;
        }

        

        public async Task UpdateDoctorAsync(Doctor doctor, int id)
        {
            var dbDoctor = await _context.Doctors.FindAsync(id);
            if (dbDoctor != null)
            {
                dbDoctor.Name = doctor.Name;
                dbDoctor.Specialty = doctor.Specialty;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DoesDoctorExist(int doctorId)
        {
            return await _context.Doctors.AnyAsync(d => d.DoctorId == doctorId);
        }



    }
}
