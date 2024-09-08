using MyAssignment_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_DataAccess.IRepository
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAllAsync();
    }
}
