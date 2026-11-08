using System.ComponentModel.DataAnnotations;

namespace BusinessLayerLogic.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class StudentUpdateDto {

        [Required]// runtime validacija
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty; // ? u compile timeu

    }

    public class StudentCreateDto {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
    }

    public class StudentWithPredmetiDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PredmetDto> Predmeti { get; set; } = new(); 
    }
}
