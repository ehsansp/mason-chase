using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Phone(ErrorMessage ="The Phone Is Incorrect")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "The Email Is Incorrect")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter {0}")]
        public string BankAccountNumber { get; set; }

    }
}
