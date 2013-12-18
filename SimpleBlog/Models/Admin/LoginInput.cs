using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models.Admin
{
    public class LoginInput
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}