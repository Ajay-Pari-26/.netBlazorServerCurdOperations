using HospitalManagementServer.Data;
using HospitalManagementServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementServer.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;
        private readonly IDoctorService _doctorService;

        public PatientService(AppDbContext context, IDoctorService doctorService)
        {
            _context = context;
            _doctorService = doctorService;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            var result = await _context.Patients.ToListAsync();
            return result;
            }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return patient;
        }

        //public async Task AddPatientAsync(Patient patient)
        //{
        //    _context.Patients.Add(patient);
        //    await _context.SaveChangesAsync();
        //}
        public async Task AddPatientAsync(Patient patient)
        {
            if (patient.DoctorId == 0 || !await _doctorService.DoesDoctorExist(patient.DoctorId))
            {
                throw new Exception("Invalid DoctorId. Please select a valid doctor.");
            }

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }


        //public async Task UpdatePatientAsync(Patient patient, int id)
        //{
        //    var dbPatient = await _context.Patients.FindAsync(id);
        //    if (dbPatient != null)
        //    {
        //        dbPatient.Name = patient.Name;
        //        dbPatient.Age = patient.Age;
        //        dbPatient.Diagnosis = patient.Diagnosis;
        //        dbPatient.DoctorId = patient.DoctorId;
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task UpdatePatientAsync(Patient patient, int id)
        {
            var dbPatient = await _context.Patients.FindAsync(id);
            if (dbPatient == null)
            {
                throw new Exception("Patient not found.");
            }

            if (patient.DoctorId == 0 || !await _doctorService.DoesDoctorExist(patient.DoctorId))
            {
                throw new Exception("Invalid DoctorId. Please select a valid doctor.");
            }

            dbPatient.Name = patient.Name;
            dbPatient.Age = patient.Age;
            dbPatient.Diagnosis = patient.Diagnosis;
            dbPatient.DoctorId = patient.DoctorId;

            await _context.SaveChangesAsync();
        }


        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
