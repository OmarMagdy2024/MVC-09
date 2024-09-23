using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_PL.ViewModel
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "FName Is Required")]
        public string FName { get; set; }

		[Required(ErrorMessage = "LName Is Required")]
		public string LName {  get; set; }

		[Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "ConfirmPassword Is Required")]
		[DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "ConfirmPassword Doesn't match Password")]
		public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "IsAgree Is Required")]
        public bool IsAgree { get; set; }
    }
}
