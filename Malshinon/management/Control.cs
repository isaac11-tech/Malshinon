using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.DAL;
using Malshinon.Models;

namespace Malshinon.management
{
    public static class Control
    {  
        public static void SubmitReport(string reporterName,string targetName,string txt)
        {
            Person reporter = PersonRepository.GetOrCreateByName(reporterName);
            Person target = PersonRepository.GetOrCreateByName(targetName);
            ReportRepository.create(reporter, target, txt);

        }
    }
}
