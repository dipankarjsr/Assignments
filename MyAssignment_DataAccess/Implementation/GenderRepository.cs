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
    public class GenderRepository : IGenderRepository
    {
        private readonly AppDbContext _appDbContext;

        public GenderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            var genderList= await _appDbContext.Genders.ToListAsync();            
            return genderList;
        }
            
        
    }
}
