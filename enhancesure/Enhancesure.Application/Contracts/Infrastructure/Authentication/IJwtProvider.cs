using EnhanceSure.Domain.Entities;

namespace EnhanceSure.Application.Contracts.Infrastructure.Authentication {
    public interface IJwtProvider {
        string GenerateToken(User user);
    }
}
