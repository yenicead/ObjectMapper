using MapperConsole.Entities;

namespace MapperTest.MoqDataGenerator
{
    public static class EntityGenerator
    {
        public static Address NewAddress()
        {
            return new Address();
        }

        public static Employee NewEmployee()
        {
            return new Employee();
        }

        public static Person NewPerson()
        {
            return new Person();
        }
    }
}
