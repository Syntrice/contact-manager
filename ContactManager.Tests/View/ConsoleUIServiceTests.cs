using ContactManager.ApplicationOptions;
using ContactManager.View;
using ContactManager.View.States;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace ContactManager.Tests.View
{
    [TestFixture]
    public class ConsoleUIServiceTests
    {
        // Dummy interfaces for testing
        public interface TestState1 : IState { }
        public interface TestState2 : IState { }
        public interface TestState3 : IState { }

        private Mock<IHostApplicationLifetime> _applicationLifetimeMock;
        private Mock<ILogger<ConsoleUIService>> _loggerMock;
        private List<Mock> _stateMocks;

        private Mock<IOptions<ConsoleUIOptions>> GetOptionsMock(ConsoleUIOptions options)
        {
            var optionsMock = new Mock<IOptions<ConsoleUIOptions>>();
            optionsMock.Setup(obj => obj.Value).Returns(options);
            return optionsMock;
        }

        private List<IState> GetStatesMockObjects()
        {
            return _stateMocks.Select(m => m.As<IState>().Object).ToList();
        }

        [SetUp]
        public void Init()
        {
            _stateMocks = new List<Mock> { new Mock<TestState1>(), new Mock<TestState2>(), new Mock<TestState3>() };
            _applicationLifetimeMock = new Mock<IHostApplicationLifetime>();
            _loggerMock = new Mock<ILogger<ConsoleUIService>>();
        }

        [Test]
        public async Task StartAsync_WithDifferentStartingStateTypes_ExecutesExpectedState([Values(0, 1, 2)] int i)
        {
            // Arrange
            var consoleUIOptions = new ConsoleUIOptions { StartingState = _stateMocks[i].Object.GetType() };
            var service = new ConsoleUIService(GetStatesMockObjects(), _applicationLifetimeMock.Object, _loggerMock.Object, GetOptionsMock(consoleUIOptions).Object);
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(10);

            // Act
            await service.StartAsync(cancellationTokenSource.Token);

            // Assert
            _stateMocks[i].As<IState>().Verify(x => x.Execute(service, It.IsAny<CancellationToken>()), Times.AtLeastOnce());
        }

        [Test]
        public void SetState_WhenStateTypeExists_SetsExpectedState([Values(0, 1, 2)] int i)
        {
            // Arrange
            var consoleUIOptions = new ConsoleUIOptions { StartingState = _stateMocks[0].Object.GetType() };
            var service = new ConsoleUIService(GetStatesMockObjects(), _applicationLifetimeMock.Object, _loggerMock.Object, GetOptionsMock(consoleUIOptions).Object);

            // Act
            service.SetState(_stateMocks[i].Object.GetType());

            // Assert
            service.CurrentState.Should().Be(_stateMocks[i].Object);
        }

        [Test]
        public void SetState_WhenStateTypeNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            List<Mock> stateMocks = new List<Mock>
            {
                new Mock<TestState1>(),
                new Mock<TestState2>()
            };
            var consoleUIOptions = new ConsoleUIOptions { StartingState = stateMocks[0].Object.GetType() };
            var service = new ConsoleUIService(GetStatesMockObjects(), _applicationLifetimeMock.Object, _loggerMock.Object, GetOptionsMock(consoleUIOptions).Object);

            // Act
            Action act = () => { service.SetState(typeof(TestState3)); };

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void SetState_WhenInvalidTypeGiven_ThrowsInvalidOperationException()
        {
            // Arrange
            var consoleUIOptions = new ConsoleUIOptions { StartingState = _stateMocks[0].Object.GetType() };
            var service = new ConsoleUIService(GetStatesMockObjects(), _applicationLifetimeMock.Object, _loggerMock.Object, GetOptionsMock(consoleUIOptions).Object);

            // Act
            Action act = () => { service.SetState(typeof(object)); };

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Stop_CallsAppLifetimeStopApplication()
        {
            // Arrange
            var consoleUIOptions = new ConsoleUIOptions { StartingState = _stateMocks[0].Object.GetType() };
            var service = new ConsoleUIService(GetStatesMockObjects(), _applicationLifetimeMock.Object, _loggerMock.Object, GetOptionsMock(consoleUIOptions).Object);

            // Act
            service.Stop();

            // Assert
            _applicationLifetimeMock.Verify(obj => obj.StopApplication(), Times.Once());
        }
    }
}