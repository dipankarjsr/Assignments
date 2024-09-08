using MyAssignment_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_DataAccess.IRepository
{
    public interface ICustomerInfoRepository
    {
        Task<IEnumerable<Customer_Info>> GetAll();
        Task<Customer_Info> GetById(int id);
        Task<Customer_Info> Add(Customer_Info pCustomer_Info);
        Task<bool> Update(Customer_Info pCustomer_Info);
        Task<bool> Delete(int id);
    }
}
