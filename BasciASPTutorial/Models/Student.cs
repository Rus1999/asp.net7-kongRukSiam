using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasciASPTutorial.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter your name.")]
        [DisplayName("ชื่อนักเรียน")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter your score")]
        [DisplayName("คะแนน")]
        [Range(0, 100, ErrorMessage = "Score out of bound")]
        public int Score { get; set; }
    }
}
