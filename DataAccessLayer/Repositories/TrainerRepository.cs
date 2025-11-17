using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.ITrainer;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly AppDbContext _context;

        public TrainerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            var trainers = await _context.Trainers.AsNoTracking()
                .Where(t => !t.IsDeleted)
                .Include(t => t.EmployeeInfo)
                .ThenInclude(e => e.PersonInfo)
                .Include(t => t.SpecialityInfo)
                .ToListAsync();

            return trainers;
        }

        public async Task<Trainer?> GetByIdAsync(int trainerId)
        {
            var trainer = await _context.Trainers.AsNoTracking()
                .FirstOrDefaultAsync(t => t.TrainerId == trainerId && !t.IsDeleted);

            return trainer;
        }

        public async Task<int> AddAsync(Trainer trainerToAdd)
        {
            await _context.Trainers.AddAsync(trainerToAdd);
            await _context.SaveChangesAsync();
            return trainerToAdd.TrainerId;
        }

        public async Task<bool> UpdateAsync(Trainer trainerToUpdate)
        {
            var trainerFound = await _context.Trainers
                .FirstOrDefaultAsync(t => t.TrainerId == trainerToUpdate.TrainerId && !t.IsDeleted);

            if (trainerFound != null)
            {
                trainerFound.UpdateFrom(trainerToUpdate);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int trainerId)
        {
            var trainerFound = await _context.Trainers.FindAsync(trainerId);

            if (trainerFound != null)
            {
                // NOTE: Soft delete handled by SQL Trigger (Instead Of Delete)
                _context.Trainers.Remove(trainerFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RestoreAsync(int employeeId)
        {
            var trainerFound = await _context.Trainers
                .FirstOrDefaultAsync(t => t.EmployeeInfo.EmployeeId == employeeId && t.IsDeleted);

            if (trainerFound != null)
            {
                trainerFound.IsDeleted = false;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsAsync(int trainerId)
        {
            var exists = await _context.Trainers.AsNoTracking()
                .AnyAsync(t => t.TrainerId == trainerId && !t.IsDeleted);

            return exists;
        }

        public async Task<bool> IsActiveAcync(int trainerId)
        {
            var isActive = await _context.Trainers.AsNoTracking()
                .AnyAsync(t => t.TrainerId == trainerId && t.IsActive);

            return isActive;
        }

        public async Task<bool> EmployeeBeOrHaveBeTrainerAsync(int employeeId)
        {
            var result = await _context.Trainers.AsNoTracking()
                .AnyAsync(t => t.EmployeeId == employeeId);

            return result;
        }

        public async Task<bool> EmployeeHasDeletedTrainerAsync(int employeeId)
        {
            var result = await _context.Trainers.AsNoTracking()
                .AnyAsync(t => t.EmployeeId == employeeId && t.IsDeleted);

            return result;
        }
    }
}
