using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialStatistic.Classes;

namespace SocialStatistic
{
    public partial class _Default : Page
    {
        protected void init(object sender, EventArgs e)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoadGroup_Click(object sender, EventArgs e)
        {
            Aggregator agr = new Aggregator();
            agr.process(TextBox1.Text);
            
            Analyzer analyzer = new Analyzer();
            
            string[] toDraw = analyzer.GetSexStatistics();
            
            Chart1.Series.Add("sex");
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(0.6, 1.4, "male");
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(1.6, 2.4, "female");
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(2.6, 3.4, "hide");
            foreach (string sex in toDraw)
            {
              Chart1.Series["sex"].Points.AddY(sex);
            }
            Dictionary<string, int> ageStats = analyzer.GetAgeStatistics();
            Chart2.Series.Add("age");
            Chart2.ChartAreas[0].AxisX.IntervalAutoMode = System.Web.UI.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            Chart2.ChartAreas[0].AxisX.Interval = 20;
            Chart2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;
            Chart2.ChartAreas[0].AxisX.IntervalOffset = 0;
            Chart2.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;
            foreach (KeyValuePair<string, int> age in ageStats)
            {
                if (age.Key != "hide")
                {
                    Chart2.Series["age"].Points.AddXY(Convert.ToDouble(age.Key), age.Value);
                }
               // else Chart2.Series["age"].Points.AddXY(0, age.Value);
            }
        }     

    }
}