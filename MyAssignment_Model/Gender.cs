using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_Model
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        public byte Id { get; set; }
        public string? Name { get; set; }
    }
}
