using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Persistance.DbContexts;

namespace EnhanceSure.Persistance.Repositories {
    public class IntervieweeRepository: GenericRepositoryAsync<Interviewee>, IIntervieweeRepository {
        private readonly ApplicationDbContext _dbContext;
        public IntervieweeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
