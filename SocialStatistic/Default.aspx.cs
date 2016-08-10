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
            Random rand = new Random();
            lab.Text = "load"+rand.Next(100);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Analyzer analyzer = new Analyzer();
            string[] toDraw = analyzer.GetSexStatistics();
            
            Chart1.Series.Add("sex");
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(0.6, 1.4, "male");
            Chart1.ChartAreas[0].AxisX.CustomLabels.Add(1.6, 2.4, "female");
            
            foreach (string sex in toDraw)
            {
              Chart1.Series["sex"].Points.AddY(sex);
            }
        }     

        protected void Button3_Click(object sender, EventArgs e)
        {
            Aggregator agr = new Aggregator();
            agr.process(TextBox1.Text);
        }

    }
}