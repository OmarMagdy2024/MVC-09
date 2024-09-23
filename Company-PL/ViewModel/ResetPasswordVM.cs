using System.ComponentModel.DataAnnotations;

namespace Company_PL.ViewModel
{
	public class ResetPasswordVM
	{
		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "ConfirmPassword Is Required")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "ConfirmPassword Doesn't match Password")]
		public string ConfirmPassword { get; set; }
	}
}
