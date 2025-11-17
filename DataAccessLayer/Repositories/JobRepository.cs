using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.IJob;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            var jobs = await _context.Jobs.AsNoTracking()
                .ToListAsync();

            return jobs;
        }

        public async Task<Job?> GetByIdAsync(short jobId)
        {
            var job = await _context.Jobs.AsNoTracking()
                .FirstOrDefaultAsync(j => j.JobId == jobId);

            return job;
        }

        public async Task<short> AddAsync(Job jobToAdd)
        {
            await _context.Jobs.AddAsync(jobToAdd);
            await _context.SaveChangesAsync();
            return jobToAdd.JobId;
        }

        public async Task<bool> UpdateAsync(Job jobToUpdate)
        {
            var jobFound = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == jobToUpdate.JobId);

            if (jobFound != null)
            {
                jobFound.UpdateFrom(jobToUpdate);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }


        public async Task<bool> DeleteAsync(short jobId)
        {
            var jobFound = await _context.Jobs.FindAsync(jobId);

            if (jobFound != null)
            {
                // NOTE: Soft delete handled by SQL Trigger (Instead Of Delete)
                _context.Jobs.Remove(jobFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Exists(short jobId)
        {
            var exists = await _context.Jobs.AsNoTracking()
                .AnyAsync(j => j.JobId == jobId);

            return exists;
        }
    }
}
