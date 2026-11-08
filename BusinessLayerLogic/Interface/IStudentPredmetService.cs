using BusinessLayerLogic.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Interface
{
    public interface IStudentPredmetService
    {
        List<StudentPredmetDto> GetAll();

        StudentPredmetDto? GetByID(int studentID, int predmetID);

        StudentPredmetDto Create(StudentPredmetCreateDto sp);

        StudentPredmetDto? Delete(int studentID, int predmetID);
    }
}
