using MetricsManager.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsManager.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        // Счётчик для метрики Network
        private PerformanceCounter _networkCounter;
        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec");
        }

public Task Execute(IJobExecutionContext context)
        {
            // Получаем значение занятости CPU
            var NetworkUsage = Convert.ToInt32(_networkCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
            TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new NetworkMetric
            {
                Time = time,
                Value =
            NetworkUsage
            });
            return Task.CompletedTask;
        }
    }
}
