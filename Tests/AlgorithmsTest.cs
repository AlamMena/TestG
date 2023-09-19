using API.Controllers;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace YourApi.Tests.Controllers
{
    public class AlgorithmsTest
    {
        [Fact]
        public async Task GetPattern_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new PatternRequest
            {
                Phrase = "Valid phrase",
                RequestDate = DateTime.Now,
                User = 1
            };
            string pattern = "TestPattern";

            var algorithmsServiceMock = new Mock<IAlgorithmsService>();
            algorithmsServiceMock.Setup(s => s.GetPattern(request.Phrase)).Returns(pattern);

            var loggingServiceMock = new Mock<ILogginService>();

            var controller = new AlgorithmsController(algorithmsServiceMock.Object, loggingServiceMock.Object);

            // Act
            IActionResult result = await controller.GetPattern(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetPattern_ExceptionThrown_ReturnsBadRequest()
        {
            // Arrange
            var request = new PatternRequest
            {
                Phrase = "Valid phrase",
                RequestDate = DateTime.Now,
                User = 1
            };
            Exception testException = new Exception("Test Exception");

            var algorithmsServiceMock = new Mock<IAlgorithmsService>();
            algorithmsServiceMock.Setup(s => s.GetPattern(request.Phrase)).Throws(testException);

            var loggingServiceMock = new Mock<ILogginService>();

            var controller = new AlgorithmsController(algorithmsServiceMock.Object, loggingServiceMock.Object);

            // Act
            IActionResult result = await controller.GetPattern(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);

            var response = Assert.IsType<string>(badRequestResult.Value);
            Assert.Equal(testException.Message, response);

            algorithmsServiceMock.Verify(s => s.GetPattern(request.Phrase), Times.Once);
        }

        [Fact]
        public async Task GetPattern_NullPhrase_ReturnsBadRequest()
        {
            // Arrange
            // Arrange
            var request = new PatternRequest
            {
                Phrase = "",
                RequestDate = DateTime.Now,
                User = 1
            };

            var algorithmsServiceMock = new Mock<IAlgorithmsService>();
            var loggingServiceMock = new Mock<ILogginService>();

            var controller = new AlgorithmsController(algorithmsServiceMock.Object, loggingServiceMock.Object);

            // Act
            IActionResult result = await controller.GetPattern(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);

            var response = Assert.IsType<string>(badRequestResult.Value);
            Assert.Equal("Invalid input", response);
        }



    }
}
