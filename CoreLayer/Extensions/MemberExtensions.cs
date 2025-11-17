using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class MemberExtensions
    {
        public static void UpdateFrom(this Member member, Member memberToUpdate)
        {
            member.MemberId = memberToUpdate.MemberId;
            member.PersonId = memberToUpdate.PersonId;
            member.PersonalTrainerId = memberToUpdate.PersonalTrainerId;
            member.CreatedByUserId = memberToUpdate.CreatedByUserId;
            member.EnrollmentDate = memberToUpdate.EnrollmentDate;
            member.IsDeleted = memberToUpdate.IsDeleted;
            member.IsActive = memberToUpdate.IsActive;
        }
    }
}
