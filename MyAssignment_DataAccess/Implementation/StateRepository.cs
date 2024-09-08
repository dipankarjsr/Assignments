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
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _appDbContext;

        public StateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<State>> GetAllAsync()
        {
            var stateList= await _appDbContext.States.ToListAsync();            
            return stateList;
        }
            
        
    }
}
