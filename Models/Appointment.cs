using System.ComponentModel.DataAnnotations;

namespace HospitalMVCProject.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Time is required")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? PatientName { get; set; } 

        [Required(ErrorMessage = "Email is required")]
        public string? PatientEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PatientPhone { get; set; } = null!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
    }
}
