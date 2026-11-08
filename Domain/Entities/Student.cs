using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {

        public required string Name { get; set; }

        public ICollection<StudentPredmet>? StudentPredmeti { get; set; }
    }
}
