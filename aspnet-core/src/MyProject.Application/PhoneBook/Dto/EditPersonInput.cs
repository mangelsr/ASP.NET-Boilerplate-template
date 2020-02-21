using Abp.AutoMapper;

namespace MyProject.PhoneBook.Dto
{
    [AutoMapTo(typeof(Person))]
    public class EditPersonInput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
    }


    [AutoMapFrom(typeof(Person))]
    public class GetPersonForEditOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
    }

    public class GetPersonForEditInput
    {
        public int Id { get; set; }
    }
}
