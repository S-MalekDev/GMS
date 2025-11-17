using CoreLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.IBusinessRule.User
{
    public interface IUserMustBeActiveRule : IBusinessRule<int>
    {
        new Task<BusinessRuleResult> ValidateAsync(int userId);
    }
}
