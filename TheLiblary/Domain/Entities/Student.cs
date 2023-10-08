namespace TheLiblary.Domain.Entities;

public class Student
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime DayOfBirth { get; set; }
    public string? Password { get; set; }
    public string? Salt { get; set; }
    public DateTime CreateAt { get; set; } = TimeHelper.GetDateTime();
    public DateTime UpdateAt { get; set; } = TimeHelper.GetDateTime();
}
