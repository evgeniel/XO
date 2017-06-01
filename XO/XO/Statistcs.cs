using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace XO
{
    [DataContract]
    public class Statistcs
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public GameState Result { get; set; }

        [DataMember]
        public int StepCounter { get; set; }

        [DataMember]
        public bool UserFirst { get; set; }
    }
}
