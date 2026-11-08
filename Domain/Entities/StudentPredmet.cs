using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentPredmet
    {
        public int StudentID { get; set; }
        public Student? Student { get; set; }    

        public int PredmetID { get; set; }

        public Predmet? Predmet { get; set; }

    }
}
