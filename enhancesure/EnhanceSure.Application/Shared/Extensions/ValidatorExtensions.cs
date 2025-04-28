using Dapper;
using EnhanceSure.Domain.Interfaces;
using FluentValidation;

namespace EnhanceSure.Application.Shared.Extensions {
    public static class ValidatorExtensions {
        public static IRuleBuilderInitial<T, TElement> DoesEmailExists<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IDbConnectionFactory dbConnectionFactory, string message = null)
        {
            return (IRuleBuilderInitial<T, TElement>)ruleBuilder.Custom((item, context) =>
            {
                if(context.PropertyPath!=null)
                {
                    var email = context.PropertyPath.ToLower() as string;
                    if(!string.IsNullOrEmpty(email))
                    {
                        var lowerEmail = email.ToLower();

                        var query = $@"SELECT * FROM tbl_Users where LOWER(Email)=@Email";
                        var connection = dbConnectionFactory.CreateConnection();

                        var count = connection.ExecuteScalar<int>(query, new { Email = lowerEmail });
                        if(count==0)
                        {
                            context.AddFailure(message??"Email not exists!");
                        }
                    }
                }
            });
        }

    }
}
