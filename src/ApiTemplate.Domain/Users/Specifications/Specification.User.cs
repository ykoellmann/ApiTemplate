namespace ApiTemplate.Domain.Users.Specifications;

public static class Specifications
{
    public static class User
    {
        public static UserIncludeAuthorizationSpecification IncludeAuthorization => new();
    }

    public static class UserDtos
    {
        public static UserNameDtoSpecification UserName => new();
    }
}