using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delivery.Models
{
    [Time(ErrorMessage ="Диапазон времени должен быть в пределах 8:00 - 20:00")]
    public class Sender
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:12,MinimumLength =12,ErrorMessage ="Длина поля ИИН должна содержать 12 символов")]
        public string IIN { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DesiredDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan MaxTime { get; set; }
        [Required]
        public FormOfPayment FormOfPayment { get; set; }
    }

    public enum FormOfPayment
    {
        Cash,
        NonCash,
        Treaty
    }

    public class TimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Sender sender = (Sender)value;
            TimeSpan min = new TimeSpan(8, 0, 0);
            TimeSpan max = new TimeSpan(20, 0, 0);
            if (sender.MaxTime < min || sender.MaxTime > max)
                if (sender.FormOfPayment == FormOfPayment.Treaty)
                    return true;
                else return false;
            else return true;
        }
    }

    
}