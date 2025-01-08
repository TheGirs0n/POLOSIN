using DocumentFormat.OpenXml.InkML;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using POLOSIN_3_PR.Math_Folder;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
                    Stroke = new SolidColorBrush(Color.FromRgb((byte)(i * 40), 104, (byte)(212 * i))),
                    Fill = new SolidColorBrush(Color.FromArgb(0, 169, 209, 209)),
                    StrokeThickness = 3,
                    PointGeometrySize = 3,
                };
                for (int j = 0; j < _results.ElementAt(i).Value.Count; j++)
                {
                    var dotX = Math.Round(_results.ElementAt(i).Value[j], 5);
                    var dotY = _results.ElementAt(_results.Count - 1).Value[j];

                    series.Values.Add(new ObservablePoint(dotY, dotX));   
                }
                series.Title = $"{_results.ElementAt(i).Key}";
                ConcentrationGraphs.Series.Add(series);
            }

            timer!.Stop();
            totalMemoryUsed = GC.GetTotalMemory(false) / (1024 * 1024);

            GetParameters();
        }

        private void Init()
        {
            timer = null;
            totalMemoryUsed = 0;

            timer = new Stopwatch();
            timer.Start();

            concentrationDataTable = new DataTable();
            // Добавляем столбец для времени
            concentrationDataTable.Columns.Add("Время");

            // Добавляем столбцы для каждого компонента (исключая "time")
            foreach (var key in _results.Keys)
            {
                if (key != "time")
                {
                    concentrationDataTable.Columns.Add(key);
                }
            }

            // убрал описание колонок именно DataGRID, поскольку шел конфликт с колонками DataTABLE

            // Заполняем DataTable данными
            for (int i = 0; i < _results["time"].Count; i++)
            {
                var newRow = concentrationDataTable.NewRow();
                newRow["Время"] = _results["time"][i]; // Время

                // Добавляем значения для каждого компонента
                foreach (var key in _results.Keys)
                {
                    if (key != "time")
                    {
                        newRow[key] = Math.Round(_results[key][i], 5);                      
                    }
                }

                concentrationDataTable.Rows.Add(newRow);
            }

            ConcentrationDataGrid.ItemsSource = concentrationDataTable.DefaultView;
        }
        private void GetParameters()
        {
            ElapsedTimeTextBox.Text = timer!.ElapsedMilliseconds.ToString(); // время в миллисекундах
            MemoryUsedTextBox.Text = (totalMemoryUsed).ToString();
        }
        private void GetDocument_Click(object sender, RoutedEventArgs e)
        {
            var temperature = MainWindow.GetTemperature();
            var processTime = MainWindow.GetProcessTime();
            var processTimeStep = MainWindow.GetProcessTimeStep();

            SaveToDocument saveToDocument = new SaveToDocument();
            saveToDocument.SaveToDocumentExcel(concentrationDataTable!, temperature, processTime, processTimeStep, timer!.ElapsedMilliseconds, totalMemoryUsed);
        }
    }
}
