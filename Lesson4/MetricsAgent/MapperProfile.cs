using AutoMapper;
using MetricsAgent.Models;
using MetricsAgent.Responses;
using MetricsAgent.DAL;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
        }
    }
}