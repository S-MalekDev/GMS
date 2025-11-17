using CoreLayer.Enums.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.ILogging
{
    public interface ILogStrategySelector
    {
        ILogStrategy SelectLogStrategy(enLogStrategyType LogStrategyType);
    }
}
