using ApiTemplate.Application.Authentication.Common;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Errors;
using ApiTemplate.Domain.User;
using ErrorOr;
using MediatR;

namespace ApiTemplate.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenProvider jwtTokenProvider)
    {
        _userRepository = userRepository;
        _jwtTokenProvider = jwtTokenProvider;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        //Check if user exists
        if (await _userRepository.GetByEmail(command.Email) is not null) 
            return Errors.User.UserWithGivenEmailAlreadyExists;

        //Create user
        var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);
        await _userRepository.Add(user);

        //Generate token
        var token = _jwtTokenProvider.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}