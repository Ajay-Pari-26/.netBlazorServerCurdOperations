using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementServer.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Diagnosis { get; set; }

        // Foreign key
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
