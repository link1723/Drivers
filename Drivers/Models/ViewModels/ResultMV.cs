using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drivers.Models.ViewModels
{
    public class ResultMV
    {
        public string Name { get; set; }
        public int Miles { get; set; }
        public int MilesPerHour { get; set; }
        public double TotalMiles { get; set; }
        public double TotalHours { get; set; }
        public ResultMV(string name, int miles, int milesPerHour)
        {
            Name = name;
            Miles = miles;
            MilesPerHour = milesPerHour;
        }
    }
}