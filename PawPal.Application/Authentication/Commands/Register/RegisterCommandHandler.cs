using ErrorOr;
using MediatR;
using PawPal.Application.Authentication.Common;
using PawPal.Application.Common.Interfaces.Authentication;
using PawPal.Application.Common.Interfaces.Persistence;
using PawPal.Domain.Common.Errors;
using PawPal.Domain.User;

namespace PawPal.Application.Authentication.Commands.Register;

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