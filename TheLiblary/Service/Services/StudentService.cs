using Newtonsoft.Json;
using TheLiblary.Data.Constants;
using TheLiblary.Domain.Entities;
using TheLiblary.Service.Helpers;
using TheLiblaryAPI.Service.Interfaces;

namespace TheLiblaryAPI.Service.Services
{
    public class StudentService : IStudentService
    {
        public StudentService()
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);

            if (string.IsNullOrEmpty(source))
                File.WriteAllText(FilePath.STUDENT_PATH, "[]");
        }
        public Student Create(Student student)
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(source);

            Student existStudent = students.FirstOrDefault(s => s.Email.ToLower() == student.Email.ToLower());

            if (existStudent is not null)
                return null;

            string studentId = File.ReadAllText(FilePath.STUDENT_ID_IDENTITY_PATH);

            if (string.IsNullOrEmpty(studentId))
                studentId = "1";

            student.Id = long.Parse(studentId);

            students.Add(student);
            source = JsonConvert.SerializeObject(students, Formatting.Indented);

            File.WriteAllText(FilePath.STUDENT_PATH, source);
            File.WriteAllText(FilePath.STUDENT_ID_IDENTITY_PATH, $"{student.Id + 1}");

            return student;
        }

        public bool Delete(long Id)
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(source);

            Student existStudent = students.FirstOrDefault(s => s.Id == Id);

            if (existStudent is null)
                return false;

            students.Remove(existStudent);

            source = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(FilePath.STUDENT_PATH, source);

            return true;
        }

        public IEnumerable<Student> GetAll()
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(source);

            return students;
        }

        public Student GetByEmail(string email)
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(source);

            Student existStudent = students.FirstOrDefault(s => s.Email.ToLower() == email.ToLower());

            if (existStudent is null)
                return null;

            return existStudent;
        }

        public Student GetById(long Id)
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(source);

            Student existStudent = students.FirstOrDefault(s => s.Id == Id);

            if (existStudent is null)
                return null;

            return existStudent;
        }

        public Student Update(Student student)
        {
            string source = File.ReadAllText(FilePath.STUDENT_PATH);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(source);

            Student existSudent = students.FirstOrDefault(s => s.Id == student.Id);

            if (existSudent is null)
                return existSudent;

            existSudent.FirstName = student.FirstName;
            existSudent.LastName = student.LastName;
            existSudent.Email = student.Email;
            existSudent.DayOfBirth = student.DayOfBirth;
            existSudent.Password = student.Password;
            existSudent.Salt = student.Salt;
            existSudent.UpdateAt = TimeHelper.GetDateTime();

            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(FilePath.STUDENT_PATH, json);

            return student;
        }
    }
}
