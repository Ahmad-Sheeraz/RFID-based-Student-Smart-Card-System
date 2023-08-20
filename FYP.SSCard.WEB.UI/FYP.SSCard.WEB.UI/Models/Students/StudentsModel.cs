using StudentSmartCard.Location;
using StudentSmartCard.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYP.SSCard.WEB.UI.Models.Students
{
    public class StudentsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string StudentRollNo { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string FatherName { get; set; }
        public string Guardian { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }
        [RegularExpression("^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        public string CNIC { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string CellNo { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string MobileNo { get; set; }
       // public virtual Gender Gender { get; set; }
       // public virtual Religions Religion { get; set; }
       // public virtual City Cities { get; set; }
       // public virtual SubCategory SubCategories { get; set; }
    }
}