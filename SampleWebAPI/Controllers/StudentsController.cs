using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.DAL.Context;
using SampleWebAPI.DAL.Implementation;
using SampleWebAPI.DAL.Interface;
using SampleWebAPI.DAL.Services.Implementation;
using SampleWebAPI.DAL.Services.Interface;
using SampleWebAPI.Models;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IGenericRepository<Student> _repo; 
        private readonly IStudentService _studentService; 

        public StudentsController(StudentContext context)
        {
            _context = context;
            _repo = new GenericRepsoitory<Student>(context);
            _studentService = new StudentService(_repo, context); 
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
          if (_context.Students == null)
          {
              return NotFound();
          }
            return _studentService.List(); 
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_context.Students == null)
          {
              return Problem("Entity set 'StudentContext.Students'  is null.");
          }

            _studentService.Create(student); 

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }
        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
          if (_context.Students == null)
          {
              return NotFound();
          }

            var student = _studentService.GetById(id); 

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }         

            _repo.Update(student);

            return NoContent();
        }


        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            //var student = await _context.Students.FindAsync(id);
            //if (student == null)
            //{
            //    return NotFound();
            //}
            _studentService.Delete(id); 
            //_context.Students.Remove(student);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
