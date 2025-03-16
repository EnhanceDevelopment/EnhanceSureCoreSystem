using AutoMapper;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Domain.Entities;

namespace EnhanceSure.Application.Profiles {
    public class MappingProfile: Profile {
        public MappingProfile()
        {
            CreateMap<Interviewee, GetIntervieweeDto>().ReverseMap();
            CreateMap<CreateIntervieweeDto, Interviewee>().ReverseMap();
            CreateMap<Interviewee, IntervieweeDto>().ReverseMap();
        }
    }
}