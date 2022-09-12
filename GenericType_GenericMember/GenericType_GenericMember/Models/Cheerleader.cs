using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericType_GenericMember.Models
{
    public class Cheerleader : IPerson
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
    }
}
