using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Data;
using Malshinon.Models;

namespace Malshinon.DAL
{
    public class ReportRepository
    {
        public void create(Person reporter,Person target,string txt)
        {

            string sql = $"INSERT INTO reports (ReporterId,TargetId,ReportText)" +
                         $"VALUES ('{reporter.Id}','{target.Id}','{txt}')";

            DBConnection.Execute(sql);
            Console.WriteLine($"the report of {reporter.FullName} insert to the DB");
        }
       
    }
}
