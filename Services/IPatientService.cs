﻿using HospitalManagementServer.Models;

namespace HospitalManagementServer.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient?> GetPatientByIdAsync(int id);
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient, int id);
        Task DeletePatientAsync(int id);
    }
}
