using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class RoleUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter role's name!")]
        public string Name { get; set; }
    }
}
