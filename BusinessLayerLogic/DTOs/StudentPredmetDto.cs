
using System.ComponentModel.DataAnnotations;

namespace BusinessLayerLogic.DTOs
{
    public class StudentPredmetDto
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;

        public int PredmetID { get; set; }

        public string PredmetNaziv { get; set; } = string.Empty;

    }

    public class StudentPredmetCreateDto
    {
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int PredmetID { get; set; }  
    }
}
