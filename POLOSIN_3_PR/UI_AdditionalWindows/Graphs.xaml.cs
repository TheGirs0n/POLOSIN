using DocumentFormat.OpenXml.InkML;
using LiveCharts;
using LiveCharts.Defaults;
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

            ConcentrationGraphs.AxisX.Add(new Axis { Title = "Время, мин", Foreground = Brushes.Black });
            ConcentrationGraphs.AxisY.Add(new Axis { Title = "Концентрация, моль/л", Foreground = Brushes.Black });

            for (int i = 0; i < _results.Count - 1; i++)
            {
                var series = new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>(),
                    Stroke = new SolidColorBrush(Color.FromRgb((byte)(i * 33), 104, 212)),
                    Fill = new SolidColorBrush(Color.FromArgb(0, 169, 209, 209)),
                    StrokeThickness = 3,
                    PointGeometrySize = 3,
                };
                for (int j = 0; j < _results.ElementAt(i).Value.Count; j++)
                {
                    var dotX = _results.ElementAt(i).Value[j];
                    var dotY = _results.ElementAt(_results.Count - 1).Value[j];

                    series.Values.Add(new ObservablePoint(dotY, dotX));   
                }
                ConcentrationGraphs.Series.Add(series);
            }

            timer!.Stop();
            totalMemoryUsed = GC.GetTotalMemory(false) / (1024 * 1024);
        }

        private void Init()
        {
            timer = new Stopwatch();
            timer.Start();

            concentrationDataTable = new DataTable();
        }
        private void GetParameters()
        {
            ElapsedTimeTextBox.Text = (timer!.ElapsedMilliseconds / 1000).ToString();
            MemoryUsedTextBox.Text = (totalMemoryUsed).ToString();
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
