using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.IProgramType;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ProgramTypeRepository : IProgramTypeRepository
    {
        private readonly AppDbContext _context;

        public ProgramTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramType>> GetAllAsync()
        {
            var programTypes = await _context.ProgramTypes
                .AsNoTracking()
                .ToListAsync();

            return programTypes;
        }

        public async Task<ProgramType?> GetByIdAsync(short programTypeId)
        {
            var programType = await _context.ProgramTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProgramTypeId == programTypeId);

            return programType;
        }

        public async Task<short> AddAsync(ProgramType programTypeToAdd)
        {
            await _context.ProgramTypes.AddAsync(programTypeToAdd);
            await _context.SaveChangesAsync();
            return programTypeToAdd.ProgramTypeId;
        }

        public async Task<bool> UpdateAsync(ProgramType programTypeToUpdate)
        {
            var programTypeFound = await _context.ProgramTypes
                .FirstOrDefaultAsync(p => p.ProgramTypeId == programTypeToUpdate.ProgramTypeId);

            if (programTypeFound != null)
            {
                programTypeFound.UpdateFrom(programTypeToUpdate);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(short programTypeId)
        {
            var programTypeFound = await _context.ProgramTypes.FindAsync(programTypeId);

            if (programTypeFound != null)
            {
                _context.ProgramTypes.Remove(programTypeFound);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public Task<bool> ExistsAsync(short programTypeId)
        {
            var exists = _context.ProgramTypes.AsNoTracking().AnyAsync(pt => pt.ProgramTypeId == programTypeId);

            return exists;
        }
    }
}
