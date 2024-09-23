using Company_DAL.Models;
using System.Net;
using System.Net.Mail;

namespace Company_PL
{
	public class Helper
	{
		public static void SendEmail(Email email)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl = false;
			client.Credentials = new NetworkCredential("omar.mego17@gmail.com","Amor@01011878562");
			client.Send("omar.mego17@gmail.com", email.Resipiant, email.Supject, email.Body);
		}
	}
}
