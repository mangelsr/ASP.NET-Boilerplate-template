using Abp.Application.Services.Dto;
using System.Threading.Tasks;

using MyProject.PhoneBook.Dto;

namespace MyProject.PhoneBook
{
    public interface IPersonAppService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);
        
        Task CreatePerson(CreatePersonInput input);

        Task DeletePerson(EntityDto input);

        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);

        Task DeletePhone(EntityDto<long> input);

        Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input);

        Task EditPerson(EditPersonInput input);


    }
}
