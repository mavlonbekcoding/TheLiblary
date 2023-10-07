using TheLiblary.Domain.Commons;

namespace TheLiblary.Domain.Entities.Students
{
    public class Student : Auditable
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public DateTime UpdateAt { get; internal set; }
    }
}

