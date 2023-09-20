using ApiTemplate.Application.Authentication.Commands.Register;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using Moq;

namespace ApiTemplate.Application.UnitTests.Authentication.Commands;

public class RegisterCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IJwtTokenProvider> _jwtTokenProvider;
    private readonly Mock<IRefreshTokenRepository> _refreshTokenRepository;

    public RegisterCommandHandlerTests(Mock<IUserRepository> userRepository, Mock<IJwtTokenProvider> jwtTokenProvider,
        Mock<IRefreshTokenRepository> refreshTokenRepository)
    {
        _userRepository = userRepository;
        _jwtTokenProvider = jwtTokenProvider;
        _refreshTokenRepository = refreshTokenRepository;
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenPasswordIsTooShort()
    {
        //Arrange
        var command = new RegisterCommand("Test", "Test", "Test@Test.de", "test1234");

        var handler = new RegisterCommandHandler(_userRepository.Object, _jwtTokenProvider.Object,
            _refreshTokenRepository.Object);
        //Act
        var result = await handler.Handle(command, default);

        //Assert
    }
}