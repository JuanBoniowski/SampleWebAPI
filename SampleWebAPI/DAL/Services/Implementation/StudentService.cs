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
        public async Task<Student> Create(Student student)
        {                   
            await _repo.Insert(student);
            return student; 
        }
        public async Task<Student> GetById(int id)
        {
            IQueryable<Student> query = await _repo.Consult(i=>i.Id==id);
            return await query.FirstOrDefaultAsync();
            
        }
        public async Task<Student> Update(Student student)
        {
            Student studentEditing = await GetById(student.Id);

            if (studentEditing == null) {

                return null; 
            }

            studentEditing.Name = student.Name;
            studentEditing.Age = student.Age;

            await _repo.Update(studentEditing); 

            return studentEditing;
        }
        public async Task<Student> Delete(int id)
        {
            Student student =await GetById(id); 
            if (student == null)
            {
                return null; 
            }
            await _repo.Delete(student);
            return null; 
        }




    }
}
