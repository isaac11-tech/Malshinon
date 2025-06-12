
using Malshinon.Data;
using Malshinon.Models;

namespace Malshinon.DAL
{
    public static class PersonRepository
    {
        private static Person? DictionaryToPerson(List<Dictionary<string, object?>> result)//convert from Dictionary to string
        {
            if (result.Count == 0)// check if person exist
            {
                Console.WriteLine("the person not exist");
                return null;
            }


            var row = result[0];
            
            
                return new Person
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FullName = row["FullName"]?.ToString(),
                    SecretCode = row["SecretCode"]?.ToString(),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                };
            
            
           
        }

        public static Person? GetById(string? id)
        {
            string sql = $"SELECT * FROM `people` WHERE id = '{id}'";

            var result = DBConnection.Execute(sql);

            return DictionaryToPerson(result);
        }

        public static Person? GetByName(string name)
        {

            string sql = $"SELECT * FROM `people` WHERE FullName = '{name}' LIMIT 1";//need to fix

            var result = DBConnection.Execute(sql);

            return DictionaryToPerson(result);
        }


        public static Person? GetBySecretCode(string secretCode)
        {
            string sql = $"SELECT * FROM `people` WHERE SecretCode = '{secretCode}'";

            var result = DBConnection.Execute(sql);

            return DictionaryToPerson(result);
        }



        public static bool FullNameCodeExists(string fullName)
        {
            string sql = $"SELECT * FROM `people` WHERE FullName = '{fullName}'";
            var result = DBConnection.Execute(sql);
            return result.Count > 0;
        }

        public static bool SecretCodeExists (string secretCode)
        {
            string sql = $"SELECT * FROM `people` WHERE SecretCode = '{secretCode}'";
            var result = DBConnection.Execute(sql);
            return result.Count > 0;
        }


        public static void Insert(string fullName, string secretCode)
        {
            string sql = "INSERT INTO people (FullName,SecretCode)" +
                         $"VALUES ('{fullName}','{secretCode}')";

            if (FullNameCodeExists(fullName))
            {
                throw new Exception("fullName already exists");
            }

            if (SecretCodeExists(secretCode))
            {
                throw new Exception("secretCode already exists");
            }

            DBConnection.Execute(sql);
            Console.WriteLine($"{fullName} insert to the DB");
        }

        public static Person GetOrCreateByName(string fullName)
        {

            if (FullNameCodeExists(fullName))// if all ready exist return the person
            {
                return GetByName(fullName);
            }

            Console.WriteLine("enter secret name");
            string secretName = Console.ReadLine();

            if (SecretCodeExists(secretName) || secretName == null)// i add for null
            {
                Console.WriteLine("This secret name already exists. Please try again.");
                return null;
            }
            Insert(fullName, secretName);

            return GetByName(fullName); ;
        }



        public static string? GetSecretCodeByName(string fullName)
        {
            var secretCode = "";
            string sql = $"SELECT SecretCode FROM `people` WHERE FullName = '{fullName}'";


            var result = DBConnection.Execute(sql);

            if (result.Count > 0)
            {
                var row = result[0];
                secretCode = row["SecretCode"]?.ToString();
            }
            else
            {
                Console.WriteLine("No results found.");
            }

            return secretCode;
        }
    }
}
