using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    static class Serializer
    {
        public static void SetData(string filePath, List<Statistcs> data)
        {
            var xs = new DataContractJsonSerializer(typeof(List<Statistcs>));

            using (var sw = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                xs.WriteObject(sw, data);
            }
        }
        public static List<Statistcs> GetData(string filePath)
        {
            var xs = new DataContractJsonSerializer(typeof(List<Statistcs>));

            using (var sr = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return xs.ReadObject(sr) as List<Statistcs>;
            }
        }
    }
}
