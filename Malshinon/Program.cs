using Malshinon.DAL;
using Malshinon.Data;


namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepository = new PersonRepository();

            personRepository.Insert("isaac tunik", "soda");

            personRepository.FindOrCreateByName("")

      
        }
    }
}
