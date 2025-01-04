using ContactManager.Data.Model;
using ContactManager.Data.Repository;
using ContactManager.Logic;
using FluentAssertions;
using Moq;

namespace ContactManager.Tests.Logic
{
    [TestFixture]
    public class ContactsLogicTests
    {
        [TestCase("John")]
        [TestCase("John Smith")]
        [TestCase("John Smith Foo")]
        [TestCase("John Smith Foo Bar")]
        public async Task CreateContactAsync_WithValidNames_ReturnsSuccessResponse(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsLogic(repo.Object);
            var expected = ResponseType.Success;

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            response.ResponseType.Should().Be(expected);

        }

        [TestCase("John")]
        [TestCase("John Smith")]
        [TestCase("John Smith Foo")]
        [TestCase("John Smith Foo Bar")]
        public async Task CreateContactAsync_WithValidNames_AddsContactToRepository(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsLogic(repo.Object);

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            repo.Verify(x => x.AddContact(It.IsAny<Contact>()), Times.Once);
            repo.Verify(x => x.SaveAsync(), Times.Once);
        }

        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task CreateContactAsync_WithTooLongName_ReturnsFailiureResponse(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsLogic(repo.Object);
            var expected = ResponseType.Failiure;


            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            response.ResponseType.Should().Be(expected);
        }

        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task CreateContactAsync_WithTooLongName_DoesNotAddContactToRepository(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsLogic(repo.Object);

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            repo.Verify(x => x.AddContact(It.IsAny<Contact>()), Times.Never);
            repo.Verify(x => x.SaveAsync(), Times.Never);
        }

        [TestCase("")]
        public async Task CreateContactAsync_WithEmptyString_ReturnsFailiureResponse(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsLogic(repo.Object);
            var expected = ResponseType.Failiure;

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            response.ResponseType.Should().Be(expected);
        }

        [TestCase("")]
        public async Task CreateContactAsync_WithEmptyString_DoesNotAddContactToRepository(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsLogic(repo.Object);

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            repo.Verify(x => x.AddContact(It.IsAny<Contact>()), Times.Never);
            repo.Verify(x => x.SaveAsync(), Times.Never);
        }

        private Mock<IContactsRepository> GetRepositoryMock()
        {
            Mock<IContactsRepository> mock = new Mock<IContactsRepository>();
            return mock;
        }

    }
}
