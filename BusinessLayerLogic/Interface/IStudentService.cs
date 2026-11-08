
using BusinessLayerLogic.DTOs;

namespace BusinessLayerLogic.Interface
{
    public interface IStudentService
    {
        List<StudentDto> GetAll();
        StudentDto? GetById(int id);
        StudentDto Create(StudentCreateDto student);
        StudentDto? Update(int id, StudentUpdateDto student);
        StudentDto? Delete(int id);

        StudentWithPredmetiDto? GetWithPredmeti(int id);

    }
}
