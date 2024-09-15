using AutoMapper;
using BindraSawMill.Application.Shared.Responses;
using Domain.Interfaces;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Features.Interviewees.Requests.Queries;
using EnhanceSure.Domain.Entities;
using MediatR;

namespace EnhanceSure.Application.Features.Interviewees.Handler.Queries {
    public class GetIntervieweeQueryHandler: RequestHandlerBase, IRequestHandler<GetIntervieweeQuery, AppResponse<GetIntervieweeDto>> {
        private readonly IDbConnectionFactory _connection;
        private readonly IIntervieweeRepository _intervieweeRepository;
        private readonly IMapper _mapper;

        public GetIntervieweeQueryHandler(IDbConnectionFactory connection, IIntervieweeRepository intervieweeRepository, IMapper mapper)
        {
            _connection=connection;
            _intervieweeRepository=intervieweeRepository;
            _mapper=mapper;
        }

        public async Task<AppResponse<GetIntervieweeDto>> Handle(GetIntervieweeQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connection.CreateConnection();
            var query = $@"SELECT * FROM tbl_Interviewees WHERE Id= @IntervieweeId";
            var parameters = new
            {
                IntervieweeId = $"{request.Id}"
            };
            var resultQuery = await _connection.QuerySingleAsync<Interviewee>(query,parameters);
            return Ok(_mapper.Map<GetIntervieweeDto>(resultQuery));
        }
    }
}
