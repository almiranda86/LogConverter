using AutoMapper;
using CandidateTest.AndreLuisMiranda.Application.Mapper.Mapping;

namespace CandidateTest.AndreLuisMiranda.Application.Mapper.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new DestionationLogToSourceLog());
                configuration.AddProfile(new SourceLogToDestinationLog());
            });
        }
    }
}
