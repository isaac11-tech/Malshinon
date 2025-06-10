using Malshinon.DAL;
using Malshinon.Data;
using Malshinon.Models;


namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepository = new PersonRepository();
            ReportRepository reportRepository = new ReportRepository();

            Person r = personRepository.GetOrCreateByName("chaim");
            Person t = personRepository.GetOrCreateByName("isaac mnor");
            reportRepository.create(r, t,"hi its my first report");
            //personRepository.Insert("chaim", "777");
            //personRepository.Insert("isaac mnor", "100");


        }
    }
}
