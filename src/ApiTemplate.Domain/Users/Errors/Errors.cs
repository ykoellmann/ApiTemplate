using ErrorOr;

namespace ApiTemplate.Domain.Users.Errors;

public partial class Errors
{
    public class Idempotent
    {
        public static Error RequestAlreadyProcessed =>
            Error.Conflict("Idempotent.RequestAlreadyProcessed", "Request has already been processed");
        
        public static Error RequestIdInvalid =>
            Error.Conflict("Idempotent.RequestIdInvalid", "Request id has to be a valid guid");
        
        public static Error RequestIdMissing =>
            Error.Validation("Idempotent.RequestIdMissing", "Request id X-Request-Id is missing");
    }
}