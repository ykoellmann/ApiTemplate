﻿using ApiTemplate.Application.Authentication.Commands.Register;
using ApiTemplate.Application.Common.Interfaces.Authentication;
using ApiTemplate.Application.Common.Interfaces.Persistence;
using ApiTemplate.Domain.Common.Errors;
using Moq;

namespace ApiTemplate.Application.UnitTests.Authentication.Commands;

public class RegisterCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly Mock<IJwtTokenProvider> _jwtTokenProvider = new();
    private readonly Mock<IRefreshTokenRepository> _refreshTokenRepository = new();

    [Fact]
    public async Task Handle_Should_ReturnError_WhenEmailExists()
    {
        //Arrange
        var command = new RegisterCommand("Test", "Test", "Test@Test.de", "test1234");

        var handler = new RegisterCommandHandler(_userRepository.Object, _jwtTokenProvider.Object,
            _refreshTokenRepository.Object);

        _userRepository.Setup(repository => 
            repository.IsEmailUniqueAsync(
                It.IsAny<string>()))
            .ReturnsAsync(false);
        //Act
        var result = await handler.Handle(command, default);

        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(Errors.User.UserWithGivenEmailAlreadyExists);
    }

    [Fact]
    public async Task Handle_Should_ReturnResult()
    {
        //Arrange
        var command = new RegisterCommand("Test", "Test", "Test@Test.de", "test1234");

        var handler = new RegisterCommandHandler(_userRepository.Object, _jwtTokenProvider.Object,
            _refreshTokenRepository.Object);

        _userRepository.Setup(repository => 
                repository.IsEmailUniqueAsync(
                    It.IsAny<string>()))
            .ReturnsAsync(true);
        //Act
        var result = await handler.Handle(command, default);

        //Assert   
        result.IsError.Should().BeFalse();
    }
}