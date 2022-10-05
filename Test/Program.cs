using NonVisualComponents.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnvisualComponents;
using UnvisualComponents.models;
using UserControlsTest;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDocument doc = new TextDocument();
            doc.CreateWordChart(@"C:\Users\admal\OneDrive\Рабочий стол\HomeWork\testDoc.docx", "Test Title", new string[] { "kjds.gnk;agjikro;fsagjors'a", "vksl;zbjkrf;ajbikfjl;dejakvbrfle;ajbkrvfl;sabnkjfl;abnkfl", "njdkwlaghjrkalghjnrkelagnjrfkela;ngjrkfel;agnjrkfa;lgnjvrkfa;nbjrkf" });

            TableDocument<Car> tableDocument = new TableDocument<Car>();
            List<CellInfo> keyValues = new List<CellInfo>();
            keyValues.Add(new CellInfo("NameInfo", 0, 2));
            keyValues.Add(new CellInfo("ProductionYear", 3));
            keyValues.Add(new CellInfo("Brand", 4));
            keyValues.Add(new CellInfo("Model", 5));
            tableDocument.CreateTableDocument(@"C:\Users\admal\OneDrive\Рабочий стол\HomeWork\testTab.docx", "title", keyValues, new int[] { 200, 500, 200 }, new string[] { "Brand", "Model", "ProductionYear" }, new Car[] { new Car("Lada", 2018, "Granta"), new Car("Volkswagen", 2010, "Tiguan"), new Car("Volvo", 2020, "C6") });

            new LinearChartDocument().CreateWordChart(@"C:\Users\admal\OneDrive\Рабочий стол\HomeWork\testChart.docx", "title", LegendLocation.Bottom, new List<List<ChartData>>() {
                new List<ChartData>() { 
                    new ChartData(){name = "s1", value = 4},
                    new ChartData(){name = "s2", value = 5},
                    new ChartData(){name = "s3", value = 7},
                    new ChartData(){name = "s4", value = 9}},
                new List<ChartData>(){
                    new ChartData(){name = "r1", value = 2},
                    new ChartData(){name = "r2", value = 9},
                    new ChartData(){name = "r3", value = 3},
                    new ChartData(){name = "r4", value = 6}}}, 
                new List<string>() { "first", "second" });
        }
    }
}
