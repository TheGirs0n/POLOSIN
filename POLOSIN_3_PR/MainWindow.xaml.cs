using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.Classes_Folder;
using POLOSIN_3_PR.Math_Folder;
using POLOSIN_3_PR.UI_AdditionalWindows;
using POLOSIN_3_PR.UI_Methods;
using System.Collections.ObjectModel;
using System.Windows;

namespace POLOSIN_3_PR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<ChemicalEquation>? _chemicalEquations;
        public static ObservableCollection<ComponentClass>? _components;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCollections();
        }

        private void InitializeCollections()
        {
            _chemicalEquations = new();
            _chemicalEquations.CollectionChanged += _chemicalEquations_CollectionChanged;
            _components = new();
        }
            
        private void AddChemicalEquation_Click(object sender, RoutedEventArgs e)
        {
            if (ComponentsStackPanel.Children!.Count > 0)
            {
                ModifyComponentGroupBox.GetComponentsAndConcentration(components: _components!, ComponentsStackPanel);
                if (_components!.Count > 0)
                {
                    AddChemicalEquation addChemicalEquation = new AddChemicalEquation();
                    addChemicalEquation.Show();
                    addChemicalEquation.Owner = this;
                }               
            }
            else
                Logger.PrintMessageAsync("Сначала введите компоненты", MessageBoxImage.Information);
        }

        private void RemoveChemicalEquation_Click(object sender, RoutedEventArgs e)
        {
            if (ChemicalEquationsStackPanel.Children!.Count > 1)
                ModifyChemicalEquationGroupBox.RemoveChemicalEquation(ChemicalEquationsStackPanel, _chemicalEquations);
            else
                Logger.PrintMessageAsync("Нет химических реакций для удаления", MessageBoxImage.Error);
        }

        private void AddComponent_Click(object sender, RoutedEventArgs e)
        {
            _components!.Add(new ComponentClass("", 0));
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel);
        }

        private void RemoveComponent_Click(object sender, RoutedEventArgs e)
        {
            if (ComponentsStackPanel!.Children.Count > 0)
                ModifyComponentGroupBox.RemoveComponent(ComponentsStackPanel, _components!);
            else
                Logger.PrintMessageAsync("Нет компонентов для удаления", MessageBoxImage.Error);
        }

        private void GetKineticButton_Click(object sender, RoutedEventArgs e)
        {
            if (TemperatureTextBox.Text != string.Empty && TempTimeTextBox.Text != string.Empty
                && TimeTextBox.Text != string.Empty && _components!.Count > 0 && _chemicalEquations!.Count > 0)
            {
                KineticCalculate kineticCalculate = new KineticCalculate();
                kineticCalculate.CalculateKinetic(chemicalEquations: _chemicalEquations, components: _components);
            }
            else
                Logger.PrintMessageAsync("Заполните все варьируемые параметры", MessageBoxImage.Error);
        }

        private void _chemicalEquations_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            { 
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    var item = (ChemicalEquation)e.NewItems![0]!;
                    ModifyChemicalEquationGroupBox.AddChemicalEquationToStackPanel(ChemicalEquationsStackPanel, item, overralReactionText: AddChemicalEquation.overralChemicalEquation!);
                    break;
            }
        }
    }
}