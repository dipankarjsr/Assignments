using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_Model
{
    [Table("Customer_Info")]
    public class Customer_Info
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public byte GenderId { get; set; }
        [Required]
        public Int16 DistrictId { get; set; }

        [ForeignKey(nameof(GenderId))]
        public Gender? Gender { get; set; }
        [ForeignKey(nameof(DistrictId))]
        public District? District { get; set; }
    }
}
