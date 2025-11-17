using WinFormsClient.Enums.EnLogging;

namespace WinFormsClient.Interfaces.ILogging
{
    public interface ILogStrategySelector
    {
        ILogStrategy SelectLogStrategy(enLogStrategyType LogStrategyType);
    }
}
