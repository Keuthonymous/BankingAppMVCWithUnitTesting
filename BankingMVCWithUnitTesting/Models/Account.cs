using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankingMVCWithUnitTesting.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string AccountHolderFName { get; set; }

        [Required]
        [Display(Name  = "Last Name")]
        public string AccountHolderLName { get; set; }

        [Required]
        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Balance { get; set; }

        [ForeignKey("Bank")]
        public int BankID { get; set; }
        public virtual Bank Bank { get; set; }

        public virtual ICollection<Trans> Transactions { get; set; }
    }
}