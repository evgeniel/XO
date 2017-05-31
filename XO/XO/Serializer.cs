using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XO
{
    static class Serializer
    {
        public static List<Statistcs> GetData(string filePath)
        {
            var xs = new XmlSerializer(typeof(List<Statistcs>));

            using (var sr = new StreamReader(filePath))
            {
                return xs.Deserialize(sr) as List<Statistcs>;
            }
        }

        public static void SetData(string filePath, List<Statistcs> data)
        {
            var xs = new XmlSerializer(typeof(List<Statistcs>));

            using (var sw = new StreamWriter(filePath))
            {
                xs.Serialize(sw, data);
            }
        }
    }
}
