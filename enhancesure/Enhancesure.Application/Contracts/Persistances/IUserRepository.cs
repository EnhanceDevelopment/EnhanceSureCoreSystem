using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Interfaces.Common;

namespace EnhanceSure.Application.Contracts.Persistances {
    public interface IUserRepository:IGenericRepositoryAsync<User> {
        bool CheckPassword(string? existingPassword, string requestPassword);
        string CheckPasswordValidation(string? password);
        string? EncryptPassword(string? password);
        Task<User> GetUserByEmailId(string emailId);
    }
}
