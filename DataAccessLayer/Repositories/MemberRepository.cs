using CoreLayer.Entities;
using CoreLayer.Extensions;
using CoreLayer.Interfaces.IMember;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            var members = await _context.Members.AsNoTracking()
                .Where(m => !m.IsDeleted)
                .Include(m => m.Person)
                .Include(m => m.PersonalTrainer)
                .ThenInclude(t => t.EmployeeInfo)
                .ThenInclude(e => e.PersonInfo)
                .ToListAsync();

            return members;
        }

        public async Task<Member?> GetByIdAsync(int memberId)
        {
            var member = await _context.Members.AsNoTracking()
                .FirstOrDefaultAsync(m => m.MemberId == memberId && !m.IsDeleted);

            return member;
        }

        public async Task<int> AddAsync(Member memberToAdd)
        {
            await _context.Members.AddAsync(memberToAdd);
            await _context.SaveChangesAsync();
            return memberToAdd.MemberId;
        }

        public async Task<bool> UpdateAsync(Member memberToUpdate)
        {
            if (memberToUpdate != null)
            {
                _context.Members.Update(memberToUpdate);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int memberId)
        {
            var memberFound = await _context.Members.FindAsync(memberId);

            if (memberFound != null)
            {
                // NOTE: Soft delete handled by SQL Trigger (Instead Of Delete)
                _context.Members.Remove(memberFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RestoreAsync(int personId)
        {
            var memberFound = await _context.Members
                .FirstOrDefaultAsync(m => m.PersonId == personId);

            if (memberFound != null)
            {
                memberFound.IsDeleted = false;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsByIdAsync(int memberId)
        {
            var exists = await _context.Members.AsNoTracking()
                .AnyAsync(m => m.MemberId == memberId && !m.IsDeleted);

            return exists;
        }

        public async Task<bool> ExistsByPersonIdAsync(int personId)
        {
            var exists = await _context.Members.AsNoTracking()
                            .AnyAsync(m => m.PersonId == personId && !m.IsDeleted);

            return exists;
        }

        public async Task<bool> PersonHasDeletedMemberAsync(int personId)
        {
            var exists = await _context.Members.AsNoTracking()
                            .AnyAsync(m => m.PersonId == personId && m.IsDeleted);

            return exists;
        }

        public async Task<bool> PersonBeOrHaveBeMemberAsync(int personId)
        {
            var exists = await _context.Members.AsNoTracking()
                            .AnyAsync(m => m.PersonId == personId);

            return exists;
        }

        public async Task<bool> IsActiveAsync(int memberId)
        {
            var IsActive = await _context.Members.AsNoTracking()
                .AnyAsync(m => m.MemberId == memberId && m.IsActive);

            return IsActive;
        }

        
    }
}
