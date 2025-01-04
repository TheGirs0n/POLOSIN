using LiveCharts.Defaults;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.Windows.Media;

namespace POLOSIN_3_PR.Math_Folder
{
    public class DrawGraphs
    {
        /// <summary>
        /// Отрисовка графика компонента component
        /// </summary>
        /// <param name="component">Компонент</param>
        /// <param name="componentValues">Значения компонента для графика</param>
        public void DrawGraphics(string component, ObservableCollection<float> componentValues,
            ObservableCollection<float> time, CartesianChart MyChart) 
        {
            var series = new LineSeries
            {
                Values = new ChartValues<ObservablePoint>(),
                Stroke = new SolidColorBrush(Color.FromRgb(33, 104, 212)),
                Fill = new SolidColorBrush(Color.FromArgb(0, 169, 209, 209)),
                StrokeThickness = 3,
                PointGeometrySize = 7,
            };
            MyChart.AxisX.Add(new Axis { Title = "Координата по длине канала, м", Foreground = Brushes.Black });

            for (int i = 0; i < componentValues.Count; i++)
            {
                series.Values.Add(new ObservablePoint(Math.Round(time[i], 2), Math.Round(componentValues[i], 2)));
            }

            MyChart.Series.Clear();
            MyChart.Series.Add(series);
        }
    }
}
