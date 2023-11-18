using System.ComponentModel.DataAnnotations;

namespace NajotTalim.Application.Models
{
    public class CreateTeacherModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
