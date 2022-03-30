using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        // Счётчик для метрики Hdd
        private PerformanceCounter _hddCounter;
        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter ("PhysicalDisk", "Current Disk Queue Length");
        }

public Task Execute(IJobExecutionContext context)
        {
            // Получаем значение занятости CPU
            var HddUsage = Convert.ToInt32(_hddCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
            TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new HddMetric
            {
                Time = time,
                Value =
            HddUsage
            });
            return Task.CompletedTask;
        }
    }
}
