using DocumentFormat.OpenXml.InkML;
using LiveCharts;
using LiveCharts.Wpf;
using POLOSIN_3_PR.Math_Folder;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace POLOSIN_3_PR.UI_AdditionalWindows
{
    /// <summary>
    /// Логика взаимодействия для Graphs.xaml
    /// </summary>
    public partial class Graphs : Window
    {
        private DataTable? concentrationDataTable;
        private Stopwatch? timer;
        private long totalMemoryUsed;
        private Dictionary<string, List<double>> _results;

        public Graphs(Dictionary<string, List<double>> Results)
        {
            InitializeComponent();
            _results = Results;
            Init();
            DrawAllGraphs();

        }

        private void DrawAllGraphs()
        {
            ConcentrationGraphs.Series.Clear();
            ConcentrationGraphs.AxisX.Clear();
            ConcentrationGraphs.AxisY.Clear();

            ConcentrationGraphs.AxisX.Add(new Axis { Title = "Время, С", Foreground = Brushes.Black });
            ConcentrationGraphs.AxisY.Add(new Axis { Title = "Концентрация, моль/л", Foreground = Brushes.Black });

            timer!.Stop();
            totalMemoryUsed = GC.GetTotalMemory(false) / (1024 * 1024);

            foreach (var component in _results)
            {
                var lineSeries = new LineSeries()
                {
                    Title = component.Key,
                    Values = new ChartValues<double>(component.Value)
                };
                ConcentrationGraphs.Series.Add(lineSeries);
            }

        }

        private void Init()
        {
            timer = new Stopwatch();
            timer.Start();

            concentrationDataTable = new DataTable();

            timer.Stop();
        }

        private void GetDocument_Click(object sender, RoutedEventArgs e)
        {
            var temperature = MainWindow.GetTemperature();
            var processTime = MainWindow.GetProcessTime();
            var processTimeStep = MainWindow.GetProcessTimeStep();

            SaveToDocument saveToDocument = new SaveToDocument();
            saveToDocument.SaveToDocumentExcel(concentrationDataTable!, temperature, processTime, processTimeStep);

        }
    }
}
