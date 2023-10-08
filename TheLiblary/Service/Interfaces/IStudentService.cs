using TheLiblary.Domain.Entities;
using TheLiblary.Service.Helpers;

namespace TheLiblaryAPI.Service.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(Student student);
        bool Delete(long Id);
        Student GetByEmail(string email);
        Student GetById(long Id);
        IEnumerable<Student> GetAll();
    }
}
