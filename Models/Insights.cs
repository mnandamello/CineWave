using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWave.Models
{
    [Table("T_CNWV_INSIGHTS")]
    public class Insights
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario? Usuario { get; set; }

        [Required]
        [Column("Titulo_Filme")]
        public string MovieTitle { get; set; }

        [Required]
        [Column("Previsao_De_Roi")]
        public int RoiForecast { get; set; }

        [Required]
        [Column("Canal_De_Marketing")]
        public string MarketingChannel { get; set; }

        [Required]
        [Column("Custo_Medio_Click")]
        public float AverageCostPerClick { get; set; }

        [Required]
        [Column("Previsao_De_Conversao")]
        public int  ConversionPrediction { get; set; }

    }
}
