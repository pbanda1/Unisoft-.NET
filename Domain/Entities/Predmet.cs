using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Predmet : BaseEntity
    {

        public string Naziv { get; set; } = string.Empty;

        public ICollection<StudentPredmet>? StudentPredmeti { get; set; }

    }
}
