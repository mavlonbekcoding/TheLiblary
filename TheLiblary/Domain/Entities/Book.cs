namespace TheLiblary.Domain.Entities;

public class Book
{
    public long Id { get; set; }
    public long? StudentId { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public DateTime RentAt { get; set; }
    public DateTime CreateAt { get; set; } = TimeHelper.GetDateTime();
    public DateTime UpdateAt { get; set; } = TimeHelper.GetDateTime();
}
