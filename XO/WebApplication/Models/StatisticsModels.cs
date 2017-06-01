using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using XO;

namespace WebApplication.Models
{
    public class StatisticsModels
    {
        public List<Statistcs> StatisticsList { get; set; }

        public StatisticsModels()
        {
            var jsonData = File.ReadAllText(@"C:\Users\EvgenieL\Source\Repos\XO\XO\XO\bin\Debug\stats.json");
            StatisticsList = JsonConvert.DeserializeObject<List<Statistcs>>(jsonData);

        }
    }
}