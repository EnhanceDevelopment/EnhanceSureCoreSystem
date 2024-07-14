using AutoMapper;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Enum;

namespace EnhanceSure.Application.Profiles {
    public class MappingProfile: Profile {
        public MappingProfile()
        {
            CreateMap<Interviewee,CreateIntervieweeDto>();
            CreateMap<Interviewee,CreateIntervieweeDto>();
            CreateMap<Interviewee,CreateIntervieweeDto>();
        }
    }
}