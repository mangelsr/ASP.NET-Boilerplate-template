using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.ObjectModel;

namespace MyProject.PhoneBook.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListDto> Phones { get; set; }
    }

    [AutoMapFrom(typeof(Phone))]
    public class PhoneInPersonListDto : FullAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }

        public string Number { get; set; }
    }


}
