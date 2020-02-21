using Abp.Runtime.Validation;
using MyProject.PhoneBook;
using MyProject.PhoneBook.Dto;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Tests.PhoneBook
{
    public class PersonAppService_Test: MyProjectTestBase
    {
        private readonly IPersonAppService _personAppService;
        public PersonAppService_Test()
        {
            _personAppService = Resolve<IPersonAppService>();
        }

        [Fact]
        public void Should_Get_All_People_Without_Any_Filter()
        {
            // Arrange

            //Act
            var persons = _personAppService.GetPeople(new GetPeopleInput());

            //Assert
            persons.Items.Count.ShouldBe(3);
        }

        [Fact]
        public void Should_Get_People_With_Filter()
        {
            // Arrange

            //Act
            var persons = _personAppService.GetPeople(
                new GetPeopleInput {
                    Filter = "Romero"
                });

            //Assert
            persons.Items.Count.ShouldBe(1);
            persons.Items[0].Name.ShouldBe("Patricia");
            persons.Items[0].Surname.ShouldBe("Romero");
        }

        [Fact]
        public async Task Should_Create_Person_With_Valid_Argument()
        {
            // Arrange

            //Act
            await _personAppService.CreatePerson(
                new CreatePersonInput
                {
                    Name = "John",
                    Surname = "Nash",
                    EmailAddress = "john.nash@gmail.com"
                });

            //Assert
            UsingDbContext(
                context =>
                {
                    var john = context.Persons.FirstOrDefault(p => p.EmailAddress == "john.nash@gmail.com");
                    john.ShouldNotBe(null);
                    john.Name.ShouldBe("John");
                });
        }

        [Fact]
        public async Task Should_Create_Person_With_Invalid_Argument()
        {
            // Arrange

            //Act and Assert
            await Assert.ThrowsAsync<AbpValidationException>(
                async () => await _personAppService.CreatePerson(new CreatePersonInput { Name = "John" })
            );

        }
    }
}
