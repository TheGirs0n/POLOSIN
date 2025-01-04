using System.Data;
using System.Diagnostics;
using System.Windows;

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
        public Graphs()
        {
            InitializeComponent();
            Init();
            DrawAllGraphs();
        }

        private void DrawAllGraphs()
        {
            timer!.Stop();
        }

        private void Init()
        {
            timer = new Stopwatch();
            timer.Start();

            concentrationDataTable = new DataTable();

            timer.Stop();
            //totalMemoryUsed = GC.GetTotalMemory(false) / (1024 * 1024); # Строка, для подсчета памяти
        }
    }
}
