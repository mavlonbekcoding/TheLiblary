using Newtonsoft.Json;
using System.Net;
using TheLiblary.Data.Constants;
using TheLiblary.Domain.Entities;
using TheLiblary.Service.Helpers;
using TheLiblary.Service.Interfaces;

namespace TheLiblaryAPI.Service.Services
{
    public class BookService : IBookService
    {
        public BookService()
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);

            if (string.IsNullOrEmpty(source))
                File.WriteAllText(FilePath.BOOK_PATH, "[]");
            else
            {
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

                DateTime currentTime = DateTime.UtcNow;
                currentTime = currentTime.AddHours(TimeConstants.UTC);

                for (int i = 0; i < books.Count; i++)
                {
                    if ((currentTime - books[i].RentAt).Days >= 30)
                    {
                        books[i].StudentId = null;
                    }
                }

                source = JsonConvert.SerializeObject(books, Formatting.Indented);
                File.WriteAllText(FilePath.BOOK_PATH, source);
            }
        }
        public bool CancellationOfRent(long Id, long studentId)
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            Book book = books.FirstOrDefault(x => x.Id == Id && x.StudentId == studentId);

            if (book is null)
                return false;

            book.StudentId = null;

            source = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(FilePath.BOOK_PATH, source);

            return true;
        }

        public Book Create(Book book)
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            string bookId = File.ReadAllText(FilePath.BOOK_ID_IDENTITY_PATH);

            if (string.IsNullOrEmpty(bookId))
                bookId = "1";

            book.Id = long.Parse(bookId);

            books.Add(book);
            source = JsonConvert.SerializeObject(books, Formatting.Indented);

            File.WriteAllText(FilePath.BOOK_PATH, source);
            File.WriteAllText(FilePath.BOOK_ID_IDENTITY_PATH, $"{book.Id + 1}");

            return book;
        }

        public bool Delete(long Id)
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            Book existBook = books.FirstOrDefault(s => s.Id == Id);

            if (existBook is null)
                return false;

            books.Remove(existBook);

            source = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(FilePath.BOOK_PATH, source);

            return true;
        }

        public IEnumerable<Book> GetAll()
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            return books;
        }

        public Book GetById(long Id)
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            Book existBook = books.FirstOrDefault(s => s.Id == Id);

            if (existBook is null)
                return null;

            return existBook;
        }

        public IEnumerable<Book> GetByStudentIdAndBookId(long studentId)
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            List<Book> result = books.Where(b => b.StudentId == studentId).ToList();

            if (result.Count == 0)
                return null;

            return result;
        }

        public bool RentTextbooks(long Id, long studentId)
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            Book book = books.FirstOrDefault(b => b.Id == Id);

            if (book.StudentId is not null)
                return false;

            book.StudentId = studentId;
            book.RentAt = DateTime.UtcNow.AddHours(TimeConstants.UTC);

            source = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(FilePath.BOOK_PATH, source);

            return true;
        }

        public Book Update(Book book)
        {
            string source = File.ReadAllText(FilePath.BOOK_PATH);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(source);

            Book existbook = books.FirstOrDefault(s => s.Id == book.Id);

            if (existbook is null)
                return existbook;

            existbook.Name = book.Name;
            existbook.Description = book.Description;
            existbook.Author = book.Author;
            existbook.StudentId = book.StudentId;
            existbook.Genre = book.Genre;
            existbook.RentAt = book.RentAt;

            string json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(FilePath.BOOK_PATH, json);

            return book;
        }
    }
}
