namespace HospitalMVCProject.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool Available { get; set; }
        public int SpecialtyId { get; set; }
        public int Traffic { get; set; }
        public Specialty Specialty { get; set; } = null!;

        public virtual ICollection<Appointment> PatientAppointments { get; set; } = new List<Appointment>();
    }
}
