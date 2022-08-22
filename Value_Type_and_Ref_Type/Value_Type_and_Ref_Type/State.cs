using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Type_and_Ref_Type
{
    public struct State
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int Population { get; set; }
        public Country Country { get; set; }
    }
}
