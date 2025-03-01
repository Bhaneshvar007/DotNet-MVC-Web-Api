using Crud_OperationOnStudentData.Models;

namespace Crud_OperationOnStudentData.Interface
{
    public interface IStudent
    {
        Task<List<Student>> GetStudentAsync();
    }
}
