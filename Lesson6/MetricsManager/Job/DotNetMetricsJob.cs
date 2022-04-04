using MetricsManager.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace MetricsManager.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        // Счётчик для метрики DotNet
        private PerformanceCounter _dotnetCounter;
        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _dotnetCounter = new PerformanceCounter (".NET CLR Memory","# Gen 0 heap size");
        }

public Task Execute(IJobExecutionContext context)
        {
            // Получаем значение занятости CPU
            var DotNetUsage = Convert.ToInt32(_dotnetCounter.NextValue());
            // Узнаем, когда мы сняли значение метрики
            var time =
            TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // Теперь можно записать что-то посредством репозитория
            _repository.Create(new DotNetMetric
            {
                Time = time,
                Value =
            DotNetUsage
            });
            return Task.CompletedTask;
        }
    }
}
