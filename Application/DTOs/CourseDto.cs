namespace Practica.Application.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }
        public int WeeklyHours { get; set; }
        public int Cycle { get; set; }
        public int TeacherId { get; set; }

        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
        public string? TeacherEmail { get; set; }
    }
}
