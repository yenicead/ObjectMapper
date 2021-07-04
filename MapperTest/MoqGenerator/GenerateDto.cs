using MapperConsole.DTOs;

namespace MapperTest.MoqGenerator
{
    public static class GenerateDto
    {
        public static AddressDTO NewAddress()
        {
            return new AddressDTO();
        }

        public static EmployeeDTO NewEmployee()
        {
            return new EmployeeDTO();
        }

        public static PersonDTO NewPerson()
        {
            return new PersonDTO();
        }
    }
}
