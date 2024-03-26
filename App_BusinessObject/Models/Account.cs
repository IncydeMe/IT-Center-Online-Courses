using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
/*        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]*/
        public DateTime BirthDate { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Phone(ErrorMessage = "Invalid Phone number")]
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public string DigitalSignature { get; set; }    
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}

        public virtual Role Role { get; set; }
    }
}
