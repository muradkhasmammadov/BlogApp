using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserUpdateViewModel
    {
        [Required(ErrorMessage = "Can't be blank.")]
        public string fullName { get; set; }
        
        [Required(ErrorMessage = "Can't be blank.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Can't be blank.")]
        public string Email { get; set; }
        public IFormFile UserImage { get; set; }
        public string Password { get; set; }
        public bool ChangePassword { get; set; }
    }
}
