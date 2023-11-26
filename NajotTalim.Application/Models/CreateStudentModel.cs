using System.ComponentModel.DataAnnotations;

namespace NajotTalim.Application.Models
{
    public class CreateStudentModel
    {
        [Required]
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
