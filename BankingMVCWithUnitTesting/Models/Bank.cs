using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingMVCWithUnitTesting.Models
{
    public class Bank
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Bank name")]
        public string BankName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double BankCapital { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}