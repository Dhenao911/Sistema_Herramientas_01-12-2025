using System.ComponentModel.DataAnnotations;

namespace SH.Share.Models
{
    public class Employee : AuditBase
    {
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "The field {0} has maximun {1} charathers")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field  is required")]
        [MaxLength(50, ErrorMessage = "The field {0} has maximun {1} charathers")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "The field {0} has maximun {1} charathers")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(15, ErrorMessage = "The field {0} has maximun {1} charathers")]
        [RegularExpression(@"^(\+57)?[0-9]{10}$",
        ErrorMessage = "Please enter a valid phone number. Example: +573001234567 or 3001234567.")]
        public string Phone { get; set; }

        public ICollection<Loan>? Loands { get; set; }
    }
}