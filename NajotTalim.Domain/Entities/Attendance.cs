namespace NajotTalim.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public bool HasParticipated { get; set; }

        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}
