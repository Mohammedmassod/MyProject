using Xunit;
using MyProject.Api.Controllers;
using MyProject.Application.Interfaces;
using MyProject.Application.DTO.User;
using Moq;
using MyProject.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IUserService> _userServiceMock;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOkResult()
        {
            // Arrange
            var users = new List<UserResponseDTO> { /* create your test user objects */ };
            _userServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.GetAllUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserResponseDTO>>(okResult.Value);
            Assert.Equal(users.Count, model.Count());
            // Add more assertions as needed
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetUserById_WithValidId_ReturnsOkResult(int id)
        {
            // Arrange
            var user = new UserResponseDTO { /* create your test user object */ };
            _userServiceMock.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<UserResponseDTO>(okResult.Value);
            Assert.Equal(user.Id, model.Id);
            // Add more assertions as needed
        }
    }
}