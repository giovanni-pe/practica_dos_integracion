namespace Practica.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }
        public int WeeklyHours { get; set; }
        public int Cycle { get; set; }

        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
