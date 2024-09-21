using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Shared.Request;

namespace EnhanceSure.Application.Features.Interviewees.Queries.GetInterviewee
{
    public class GetIntervieweeQuery : AppRequest<GetIntervieweeDto>
    {
        public Guid Id { get; set; }
    }
}
