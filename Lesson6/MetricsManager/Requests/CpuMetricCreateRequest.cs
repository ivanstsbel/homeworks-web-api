using System;

namespace MetricsManager.Requests
{
    public class GetAllCpuMetricsRequest
    {
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public Uri ClientBaseAddress { get; set; }
        public int Value { get; set; }
    }
}