using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class JobExtensions
    {
        public static void UpdateFrom(this Job job, Job jobToUpdate)
        {
            if(jobToUpdate == null)  throw new ArgumentNullException();

            job.JobId = jobToUpdate.JobId;
            job.JobTitle = jobToUpdate.JobTitle;
            job.Description = jobToUpdate.Description;
            
        }
    }
}
