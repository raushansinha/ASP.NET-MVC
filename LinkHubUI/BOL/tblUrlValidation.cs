using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            if (value == null)
                return null;// new ValidationResult("Url Already Exist");

            String urlValue = value.ToString();
            int count = db.tbl_Url.Where(x => x.Url == urlValue).ToList().Count();
            if (count != 0)
                return new ValidationResult("Url Already Exist");
            return ValidationResult.Success;
        }
    }

    public class tblUrlValidation
    {
        [Required]
        public string UrlTitle { get; set; }

        [Required]
        [UniqueUrl]
        [Url]
        public string Url { get; set; }

        [Required]
        public string UrlDesc { get; set; }
    }

    [MetadataType(typeof(tblUrlValidation))]
    public partial class tbl_Url
    { }
}
