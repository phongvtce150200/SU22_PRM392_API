using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SU22_PRM392_API.Database;
using SU22_PRM392_API.RequestRespone;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace SU22_PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResetPasswordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            var check = _context.users.FirstOrDefault(x => x.Email == resetPasswordRequest.Email);
            if (check != null)
            {
                //change random password
                string sRandomPassword = CreateRandomPassword();
                check.Password = sRandomPassword;
                _context.users.Update(check);
                _context.SaveChanges();
                //send new password to customer 
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Food Store Project", "admin@gmail.com"));
                message.To.Add(new MailboxAddress(check.UserName ,resetPasswordRequest.Email));
                message.Subject = "Change your password";
                message.Body = new TextPart("plain")
                {
                    Text = "Your Password is : " + sRandomPassword + "\n"
                    + "Please login and change your password"

                };
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("phongvtce150200@fpt.edu.vn", "Vo Thanh Phong 1712");
                    client.Send(message);
                    client.Disconnect(true);
                }

            }
            else
            {
                return BadRequest(new { Response = "Email is doesn't exists" });
            }

            return Ok();
        }

        private static string CreateRandomPassword(int length = 15)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }


    }
}
