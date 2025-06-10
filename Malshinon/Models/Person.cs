using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string SecretCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
