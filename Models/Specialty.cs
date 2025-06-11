namespace HospitalMVCProject.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Status { get; set; }

        public ICollection<Doctor> Doctors = new List<Doctor>();
    }
}
