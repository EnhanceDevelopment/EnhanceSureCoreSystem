using AutoMapper;
using Dapper;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Shared.Responses;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Interfaces;
using MediatR;
using Dapper;

namespace EnhanceSure.Application.Features.Interviewees.Queries.GetInterviewee {
    public class GetIntervieweeQueryHandler : RequestHandlerBase, IRequestHandler<GetIntervieweeQuery, AppResponse<GetIntervieweeDto>>
    {
        private readonly IDbConnectionFactory _connection;
        private readonly IMapper _mapper;

        public GetIntervieweeQueryHandler(IDbConnectionFactory connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }

        public async Task<AppResponse<GetIntervieweeDto>> Handle(GetIntervieweeQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connection.CreateConnection();
            var query = $@"SELECT * FROM tbl_Interviewees WHERE Id= @IntervieweeId";
            var parameters = new
            {
                IntervieweeId = $"{request.Id}"
            };
            var resultQuery = await connection.QueryFirstOrDefaultAsync<Interviewee>(query, parameters);
            return Ok(_mapper.Map<GetIntervieweeDto>(resultQuery));
        }
    }
}
