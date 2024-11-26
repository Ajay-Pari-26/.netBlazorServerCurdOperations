using HospitalManagementServer.Models;

namespace HospitalManagementServer.Services
{
    public interface IDoctorService
    {
        
            Task<List<Doctor>> GetAllDoctorsAsync();
            Task<Doctor> GetDoctorByIdAsync(int id);
            Task AddDoctorAsync(Doctor doctor);
            Task UpdateDoctorAsync(Doctor doctor, int id);
            Task DeleteDoctorAsync(int id);
        Task<bool> DoesDoctorExist(int doctorId);
    }
}
