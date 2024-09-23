using System.ComponentModel.DataAnnotations;

namespace Company_PL.ViewModel
{
	public class SignInVM
	{
		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
		public bool RememberMe { get; set; }
	}
}
