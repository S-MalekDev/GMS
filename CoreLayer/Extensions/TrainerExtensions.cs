using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class TrainerExtensions
    {
        public static void UpdateFrom (this Trainer trainer, Trainer trainerToUpdate)
        {
            trainer.TrainerId = trainerToUpdate.TrainerId;
            trainer.EmployeeId = trainerToUpdate.EmployeeId;
            trainer.SpecialityId = trainerToUpdate.SpecialityId;
            trainer.CreatedByUserId = trainerToUpdate.CreatedByUserId;
            trainer.ExperienceYears = trainerToUpdate.ExperienceYears;
            trainer.IsActive = trainerToUpdate.IsActive;
            trainer.IsDeleted = trainerToUpdate.IsDeleted;
        }
    }
}
