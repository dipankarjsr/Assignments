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
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        private readonly AppDbContext _db;

        public CustomerInfoRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Customer_Info> Add(Customer_Info pCustomer_Info)
        {
            var result = await _db.AddAsync(pCustomer_Info);
            _db.SaveChanges();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var customerInfo = await _db.Customer_Infos.FindAsync(id);
            if (customerInfo == null)
                return false;

            _db.Remove(customerInfo);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Customer_Info>> GetAll()
        {
            var customerInfoList = await _db.Customer_Infos.Include(x => x.Gender).Include(x => x.District).ThenInclude(x => x.State).ToListAsync();

            return customerInfoList;
        }

        public async Task<Customer_Info> GetById(int id)
        {
            var customerInfo = await _db.Customer_Infos.Include(x => x.Gender).Include(x => x.District).ThenInclude(x => x.State).FirstOrDefaultAsync(x => x.Id == id);

            return customerInfo;
        }

        public async Task<bool> Update(Customer_Info customer_Info)
        {
            var customerInfo = await _db.Customer_Infos.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==customer_Info.Id);
            if (customerInfo == null)
                return false;

            _db.Update(customer_Info);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
