namespace NajotTalim.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            StudentGroups = new HashSet<StudentGroup>();
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<StudentGroup> StudentGroups { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
