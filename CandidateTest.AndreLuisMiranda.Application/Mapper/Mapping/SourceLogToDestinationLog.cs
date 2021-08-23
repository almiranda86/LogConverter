using AutoMapper;
using CandidateTest.AndreLuisMiranda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.AndreLuisMiranda.Application.Mapper.Mapping
{
    public class SourceLogToDestinationLog : Profile
    {
        public SourceLogToDestinationLog()
        {
            CreateMap<SourceLogModel, DestinationLogModel>()
                .ForMember(dest => dest.TimeTaken, opt => opt.MapFrom(src => Math.Round(decimal.Parse(src.TimeTaken)).ToString()))
                .ForMember(dest => dest.CacheStatus, opt => opt.MapFrom(src => src.CacheStatus.Equals("INVALIDATE") ? "REFRESH_HIT" : src.CacheStatus));
        }
    }
}
