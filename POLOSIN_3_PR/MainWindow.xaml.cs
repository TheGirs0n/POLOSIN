using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.UI_AdditionalWindows;
using POLOSIN_3_PR.UI_Methods;
using System.Windows;
using System.Windows.Controls;

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
        private void GetComponentsAndConcentration()
        {
            string component = "";
            float concentration = 0;
            
            Components!.Clear();

            foreach (var item in ComponentsStackPanel.Children)
            {
                var stackPanel = (Border)item;
                StackPanel child = (StackPanel)stackPanel.Child;
                var collection = child.Children;

                for (int i = 1; i < collection.Count; i+=2)
                {
                    if (i == 1)
                    {
                        var textBoxComponent = (TextBox)collection[i];
                        component = textBoxComponent.Text;
                    }
                    else
                    {
                        var textBoxConcentration = (TextBox)collection[i];
                        concentration = float.Parse(textBoxConcentration.Text);
                    }
                }
                var componentClass = new ComponentClass(component, concentration);
                Components!.Add(componentClass);
            } 
        }
        private void AddChemicalEquation_Click(object sender, RoutedEventArgs e)
        {
            if (ComponentsStackPanel.Children!.Count > 0)
            {
                GetComponentsAndConcentration();
                AddChemicalEquation addChemicalEquation = new AddChemicalEquation();
                addChemicalEquation.Show();
                addChemicalEquation.Owner = this;
            }
            else
                Logger.PrintMessageAsync("Сначала введите компоненты", MessageBoxImage.Information);
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