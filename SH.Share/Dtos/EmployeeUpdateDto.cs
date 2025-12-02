using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Share.Dtos
{
    public class EmployeeUpdateDto
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "The field {0} has maximun {1} charathers")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "The field {0} has maximun {1} charathers")]
       
        public string Phone { get; set; }
    }
}
