using TheLiblary.Domain.Entities;
using TheLiblary.Service.Helpers;

namespace TheLiblary.Service.Interfaces
{
    public interface IBookService
    {
        Book Create(Book book);
        Book Update(Book book);
        bool Delete(long Id);
        IEnumerable<Book> GetByStudentIdAndBookId(long studentId);
        IEnumerable<Book> GetAll();
        bool CancellationOfRent(long Id, long studentId);
        Book GetById(long Id);
        bool RentTextbooks(long Id, long studentId);
    }
}
