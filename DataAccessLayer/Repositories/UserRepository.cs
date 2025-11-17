using CoreLayer.Entities;
using CoreLayer.Interfaces.IUser;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using CoreLayer.Extensions;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.AsNoTracking()
                .Where(u => !u.IsDeleted)
                .Include(u => u.PersonInfo)
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            var user = await _context.Users.AsNoTracking()
                .Include(u => u.PersonInfo)
                .FirstOrDefaultAsync(u => u.UserID == userId && !u.IsDeleted);

            return user;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.AsNoTracking()
                .Include(u => u.PersonInfo)
                .FirstOrDefaultAsync(u => u.Username == username && !u.IsDeleted);

            return user;
        }
        public async Task<int> AddAsync(User userToAdd)
        {
            await _context.Users.AddAsync(userToAdd);
            await _context.SaveChangesAsync();
            return userToAdd.UserID;
        }

        public async Task<bool> UpdateAsync(int userId, string username, int parmissions, bool isActive)
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId && !u.IsDeleted);

            if (userFound != null)
            {
                userFound.Username = username;
                userFound.Parmissions = parmissions;
                userFound.IsActive = isActive;
                
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var userFound = _context.Users.Find(userId);

            if (userFound != null)
            {
                // NOTE: Soft delete handled by SQL Trigger (Instead Of Delete)
                _context.Users.Remove(userFound);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RestoreAsync(int personId)
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(u => u.PersonID == personId && u.IsDeleted);

            if (userFound != null)
            {
                userFound.IsDeleted = false;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsByIdAsync(int UserId)
        {
            var Exists =  await _context.Users.AsNoTracking()
                .AnyAsync(u => u.UserID == UserId && !u.IsDeleted);

            return Exists;
        }
        public async Task<bool> ExistsByUsernameAsync(string username)
        {
            var Exists = await _context.Users.AsNoTracking()
                .AnyAsync(u => u.Username == username && !u.IsDeleted);

            return Exists;
        }
        public async Task<bool> HasActiveUserAsync(int personId)
        {
            var Exists = await _context.Users.AsNoTracking()
                .AnyAsync(u => u.PersonID == personId && u.IsActive && !u.IsDeleted);

            return Exists;
        }

        public async Task<bool> PersonHasDeletedUserAccount(int personId)
        {
            var Exists = await _context.Users.AsNoTracking()
                .AnyAsync(u => u.PersonID == personId && u.IsDeleted);

            return Exists;
        }

        public async Task<string> GetUserPasswordHashByUsernameAsync(string username)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);

            if (user != null)
                return user.PasswordHash;

            return "";

        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _context.Users.AsNoTracking().AnyAsync(u => u.Username == username);
        }

        public async Task<bool> ChangeUserActivationAsync(int userId, bool isActive)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.IsActive = isActive;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
            
        }

        public async Task<bool> UpdateUserPasswordAsync(int userId, string newPasswordHash)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.PasswordHash = newPasswordHash;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> IsActiveAsync(int userId)
        {
            var isActive = await _context.Users.AsNoTracking()
                .AnyAsync(u => u.UserID == userId && u.IsActive);

            return isActive;
        }

        public async Task<bool> ExistsByPersonIdAsync(int personId)
        {
            var Exists = await _context.Users.AsNoTracking()
                .AnyAsync(u => u.PersonID == personId && !u.IsDeleted);

            return Exists;
        }

        public async Task<bool> PersonHasOrHadUserAsync(int personId)
        {
            var Exists = await _context.Users.AsNoTracking()
                .AnyAsync(u => u.PersonID == personId);

            return Exists;
        }
    }
}
