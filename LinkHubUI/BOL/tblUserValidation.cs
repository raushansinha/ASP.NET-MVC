using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueEmailAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            string userEmailValue = value.ToString();
            int count = db.tbl_User.Where(x => x.UserEmail == userEmailValue).ToList().Count;
            if (count != 0)
                return new ValidationResult("User Already Exists with This Email Id");

            return ValidationResult.Success;
        }
    }

    public class tblUserValidation
    {
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassowrd { get; set; }
    }

    [MetadataType(typeof(tblUserValidation))]
    public partial class tbl_User
    {
            public string ConfirmPassowrd { get; set; }
    }
}

