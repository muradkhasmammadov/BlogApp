using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage = "Please enter your username!")]
		public string username { get; set; }

		[Required(ErrorMessage = "Please enter your password!")]
		public string password { get; set; }
	}

}
