using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ChartData
    {
        public string[] xValues { get; set; }
        public double[] yValues { get; set; }
        public string seriesName;
    }
}