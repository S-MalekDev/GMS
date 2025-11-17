using CoreLayer.Entities;
using CoreLayer.Interfaces.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class UserExtensions
    {
        public static void UpdateFrom(this User user, User userToUpdate)
        {
            if(userToUpdate == null) throw new ArgumentNullException();

            user.UserID = userToUpdate.UserID;
            user.PersonID = userToUpdate.PersonID;
            user.CreatedByUserID = userToUpdate.CreatedByUserID;
            user.Username = userToUpdate.Username;
            user.PasswordHash = userToUpdate.PasswordHash;
            user.Parmissions = userToUpdate.Parmissions;
            user.CreatedAt = userToUpdate.CreatedAt;
            user.IsActive = userToUpdate.IsActive;
            user.IsDeleted = userToUpdate.IsDeleted;
        }

        public static string GetGenderText(this User user)
        {
            if (user.PersonInfo != null)
                return user.PersonInfo.GetGenderText();
            else return "";
        }
        public static string GetFullName(this User user)
        {
            if (user.PersonInfo != null)
                return user.PersonInfo.GetFullName();
            else return "";
        }
    }
}
