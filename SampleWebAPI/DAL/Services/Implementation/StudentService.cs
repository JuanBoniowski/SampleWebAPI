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

        public List<Student> List()
        {
            List<Student> listOfStudents = _context.Students.ToList();
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
            studentEditing.Name = student.Name;
            studentEditing.Age = student.Age;

            _repo.Update(studentEditing); 

            return studentEditing;
        }
        public Student Delete(int id)
        {
            Student student = GetById(id); 
            _repo.Delete(student);
            return null; 
        }




    }
}
