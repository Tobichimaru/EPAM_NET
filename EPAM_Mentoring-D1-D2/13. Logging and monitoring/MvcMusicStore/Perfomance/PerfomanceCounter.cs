using System.Diagnostics;
using PerformanceCounterHelper;

namespace MvcMusicStore.Perfomance
{
    [PerformanceCounterCategory("MvcMusicStore", PerformanceCounterCategoryType.MultiInstance, "Mvc Music Store counters")]
    public enum PerfomanceCounters
    {
        [PerformanceCounterAttribute("LogInCounter",
            "LogIn Counter",
            System.Diagnostics.PerformanceCounterType.NumberOfItems64)]
        LogInCounter,

        [PerformanceCounterAttribute("LogOffCounter",
            "LogOff Counter",
            System.Diagnostics.PerformanceCounterType.NumberOfItems64)]
        LogOffCounter
    }
}