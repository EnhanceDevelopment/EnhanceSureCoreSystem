using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Persistance.DbContexts;
using EnhanceSure.Persistance.Repositories.Common;

namespace EnhanceSure.Persistance.Repositories {
    public class InterviewerRepository: GenericRepositoryAsync<Interviewer>, IInterviewerRepository {
        private readonly ApplicationDbContext _dbContext;
        public InterviewerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext=dbContext;
        }
    }
}
