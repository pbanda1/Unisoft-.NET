using System.ComponentModel.DataAnnotations;

namespace BusinessLayerLogic.DTOs
{
    public class PredmetDto
    {
        public int Id { get; set; } 
        public string Naziv { get; set; } = string.Empty;
    }

    public class PredmetUpdateDto {
        [Required]
        public string Naziv {  get; set; } = string.Empty;
    }

    public class PredmetCreateDto {
        [Required]

        public string Naziv { get; set; } = string.Empty;
    }

    public class PredmetWithStudentiDto
    {

        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;

        public List<StudentDto> Students { get; set; } = new();
    }
}
