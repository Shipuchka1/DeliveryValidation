using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Delivery.Models
{
    [TypeFeedback(ErrorMessage = "Имя должно быть заполнено")]
    [Email(ErrorMessage ="Поля вопрос и Email должны быть заполнены")]
    public class Feedback
    {
        
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }    
        [Required]
        public TypeFeedback TypeFeedback { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 11, ErrorMessage = "В поле Вопрос должно быть более 10 символов")]
        [Required]
        public string Question { get; set; }
    }

    public enum TypeFeedback
    {
        GeneralIssues,
        ComplaintsAndSuggestions,
        SiteComments,
        SearchItem,
        FinancialQuestions
    }

    public class TypeFeedbackAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Feedback fb = value as Feedback;
            if (fb != null)
                if (fb.TypeFeedback != TypeFeedback.ComplaintsAndSuggestions)
                {
                    if (string.IsNullOrEmpty(fb.Name))
                        return false;
                    else return true;
                }

                else return true;
            else return false;
        }
    }

    public class EmailAttribute:ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            Feedback fb = value as Feedback;
            if (fb != null)
                if (!string.IsNullOrEmpty(fb.Question) && !string.IsNullOrEmpty(fb.Email))
                {
                    if(fb.TypeFeedback==TypeFeedback.ComplaintsAndSuggestions)
                    MyEmail.SendMail(fb);
                    return true;
                }
                else return false;
            else return false;
            
        }
    }


    public class MyEmail
    {
      

        public static void SendMail(Feedback feedback)
        {
           EmailConfig config =
       (EmailConfig)System.Configuration.ConfigurationManager.GetSection(
       "SendEmailConfig");

            MailMessage mail = new MailMessage(config.Email.Value, config.SendTo.Value);
            SmtpClient client = new SmtpClient();
            client.Port = config.Port.Value;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = config.Server.Value;
            mail.Subject = feedback.TypeFeedback.ToString();
            mail.Body = feedback.Question;
            client.Credentials = new System.Net.NetworkCredential(config.Email.Value, config.Password.Value);
            client.EnableSsl = true;
            client.Send(mail);
        }
    }

}