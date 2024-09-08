using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_Model
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9_]*$",ErrorMessage ="Domain Name allows only alpha numeric string and _ character.")]
        public string? DomainName { get; set; }
    }
}
