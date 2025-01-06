using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.Classes_Folder;
using POLOSIN_3_PR.Math_Folder;
using POLOSIN_3_PR.UI_AdditionalWindows;
using POLOSIN_3_PR.UI_Methods;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace POLOSIN_3_PR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<ChemicalEquation>? chemicalEquations;
        public static ObservableCollection<ComponentClass>? components;
        private DataTable? _stechiometricDataTable;
        private DataTable? _particularOrdersDataTable;

        private static float _temperature;
        private static float _processTime;
        private static float _processTimeStep;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCollections();
        }

        private void InitializeCollections()
        {
            chemicalEquations = new();
            chemicalEquations.CollectionChanged += _chemicalEquations_CollectionChanged;

            components = new();
            components.CollectionChanged += Components_CollectionChanged;

            _stechiometricDataTable = new DataTable();
            _particularOrdersDataTable = new DataTable();
        }

        private void GetActualProccesParameters()
        {
            _temperature = float.Parse(TemperatureTextBox.Text);
            _processTime = float.Parse(TimeTextBox.Text);
            _processTimeStep = float.Parse(TempTimeTextBox.Text);
        }
        public static float GetTemperature() => _temperature;
        public static float GetProcessTime() => _processTime;
        public static float GetProcessTimeStep() => _processTimeStep;
        private void AddChemicalEquation_Click(object sender, RoutedEventArgs e)
        {
            if (ComponentsStackPanel.Children!.Count > 0)
            {
                ModifyComponentGroupBox.GetComponentsAndConcentration(components: components!, ComponentsStackPanel);
                if (components!.Count > 0)
                {
                    AddChemicalEquation addChemicalEquation = new AddChemicalEquation();
                    addChemicalEquation.Show();
                    addChemicalEquation.Owner = this;
                }               
            }
            else
                Logger.PrintMessageAsync("Сначала введите компоненты", MessageBoxImage.Information);
        }
        private void UpdateDataGridSource(DataGrid dataGrid, DataTable dataTable)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void UpdateStechiometricAndParticularDataTable(DataTable stechiometricDataTable, DataTable particularDataTable)
        {
            stechiometricDataTable.Columns.Clear();
            stechiometricDataTable.Rows.Clear();
            particularDataTable.Columns.Clear();
            particularDataTable.Rows.Clear();

            for (int i = 0; i < components!.Count; i++)
            {
                stechiometricDataTable.Columns.Add($"{components[i]._ComponentName}");
                particularDataTable.Columns.Add($"{components[i]._ComponentName}");
            }

            for (int i = 0; i < chemicalEquations!.Count; i++)
            {
                stechiometricDataTable.Rows.Add();
                particularDataTable.Rows.Add();

                for (int j = 0; j < stechiometricDataTable.Columns.Count; j++)
                {
                    var stechioColumn = stechiometricDataTable.Columns[j];
                    var particularColumn = particularDataTable.Columns[j];
                    var existInLeft = chemicalEquations[i]._LeftEquationSide!.ContainsKey($"{stechioColumn}");

                    if (existInLeft)
                    {
                        stechiometricDataTable.Rows[^1][stechioColumn] = -chemicalEquations[i]._LeftEquationSide![stechioColumn.ColumnName]; // значение по ключу
                        var value = Math.Abs(decimal.Parse(stechiometricDataTable.Rows[^1][stechioColumn].ToString()!));
                        particularDataTable.Rows[^1][particularColumn] = value;
                        continue;
                    }

                    var existInRight = chemicalEquations[i]._RightEquationSide!.ContainsKey($"{stechioColumn}");

                    if (existInRight)
                    {
                        stechiometricDataTable.Rows[^1][stechioColumn] = chemicalEquations[i]._RightEquationSide![stechioColumn.ColumnName]; // значение по ключу
                        particularDataTable.Rows[^1][particularColumn] = 0;
                        continue;
                    }

                    stechiometricDataTable.Rows[^1][stechioColumn] = 0;
                    particularDataTable.Rows[^1][particularColumn] = 0;
                }
            }

            UpdateDataGridSource(StechiometricDataGrid, stechiometricDataTable);
            UpdateDataGridSource(ParticularOrdersDataGrid, particularDataTable);
        }
        private List<float> GetVelocityConst()
        {
            List<float> velocityConst = new List<float>();
            for (int i = 0; i < chemicalEquations!.Count; i++)
            {
                var exp = chemicalEquations[i]._VelocityConst;
                var ea = chemicalEquations[i]._ActivateEnergy;
                var item = exp * Math.Pow(Math.E, (double)(-ea / (8.31 * _temperature))!);
                velocityConst.Add((float)item!);
            }
            return velocityConst;
        }
        private List<string> GetChemicalEquationsText()
        {
            List<string> chemicalEquations = new List<string>();
            for (int i = 0; i < MainWindow.chemicalEquations!.Count; i++)
            {
                var exp = MainWindow.chemicalEquations[i]._OverralReactionText;
                
                chemicalEquations.Add(exp!);
            }
            return chemicalEquations;
        }
        private List<float> GetComponents()
        {
            ModifyComponentGroupBox.GetComponentsAndConcentration(components: components!, ComponentsStackPanel);
            List<float> componentsConcentraion = new List<float>();
            for (int i = 0; i < MainWindow.components!.Count; i++)
            {
                var concentration = components[i]._ComponentConcentration;

                componentsConcentraion.Add((float)concentration!);
            }
            return componentsConcentraion;
        }
        private void RemoveChemicalEquation_Click(object sender, RoutedEventArgs e)
        {
            if (ChemicalEquationsStackPanel.Children!.Count > 1)
                ModifyChemicalEquationGroupBox.RemoveChemicalEquation(ChemicalEquationsStackPanel, chemicalEquations);
            else
                Logger.PrintMessageAsync("Нет химических реакций для удаления", MessageBoxImage.Error);
        }

        private void AddComponent_Click(object sender, RoutedEventArgs e)
        {
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel);
        }

        private void RemoveComponent_Click(object sender, RoutedEventArgs e)
        {
            if (ComponentsStackPanel!.Children.Count > 0)
            {
                ModifyComponentGroupBox.GetComponentsAndConcentration(components!, ComponentsStackPanel);

                ModifyComponentGroupBox.RemoveComponent(ComponentsStackPanel);

                if (components!.Count > 0)
                    components.RemoveAt(components.Count - 1);
            }
            else
                Logger.PrintMessageAsync("Нет компонентов для удаления", MessageBoxImage.Error);
        }

        private void GetKineticButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (TemperatureTextBox.Text != string.Empty && TempTimeTextBox.Text != string.Empty
                && TimeTextBox.Text != string.Empty && components!.Count > 0 && chemicalEquations!.Count > 0)
            {
                GetActualProccesParameters();

                KineticCalculate kineticCalculate = new KineticCalculate();
                Dictionary<string, List<double>> Results = new Dictionary<string, List<double>>(); // ДОБАВИЛ ДЛЯ ГРАФИКА
                var velocityConsts = GetVelocityConst();
                var chemicalEquantions = GetChemicalEquationsText();
                var components = GetComponents();
                Results = kineticCalculate.CalculateDifferentialEquations(chemicalEquantions, velocityConsts, components, _processTime, _processTimeStep);
                Graphs graphWindow = new Graphs(Results); // ГРАФИК
                graphWindow.Show(); //

            }
            else if(TemperatureTextBox.Text == string.Empty || TempTimeTextBox.Text == string.Empty
                || TimeTextBox.Text == string.Empty)
                Logger.PrintMessageAsync("Заполните все варьируемые параметры", MessageBoxImage.Error);
            else if(components!.Count == 0)
                Logger.PrintMessageAsync("Введите компоненты", MessageBoxImage.Error);
            else if (chemicalEquations!.Count == 0)
                Logger.PrintMessageAsync("Введите химические реакции", MessageBoxImage.Error);
        }


        private void _chemicalEquations_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            { 
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    var item = (ChemicalEquation)e.NewItems![0]!;
                    ModifyChemicalEquationGroupBox.AddChemicalEquationToStackPanel(ChemicalEquationsStackPanel, item, overralReactionText: AddChemicalEquation.overralChemicalEquation!);
                    UpdateStechiometricAndParticularDataTable(_stechiometricDataTable!, _particularOrdersDataTable!);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    _stechiometricDataTable!.Rows.RemoveAt(_stechiometricDataTable.Rows.Count - 1);
                    _particularOrdersDataTable!.Rows.RemoveAt(_particularOrdersDataTable.Rows.Count - 1);

                    UpdateDataGridSource(StechiometricDataGrid, _stechiometricDataTable);
                    UpdateDataGridSource(ParticularOrdersDataGrid, _particularOrdersDataTable);
                    break;
            }
        }

        private void Components_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:        
                    UpdateStechiometricAndParticularDataTable(_stechiometricDataTable!, _particularOrdersDataTable!);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    _stechiometricDataTable!.Columns.RemoveAt(_stechiometricDataTable.Columns.Count - 1);
                    _particularOrdersDataTable!.Columns.RemoveAt(_particularOrdersDataTable.Columns.Count - 1);

                    UpdateDataGridSource(StechiometricDataGrid, _stechiometricDataTable);
                    UpdateDataGridSource(ParticularOrdersDataGrid, _particularOrdersDataTable);
                    break;
            }
        }
        private void TextBox_PreviewTextInputConcentration(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!char.IsDigit(Symb) && Symb != ',')
                e.Handled = true;
        }
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
                e.Handled = true;
        }
    }
}