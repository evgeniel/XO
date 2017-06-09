using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using XO;
using System.Data;
using System.Data.SqlClient;

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

        public static bool AddStatistics(Statistcs stat)
        {
            //var conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=XO;Integrated Security=true");
            //var command = new SqlCommand();
            //command.Connection = conn;
            //command.CommandType = CommandType.Text;
            //command.CommandText = $"INSERT INTO Statistic(Date, Result, StepCounter, UserFirst) VALUES('{stat.Date}', '{stat.Result}', {stat.StepCounter}, '{stat.UserFirst}')";

            //try
            //{
            //    conn.Open();
            //    command.ExecuteNonQuery();
            //}
            //catch
            //{
            //    return false;
            //}
            //finally
            //{
            //    conn.Close();
            //}

            //return true;

            try
            {
                var filePath = "stats.json";

                var jsonData = File.ReadAllText(filePath);

                var statisticsList = JsonConvert.DeserializeObject<List<Statistcs>>(jsonData)
                                        ?? new List<Statistcs>();

                statisticsList.Add(stat);

                jsonData = JsonConvert.SerializeObject(statisticsList);
                File.WriteAllText(filePath, jsonData);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}