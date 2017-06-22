using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingMVCWithUnitTesting.Models
{
    public class Trans
    {
        [Key]
        public int ID { get; set; }

        [Required]
        DateTime EventTime { get; set; }

        [Required]
        public EventType Type { get; set; }

        [Required]
        public double Amount { get; set; }

        public virtual ICollection<Account> Account { get; set; }

        public enum EventType
        {
            WithDrawl,
            Deposit
        }
    }
}