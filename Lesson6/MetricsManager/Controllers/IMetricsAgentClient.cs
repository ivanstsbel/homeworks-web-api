using MetricsManager;
using MetricsManager.Responses;
using MetricsManager.Requests;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
        AllRamMetricsResponse GetAllRamMetrics(GetAllRamMetricsRequest
        request);
        AllHddMetricsResponse GetAllHddMetrics(GetAllHddMetricsRequest
        request);
        AllDotNetMetricsResponse GetDonNetMetrics(DonNetMetricsRequest request);
        AllCpuMetricsResponse GetCpuMetrics(GetAllCpuMetricsRequest request);
    }
}
