using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class XOException : Exception
    {
        public int col { get; set; }
        public int row { get; set; }
    }
}
