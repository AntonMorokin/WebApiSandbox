using System;

namespace Core.Common
{
    internal class TimeManager : ITimeManager
    {
        public DateTime LocalDateTime => DateTime.Now;
    }
}
