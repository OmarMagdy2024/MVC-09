using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_DAL.Models
{
	public class Email:ModelBase
	{
		public string Supject {  get; set; }
		public string Body { get; set; }
		public string Resipiant { get; set; }
	}
}
