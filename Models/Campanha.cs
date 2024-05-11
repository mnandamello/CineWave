using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWave.Models
{
    [Table("T_CNWV_CAMPANHA")]
    public class Campanha
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }

        [Required]
        [Column("Titulo_Filme")]
        public string MovieTitle { get; set; }

        [Required]
        [Column("Genero_Filme")]
        public string GenderMovie { get; set; }

        [Required]
        [Column("Faxa_Etaria")]
        public string AgeRange { get; set; }

        [Required]
        [Column("Budget")]
        public float Budget { get; set; }

        [Required]
        [Column("Expectativa_De_Alcance")]
        public int ReachExpectations { get; set; }


    }
}
