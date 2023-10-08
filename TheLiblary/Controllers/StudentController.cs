using Microsoft.AspNetCore.Mvc;
using TheLiblary.Domain.Entities;
using TheLiblaryAPI.Service.Interfaces;

namespace TheLiblary.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost("create")]
    public Student Create([FromBody] Student student)
    {
        return _studentService.Create(student);
    }

    [HttpDelete("delete/{id}")]
    public bool Delete(long id)
    {
        return _studentService.Delete(id);
    }

    [HttpGet("getall")]
    public IEnumerable<Student> GetAll()
    {
        return _studentService.GetAll();
    }

    [HttpGet("getbyemail")]
    public Student GetByEmail([FromQuery] string email)
    {
        return _studentService.GetByEmail(email);
    }

    [HttpGet("getbyid/{id}")]
    public Student GetById(long Id)
    {
        return _studentService.GetById(Id);
    }

    [HttpPut("update")]
    public Student Update([FromBody] Student student)
    {
        return _studentService.Update(student);
    }
}
