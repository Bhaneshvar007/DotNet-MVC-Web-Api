using Microsoft.AspNetCore.Mvc;
using webProjectWithMvc.Models;

namespace webProjectWithMvc.Interface
{
    public interface IStudent
    {
        Task<IActionResult> InsertStudentAsynce(Student student);
        Task<List<Student>> GetStudentAsynce();
        Task<Student> GetStudentByIdAsync(int id);
        Task<string> DeleteStudentAsync(int id);

        Task<string> UpdateStudentAsync(Student student);


    }
}
