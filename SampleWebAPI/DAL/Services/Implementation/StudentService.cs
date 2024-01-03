using Microsoft.EntityFrameworkCore;
using SampleWebAPI.DAL.Context;
using SampleWebAPI.DAL.Interface;
using SampleWebAPI.DAL.Services.Interface;
using SampleWebAPI.Models;

namespace SampleWebAPI.DAL.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _repo;
        private readonly StudentContext _context; 

        public StudentService(IGenericRepository<Student> repo, StudentContext context)
        {
            _repo = repo;
            _context = context; 
        }

        public async Task<List<Student>> List()
        {
            List<Student> listOfStudents =await  _context.Students.ToListAsync();
            return listOfStudents; 
        }
        public Student Create(Student student)
        {
            _repo.Insert(student);
            return student; 
        }
        public Student GetById(int id)
        {
            IQueryable<Student> query = _repo.Consult(i=>i.Id==id);
            return query.FirstOrDefault();
            
        }
        public Student Update(Student student)
        {
            Student studentEditing = GetById(student.Id);

            if (studentEditing == null) {

                return null; 
            }

            studentEditing.Name = student.Name;
            studentEditing.Age = student.Age;

            _repo.Update(studentEditing); 

            return studentEditing;
        }
        public Student Delete(int id)
        {
            Student student = GetById(id); 
            if (student == null)
            {
                return null; 
            }
            _repo.Delete(student);
            return null; 
        }




    }
}
