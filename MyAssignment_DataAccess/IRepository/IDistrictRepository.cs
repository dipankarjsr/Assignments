using MyAssignment_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_DataAccess.IRepository
{
    public interface IDistrictRepository
    {
        Task<List<District>> GetByStateIdAsync(int stateId);

        Task<Int16> GetStateByDistrictIdAsync(Int16 districtId);
    }
}
