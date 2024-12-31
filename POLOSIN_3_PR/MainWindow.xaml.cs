using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.UI_Methods;
using System.Windows;

namespace POLOSIN_3_PR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<ChemicalEquation>? _chemicalEquations = new();
        private static List<ComponentClass>? _components = new();
        public static List<ChemicalEquation>? ChemicalEquations
        {
            get => _chemicalEquations;
            set => _chemicalEquations = value;
        }
        public static List<ComponentClass>? Components
        {
            get => _components;
            set => _components = value;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddChemicalEquation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveChemicalEquation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddComponent_Click(object sender, RoutedEventArgs e)
        {
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel);
        }

        private void RemoveComponent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetKineticButton_Click(object sender, RoutedEventArgs e)
        {
            if (TemperatureTextBox.Text != string.Empty && TempTimeTextBox.Text != string.Empty
                && TimeTextBox.Text != string.Empty)
            {

            }
            else
                Logger.PrintMessageAsync("Заполните все варьируемые параметры", MessageBoxImage.Error);
        }
    }
}