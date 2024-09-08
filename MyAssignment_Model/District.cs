using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_Model
{
    [Table("District")]
    public class District
    {
        [Key]        
        public Int16 Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public Int16 StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State? State { get; set; }
    }
}
