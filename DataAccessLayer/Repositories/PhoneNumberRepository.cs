using CoreLayer.Entities;
using CoreLayer.Interfaces.IPerson.Phone;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class PhoneNumberRepository:IPhoneNumberRepository
    {
        private readonly AppDbContext _context;

        public PhoneNumberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(PhoneNumber phoneNumber)
        {
            await _context.PhoneNumbers.AddAsync(phoneNumber);
            await _context.SaveChangesAsync();
            return phoneNumber.PhoneNumberID;
        }

        public async Task<IEnumerable<PhoneNumber>> GetAllAsync()
        {
            return await _context.PhoneNumbers.AsNoTracking().ToListAsync();
        }

        public async Task<PhoneNumber?> GetByIdAsync(int phoneNumberId)
        {
            var phoneNumber = await _context.PhoneNumbers.AsNoTracking().FirstOrDefaultAsync(n => n.PhoneNumberID == phoneNumberId);
            return phoneNumber;
        }

        public async Task<IEnumerable<PhoneNumber>> GetByPersonIdAsync(int personId)
        {           
             return await _context.PhoneNumbers.AsNoTracking().Where(p => p.PersonID == personId).ToListAsync();            
        }

        public async Task<bool> ExistsByIdAsync(int phoneNumberId)
        {
            return await _context.PhoneNumbers.AsNoTracking().AnyAsync(n => n.PhoneNumberID == phoneNumberId);
        }
        
        public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.PhoneNumbers.AsNoTracking().AnyAsync(n => n.Number == phoneNumber);
        }

        public async Task<bool> UpdateAsync(PhoneNumber numberToUpdate)
        {
            var phoneNumber = await _context.PhoneNumbers.FindAsync(numberToUpdate.PhoneNumberID);

            if (phoneNumber is null) return false;

            
            phoneNumber.Number = numberToUpdate.Number;
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool> DeleteAsync(int phoneNumberId)
        {
            var phoneNumber = await _context.PhoneNumbers.FindAsync(phoneNumberId);

            if(phoneNumber is null) return false;

            _context.Remove(phoneNumber);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
