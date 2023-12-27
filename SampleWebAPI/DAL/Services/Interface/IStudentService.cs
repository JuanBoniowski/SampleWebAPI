using SampleWebAPI.Models;

namespace SampleWebAPI.DAL.Services.Interface
{
    public interface IStudentService
    {
        List<Student> List();
        Student Create(Student student);
        Student Update(Student student);
        Student Delete(int id);        
        Student GetById(int id);

    }
}
