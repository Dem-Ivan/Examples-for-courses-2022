using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericType_GenericMember.Models
{
    public interface IPerson
    {
        string Name { get; set; }
        int PhoneNumber { get; set; }
    }
}
