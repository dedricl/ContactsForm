using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsForm.Models
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email address"),]

        public string EmailAddress { get; set; }
        [Phone]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}", ErrorMessage ="Phone Number must be in XXX-XXX-XXXX format")]
        
        public string PhoneNumber { get; set; }
    }
}
