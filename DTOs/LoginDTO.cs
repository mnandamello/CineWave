using System.ComponentModel.DataAnnotations;

namespace CineWave.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PassWordHash { get; set; }
    }
}
