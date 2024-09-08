using Microsoft.EntityFrameworkCore;
using MyAssignment_DataAccess.IRepository;
using MyAssignment_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment_DataAccess.Implementation
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly AppDbContext _appDbContext;

        public DistrictRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<District>> GetByStateIdAsync(int stateId)
        {
            var districtList = await _appDbContext.Districts.Where(x => x.StateId == stateId).AsQueryable().ToListAsync();
            return districtList;
        }

        public async Task<Int16> GetStateByDistrictIdAsync(Int16 districtId)
        {
            return await _appDbContext.Districts.Where(x => x.Id == districtId).Select(x =>x.StateId).FirstOrDefaultAsync();
        }
    }



}
