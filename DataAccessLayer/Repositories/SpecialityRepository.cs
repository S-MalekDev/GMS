using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.ITranierSpeciality;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly AppDbContext _context;

        public SpecialityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Speciality>> GetAllAsync()
        {
            var specialities = await _context.Specialities.AsNoTracking()
                .ToListAsync();

            return specialities;
        }

        public async Task<Speciality?> GetByIdAsync(short specialityId)
        {
            var speciality = await _context.Specialities.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SpecialityId == specialityId);

            return speciality;
        }

        public async Task<short> AddAsync(Speciality specialityToAdd)
        {
            await _context.Specialities.AddAsync(specialityToAdd);
            await _context.SaveChangesAsync();
            return specialityToAdd.SpecialityId;
        }

        public async Task<bool> UpdateAsync(Speciality specialityToUpdate)
        {
            var specialityFound = await _context.Specialities.FirstOrDefaultAsync(s => s.SpecialityId == specialityToUpdate.SpecialityId);

            if (specialityFound != null)
            {
                specialityFound.SpecialityName = specialityToUpdate.SpecialityName;
                specialityFound.Description = specialityToUpdate.Description;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(short specialityId)
        {
            var specialityFound = await _context.Specialities.FindAsync(specialityId);

            if (specialityFound != null)
            {
                // NOTE: Soft delete handled by SQL Trigger (Instead Of Delete)
                _context.Specialities.Remove(specialityFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsAsync(short specialityId)
        {
            var exists = await _context.Specialities.AsNoTracking()
                .AnyAsync(s => s.SpecialityId == specialityId);

            return exists;
        }
    }
}
