using SampleWebAPI.Models;

namespace SampleWebAPI.DAL.Services.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> List();
        Task<Student> Create(Student student);
        Task<Student> Update(Student student);
        Task<Student> Delete(int id);        
        Task<Student> GetById(int id);

    }
}
