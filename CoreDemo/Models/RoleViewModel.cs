using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Enter role name!")]
        public string Name { get; set; }
    }
}
