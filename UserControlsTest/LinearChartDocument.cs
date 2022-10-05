using System;
using System.ComponentModel;
using Xceed.Words.NET;
using UnvisualComponents.models;
using System.Collections.Generic;
using UserControlsTest;
using Xceed.Document.NET;

namespace UnvisualComponents
{
    public class LinearChartDocument
    {
        public void CreateWordChart(string path, string documentName, LegendLocation legendLocation, List<List<ChartData>> data, List<string> seriesName)
        {
            if(string.IsNullOrEmpty(path) || string.IsNullOrEmpty(documentName) || data.Count < 1)
            {
                throw new Exception("Input data has empty fields");
            }

            using (var document = DocX.Create(path))
            {
                document.InsertParagraph(documentName).FontSize(35).SpacingAfter(50d).Bold().Alignment = Alignment.center;
                ChartLegendPosition pos = ChartLegendPosition.Bottom;
                switch (legendLocation)
                {
                    case LegendLocation.Top:
                        pos = ChartLegendPosition.Top;
                        break;
                    case LegendLocation.Left:
                        pos = ChartLegendPosition.Left;
                        break;
                    case LegendLocation.Right:
                        pos = ChartLegendPosition.Right;
                        break;
                }
                var lineChart = document.AddChart<LineChart>();
                lineChart.AddLegend(pos, false);
                for (int i = 0; i < seriesName.Count; i++)
                {
                    Series series = new Series(seriesName.ToArray()[i]);
                    series.Bind(data.ToArray()[i], "name", "value");
                    lineChart.AddSeries(series);
                }
     
                document.InsertChart(lineChart);
                document.Save();
            }
        }
    }
}
