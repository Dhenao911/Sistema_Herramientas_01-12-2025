using System.ComponentModel.DataAnnotations;

namespace SH.Share.Models
{
    public class Tool : AuditBase
    {
        [Display(Name = "Tool Name")]
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(50, ErrorMessage = "The field {0} has maximun {1} charathers")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field  is required")]
        [MaxLength(50, ErrorMessage = "The field {0} has maximun {1} charathers")]
        public string Category { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "The field {0} has maximun {1} charathers")]
        public string State { get; set; } = "Disponible";

        public ICollection<Loan> Loans { get; set; }
    }
}