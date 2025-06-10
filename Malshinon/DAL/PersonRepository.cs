using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Malshinon.Data;
using Malshinon.Models;
using Mysqlx.Prepare;
using MySqlX.XDevAPI.Common;
using ZstdSharp.Unsafe;

namespace Malshinon.DAL
{
    public class PersonRepository
    {
        private Person? DictionaryToPerson(List<Dictionary<string, object?>> result)
        {
            if (result.Count == 0)
                return null;

            var row = result[0];
            return new Person
            {
                Id = Convert.ToInt32(row["id"]),
                FullName = row["FullName"]?.ToString(),
                SecretCode = row["SecretCode"]?.ToString(),
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }

        public Person? GetById(int id)
        {
            string sql = $"SELECT * FROM `people` WHERE id = {id}";

            var result = DBConnection.Execute(sql);

            return DictionaryToPerson(result);
        }

        public Person? GetByName(string name)
        {
            string sql = $"SELECT * FROM `people` WHERE FullName = {name}";

            var result = DBConnection.Execute(sql);

            return DictionaryToPerson(result);
        }

        public Person? GetBySecretCode(string secretCode)
        {
            string sql = $"SELECT * FROM `people` WHERE SecretCode = {secretCode}";

            var result = DBConnection.Execute(sql);

            return DictionaryToPerson(result);
        }

        public void Insert(string fullName, string secretCode)
        {
            string sql = "INSERT INTO people (FullName,SecretCode,CreatedAt)" +
                         $"VALUES ('{fullName}','{secretCode}','{DateTime.Now}')";
            
             DBConnection.Execute(sql);
            //need to Manage errors!!!

        }

        public Person FindOrCreateByName(string fullName)
        {
            var result = GetByName(fullName);
            if (result == null)
            {
                Console.WriteLine("enter secret name");
                string secretName = Console.ReadLine();
                Insert(fullName, secretName);
                result = GetByName(fullName);
            }
            return result;
        }

        public string? GetSecretCodeByName(string fullName)
        {
            var secretCode = "";
            string sql = $"SELECT SecretName FROM `people` WHERE FullName = {fullName}";

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
