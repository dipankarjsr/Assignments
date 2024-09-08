using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_Model.ViewModels
{
    public class CustomerVM
    {
        public IEnumerable<Customer_Info>? CustomerInfoList { get; set; }
        public CustomerInfoVM? CustomerInfo { get; set; }
    }
}
