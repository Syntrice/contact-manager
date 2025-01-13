using ContactManager.Logic;
using ContactManager.Model;
using ContactManager.Repository;
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
        public async Task CreateContactAsync_WithValidNames_ReturnsSuccess(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsController(repo.Object);
            var expected = ResponseType.Success;

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            response.Type.Should().Be(expected);

        }

        [TestCase("John")]
        [TestCase("John Smith")]
        [TestCase("John Smith Foo")]
        [TestCase("John Smith Foo Bar")]
        public async Task CreateContactAsync_WithValidNames_AddsContactToRepository(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsController(repo.Object);

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            repo.Verify(x => x.AddContact(It.IsAny<Contact>()), Times.Once);
            repo.Verify(x => x.SaveAsync(), Times.Once);
        }

        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task CreateContactAsync_WithTooLongName_ReturnsFailiure(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsController(repo.Object);
            var expected = ResponseType.Failiure;


            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            response.Type.Should().Be(expected);
        }

        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task CreateContactAsync_WithTooLongName_DoesNotAddContactToRepository(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsController(repo.Object);

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            repo.Verify(x => x.AddContact(It.IsAny<Contact>()), Times.Never);
            repo.Verify(x => x.SaveAsync(), Times.Never);
        }

        [TestCase("")]
        public async Task CreateContactAsync_WithEmptyString_ReturnsFailiure(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsController(repo.Object);
            var expected = ResponseType.Failiure;

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            response.Type.Should().Be(expected);
        }

        [TestCase("")]
        public async Task CreateContactAsync_WithEmptyString_DoesNotAddContactToRepository(string name)
        {
            // Arrange
            var repo = GetRepositoryMock();
            var logic = new ContactsController(repo.Object);

            // Act
            var response = await logic.CreateContactAsync(name);

            // Assert
            repo.Verify(x => x.AddContact(It.IsAny<Contact>()), Times.Never);
            repo.Verify(x => x.SaveAsync(), Times.Never);
        }

        [Test]
        public async Task GetContactsAsync_WithNonEmptyRepository_ReturnsSuccessWithValuesFromRepo()
        {
            // Arrange
            var repo = GetRepositoryMock();
            var contacts = new List<Contact>()
            {
                new Contact() {Name = "foo", ContactId = 0},
                new Contact() {Name = "bar", ContactId = 1},
            };
            repo.Setup(obj => obj.GetAllContactsAsync()).Returns(Task<List<Contact>>.FromResult(contacts.AsEnumerable()));
            var logic = new ContactsController(repo.Object);

            // Act
            var response = await logic.GetContactsAsync();

            // Assert
            response.Value.Should().BeEquivalentTo(contacts);
            response.Type.Should().Be(ResponseType.Success);
            repo.Verify(obj => obj.GetAllContactsAsync(), Times.Once);
        }

        [Test]
        public async Task GetContactsAsync_WithEmptyRepository_ReturnsFailiure()
        {
            // Arrange
            var repo = GetRepositoryMock();
            var contacts = new List<Contact>();
            repo.Setup(obj => obj.GetAllContactsAsync()).Returns(Task<List<Contact>>.FromResult(contacts.AsEnumerable()));
            var logic = new ContactsController(repo.Object);

            // Act
            var response = await logic.GetContactsAsync();

            // Assert
            response.Type.Should().Be(ResponseType.Failiure);
        }

        private Mock<IContactsRepository> GetRepositoryMock()
        {
            Mock<IContactsRepository> mock = new Mock<IContactsRepository>();
            return mock;
        }

    }
}
