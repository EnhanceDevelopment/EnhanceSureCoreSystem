namespace EnhanceSure.Domain.Errors {
    public static class DomainErrors {
        public static class User {
            public static readonly string EmailAlreadyInUse = "The specified email is already in use.";
            public static readonly string UserNotFound = $"The user not found.";
            public static readonly string InvalidCredentials = $@"The provided credentials are invalid";
            public static readonly string LoggedInSucceed = $@"User loggedin successfully.";
        }
    }
}
