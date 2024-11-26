using System.ComponentModel.DataAnnotations;

namespace HospitalManagementServer.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public List<Patient> Patients { get; set; } = new();
    }
}
