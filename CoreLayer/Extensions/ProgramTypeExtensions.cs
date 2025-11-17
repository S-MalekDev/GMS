using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class ProgramTypeExtensions
    {
        public static void UpdateFrom(this ProgramType programType, ProgramType programTypeToUpdateFrom)
        {
            programType.ProgramTypeId = programTypeToUpdateFrom.ProgramTypeId;
            programType.Name = programTypeToUpdateFrom.Name;
            programType.Description = programTypeToUpdateFrom.Description;
            programType.SingleSissionPrice = programTypeToUpdateFrom.SingleSissionPrice;
            programType.SubscriptionMonthlyPrice = programTypeToUpdateFrom.SubscriptionMonthlyPrice;
        }
    }
}
