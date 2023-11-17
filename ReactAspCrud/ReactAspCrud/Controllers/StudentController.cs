using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        [HttpGet]
        [Route("GetStudents")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Student.ToListAsync();
        }
        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student student)
        {
            _studentDbContext.Student.Add(student);
            await _studentDbContext.SaveChangesAsync();
            return student;
        }
        [HttpPatch]
        [Route("UpdateStudent")]
        public async Task<Student> UpdateStudent(Student student)
        {
            _studentDbContext.Entry(student).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return student;
        }
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<bool> DeleteStudent(int id)
        {
            Student? student = await _studentDbContext.Student.FindAsync(id);
            if (student!=null)
            {
                _studentDbContext.Entry(student).State= EntityState.Deleted;
                await _studentDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
