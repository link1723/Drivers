using Drivers.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Drivers.Models
{
    public class HomeModel
    {
        public static List<ResultMV> ProcesFile(byte[] file)
        {
            List<ResultMV> result = new List<ResultMV>();
            var streamReader = new StreamReader(new MemoryStream(file));
            while(streamReader.Peek() >= 0)
            {
                string line = streamReader.ReadLine();
                string[] commands = line.Split(' ');
                if(commands[0] == "Driver")
                {
                    bool exists = result.Where(f => f.Name == commands[1]).Any();
                    if (!exists)
                    {
                        result.Add(new ResultMV(commands[1], 0, 0));
                    }
                }
                else if(commands[0] == "Trip")
                {
                    string driver = commands[1];
                    string[] start = commands[2].Split(':');
                    string[] end = commands[3].Split(':');
                    double miles = Convert.ToDouble(commands[4]);
                    TimeSpan timeSpanStart = new TimeSpan(Convert.ToInt32(start[0]), Convert.ToInt32(start[1]), 0);
                    TimeSpan timeSpanEnd = new TimeSpan(Convert.ToInt32(end[0]), Convert.ToInt32(end[1]), 0);
                    TimeSpan timeSpanResult = timeSpanEnd - timeSpanStart;
                    double mph = miles/timeSpanResult.TotalHours;
                    if(mph > 5 || mph < 100)
                    {
                        bool exists = result.Where(f => f.Name == driver).Any();
                        if (exists)
                        {
                            var driverItem = result.Where(f => f.Name == driver).Single();
                            driverItem.TotalMiles += miles;
                            driverItem.TotalHours += timeSpanResult.TotalHours;
                        }
                        
                    }
                }
            }

            foreach (var item in result)
            {
                item.Miles = Convert.ToInt32(Math.Round(item.TotalMiles));
                if(item.TotalHours > 0)
                {
                    double mph = item.TotalMiles / item.TotalHours;
                    item.MilesPerHour = Convert.ToInt32(Math.Round(mph));
                }
            }

            return result.OrderByDescending(f => f.Miles).ToList();
        }
    }
}