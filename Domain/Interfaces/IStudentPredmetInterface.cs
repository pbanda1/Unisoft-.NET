using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentPredmetInterface
    {
        List<StudentPredmet> GetAll();

        StudentPredmet? GetByID(int studentId, int predmetId);

        StudentPredmet Create(StudentPredmet sp);

        StudentPredmet? Delete(int studentId, int predmetId);

    }
}
