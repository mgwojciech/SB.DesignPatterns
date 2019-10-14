using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Builder
{
    public class ComposedBuilder : ReportBuilder
    {
        List<ReportBuilder> Builders { get; set; }
        public ComposedBuilder(List<ReportBuilder> builders)
        {
            Builders = builders;
        }

        public override void SetColumns()
        {
            foreach(ReportBuilder builder in Builders)
                builder.SetColumns();
        }
        public override void GetData()
        {

            foreach (ReportBuilder builder in Builders)
                builder.GetData();
        }
        public override void ProcessData()
        {
            foreach (ReportBuilder builder in Builders)
                builder.ProcessData();
        }
    }
}
