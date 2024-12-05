using BHF.MS.test15.Controllers;
using BHF.MS.test15.Models;
using BHF.MS.test15.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BHF.MS.test15.Tests.Controllers
{
    public class test15ControllerTests
    {
        private readonly Mock<ILogger<test15Controller>> _loggerMock = new();
        private readonly Mock<IExampleService> _exampleServiceMock = new();
        private readonly test15Controller _sut;

        public test15ControllerTests()
        {
            _sut = new test15Controller(_loggerMock.Object, _exampleServiceMock.Object);
        }

        [Fact]
        public async Task Get_LogsWarning()
        {
            // Arrange
            var message = new HttpResponseMessage();
            _exampleServiceMock.Setup(x => x.GetSomething()).ReturnsAsync(message);

            // Act
            var result = await _sut.Get();

            // Assert
            _loggerMock.VerifyLog(x => x.LogWarning("Responses {Response} are invalid!", message), Times.Once);
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Post_LogsWarning()
        {
            // Arrange
            var message = new HttpResponseMessage();
            var model = new ExampleModel { Title = "title", Email = "abc@abc.com", Phone = "123123123" };
            _exampleServiceMock.Setup(x => x.PostSomething(model)).ReturnsAsync(message);

            // Act
            var result = await _sut.Post(model);

            // Assert
            _loggerMock.VerifyLog(x => x.LogWarning("Responses {Response} are invalid!", message), Times.Once);
            result.Should().BeOfType<OkResult>();
        }
    }
}

