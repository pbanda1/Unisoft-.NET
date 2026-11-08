using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository : ICrud<Student>
    {
        Student? GetWithPredmeti(int id); 
    }
}
