using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericType_GenericMember.Models
{
    public class Trainer : IPerson
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string TeamName { get; set; } 
    }
}
