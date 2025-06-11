using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Data;
using Malshinon.Models;


namespace Malshinon.DAL
{
    public static class AlertRepository
    {
        public static int DictionaryToInt(List<Dictionary<string, object?>> result)
        {
            if (result.Count == 0)// check if person exist
            {
                throw new Exception("the ID not exist");
            }

            var row = result[0];

            return Convert.ToInt32(row["id"]);
        }



        public static bool CheckIfAlert(string targetId)
        {
            string sql = $"SELECT COUNT(*) FROM `reports` WHERE TargetId = '{targetId}'";

            var result = DBConnection.Execute(sql);

            int count = DictionaryToInt(result);

            return count > 20 ? true : false;
        }

        public static void insertAlert(string targetId)
        {
            if (CheckIfAlert(targetId))
            {

                string sql = $"INSERT INTO Reports (TargetId, WindowStart, WindowEnd, Reason)+" +
                             $"VALUES ({targetId}, '2025-06-11 08:00:00', '2025-06-11 20:00:00', 'Suspected of dangerous activity');";
                DBConnection.Execute(sql);
            }

            Console.WriteLine("the target not dangerous(lass the 20 reports)");
        }

    }
}
