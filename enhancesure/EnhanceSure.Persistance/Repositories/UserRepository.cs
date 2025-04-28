using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Interfaces;
using EnhanceSure.Persistance.DbContexts;
using EnhanceSure.Persistance.Repositories.Common;
using System.Text.RegularExpressions;
using Dapper;
using System.Text;

namespace EnhanceSure.Persistance.Repositories {
    internal class UserRepository: GenericRepositoryAsync<User>, IUserRepository {
        private readonly IDbConnectionFactory _connection;
        public UserRepository(IDbConnectionFactory connection, ApplicationDbContext dbContext):base(dbContext)
        {
            _connection=connection;
        }

        public bool CheckPassword(string? esistingPassword, string requestPassword)
        {
            return BCrypt.Net.BCrypt.Verify(requestPassword, esistingPassword);
        }

        public string CheckPasswordValidation(string requestPassword)
        {
            return CheckPasswordStrength(requestPassword);
        }

        public string? EncryptPassword(string? password)
        { 
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<User> GetUserByEmailId(string emailId)
        {
            using var connection = _connection.CreateConnection();
            var query = $@"SELECT * FROM {PersistanceConstants.Tables.tblUser} WHERE Email= @EmailId";
            var parameters = new
            {
                EmailId = $"{emailId}"
            };
            var user = await connection.QueryFirstOrDefaultAsync<User>(query, parameters);
            return user;
        }

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if(password.Length<8)
            {
                sb.Append("Minimum password length should be 8"+Environment.NewLine);
            }
            if(!(Regex.IsMatch(password, "[a-z]")&&Regex.IsMatch(password, "[A-Z]")&&Regex.IsMatch(password, "[0-9]")))
            {
                sb.Append("Password should be Alphanumeric"+Environment.NewLine);
            }
            if(!(Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]")))
            {
                sb.Append("Password should contain special chars"+Environment.NewLine);
            }

            return sb.ToString();
        }

    }
}
