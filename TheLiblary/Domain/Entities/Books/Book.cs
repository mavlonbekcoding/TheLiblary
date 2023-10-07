using TheLiblary.Domain.Commons;

namespace TheLiblary.Domain.Entities.Books
{
    public class Book : Auditable
    {
        public long? StudentId { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public DateTime RentAt { get; set; }
    }
}