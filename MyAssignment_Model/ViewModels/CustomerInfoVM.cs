using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_Model.ViewModels
{
    public class CustomerInfoVM    {
       
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public byte GenderId { get; set; }
        [Display(Name = "State")]
        public Int16 StateId { get; set; }
        [Required]
        [Display(Name = "District")]
        public Int16 DistrictId { get; set; }
    }
}
