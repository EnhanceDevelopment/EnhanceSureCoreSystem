using BindraSawMill.Application.Shared.Request;
using EnhanceSure.Application.DTOs.Interviewees;

namespace EnhanceSure.Application.Features.Interviewees.Requests.Queries {
    public class GetIntervieweeQuery: AppRequest<GetIntervieweeDto>
    {
        public Guid Id { get; set; }
    }
}
