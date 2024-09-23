using System.ComponentModel.DataAnnotations;

namespace Company_PL.ViewModel
{
	public class ForgetPasswordVM
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
	}
}
