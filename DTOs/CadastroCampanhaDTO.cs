using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWave.DTOs
{
    public class CadastroCampanhaDTO
    {
        [Required]
        public string MovieTitle { get; set; }

        [Required]
        public string GenderMovie { get; set; }

        [Required]
        public string AgeRange { get; set; }

        [Required]
        public float Budget { get; set; }

        [Required]
        public int ReachExpectations { get; set; }
    }
}
