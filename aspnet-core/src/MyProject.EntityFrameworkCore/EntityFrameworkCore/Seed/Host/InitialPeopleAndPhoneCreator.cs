using System.Collections.Generic;
using System.Linq;

using MyProject.PhoneBook;


namespace MyProject.EntityFrameworkCore.Seed.Host
{
    public class InitialPeopleAndPhoneCreator
    {

        private readonly MyProjectDbContext _context;

        public InitialPeopleAndPhoneCreator(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Create() 
        {
            var miguel = _context.Persons.FirstOrDefault(prop => prop.EmailAddress == "mangelsr@live.com");
            if (miguel == null)
            {
                _context.Persons.Add(
                    new Person {
                        Name = "Miguel",
                        Surname = "Sanchez",
                        EmailAddress = "mangelsr@live.com",
                        Phones = new List<Phone>
                                    {
                                        new Phone { Type = PhoneType.Home, Number = "042692990" },
                                        new Phone { Type = PhoneType.Mobile, Number = "0986807904" },
                                    }
                    });
            }

            var angel = _context.Persons.FirstOrDefault(prop => prop.EmailAddress == "asssanchezg@hotmail.com");
            if (angel== null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Angel",
                        Surname = "Sanchez",
                        EmailAddress = "asssanchezg@hotmail.com",
                        Phones = new List<Phone>
                                    {
                                        new Phone { Type = PhoneType.Home, Number = "042692990" },
                                        new Phone { Type = PhoneType.Mobile, Number = "0999091364" },
                                    }
                    });
            }

            var paty = _context.Persons.FirstOrDefault(prop => prop.EmailAddress == "jpromeror@hotmail.com");
            if (paty == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Patricia",
                        Surname = "Romero",
                        EmailAddress = "jpromeror@hotmail.com",
                        Phones = new List<Phone>
                                    {
                                        new Phone { Type = PhoneType.Home, Number = "042692990" },
                                        new Phone { Type = PhoneType.Mobile, Number = "0999533635" },
                                    }
                    });
            }
        }
    }
}
