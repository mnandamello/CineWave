using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineWave.Models
{
    [Table("T_CNWV_USUARIO")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome_Usuario")]
        public string UserName { get; set; }

        [Required]
        [Column("Email_Usuario")]
        public string UserEmail { get; set; }

        [Required]
        [Column("Hash_Senha")]
        public string PassWordHash { get; set; }

        public ICollection<Campanha>? Campanhas { get; set; }

    }
}
