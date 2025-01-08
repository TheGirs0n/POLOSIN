using DocumentFormat.OpenXml.Spreadsheet;
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

        public static int indexChemicalEquationToDelete = 0;
        public static int indexChemicalComponentToDelete = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCollections();
            StartValues();
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

        private void StartValues()
        {
            TemperatureTextBox.Text = "-3";
            TimeTextBox.Text = "50";
            TempTimeTextBox.Text = "1";

            ComponentClass componentA = new ComponentClass(componentName: "A", componentConcentration: (float)0.9);
            ComponentClass componentB = new ComponentClass(componentName: "B", componentConcentration: (float)0.0);
            ComponentClass componentC = new ComponentClass(componentName: "C", componentConcentration: (float)0.0);
            ComponentClass componentD = new ComponentClass(componentName: "D", componentConcentration: (float)0.0);
            ComponentClass componentE = new ComponentClass(componentName: "E", componentConcentration: (float)0.0);

            Dictionary<string, int> leftEquationSide = new Dictionary<string, int>()
            {
                { componentA._ComponentName!, 1  },
            };
            Dictionary<string, int> rightEquationSide = new Dictionary<string, int>()
            {
                { componentB._ComponentName!, 2},
                { componentC._ComponentName!, 1},
            };
            float energyActivation = 74000;
            float predExp = (float)(0.2 * Math.Pow(10, 14));
            //float velocityConst = (float)(predExp * Math.Pow(Math.E, (-energyActivation / (8.31 * (float.Parse(TemperatureTextBox.Text) + 273)))));
            string energyActivationUnit = "Дж/моль";
            string overralReactionText = "";
            overralReactionText = GetOverralReactionText(ref overralReactionText, leftEquationSide, rightEquationSide);

            ChemicalEquation equationFirst = new ChemicalEquation(leftEquationSide, rightEquationSide, energyActivation, predExp, energyActivationUnit, overralReactionText);

            components!.Add(componentA);
            components!.Add(componentB);
            components!.Add(componentC);
            components!.Add(componentD);
            components!.Add(componentE);

            chemicalEquations!.Add(equationFirst);

            leftEquationSide = new Dictionary<string, int>()
            {
                { componentB._ComponentName!, 1  },
            };
            rightEquationSide = new Dictionary<string, int>()
            {
                { componentD._ComponentName!, 1},
                { componentE._ComponentName!, 1},
            };

            energyActivation = 89000;
            predExp = (float)(9 * Math.Pow(10, 15));
            //velocityConst = (float)(predExp * Math.Pow(Math.E, -energyActivation / (8.31 * (float.Parse(TemperatureTextBox.Text) + 273))));     
            energyActivationUnit = "Дж/моль";
            overralReactionText = GetOverralReactionText(ref overralReactionText, leftEquationSide, rightEquationSide);

            ChemicalEquation equationSecond = new ChemicalEquation(leftEquationSide, rightEquationSide, energyActivation, predExp, energyActivationUnit, overralReactionText);

            chemicalEquations!.Add(equationSecond);

            leftEquationSide = new Dictionary<string, int>()
            {
                { componentB._ComponentName!, 1},
                { componentC._ComponentName!, 1}
            };
            rightEquationSide = new Dictionary<string, int>()
            {
                { componentA._ComponentName!, 1}
            };

            energyActivation = 85000;
            predExp = (float)(0.5 * Math.Pow(10, 14));
            //velocityConst = (float)(predExp * Math.Pow(Math.E, (-energyActivation / (8.31 * (float.Parse(TemperatureTextBox.Text) + 273)))));
            energyActivationUnit = "Дж/моль";
            overralReactionText = GetOverralReactionText(ref overralReactionText, leftEquationSide, rightEquationSide);

            ChemicalEquation equationThird = new ChemicalEquation(leftEquationSide, rightEquationSide, energyActivation, predExp, energyActivationUnit, overralReactionText);

            chemicalEquations!.Add(equationThird);

            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel, componentA);
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel, componentB);
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel, componentC);
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel, componentD);
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel, componentE);

        }

        private string GetOverralReactionText(ref string overraTextReaction, Dictionary<string, int> leftEquationSide, Dictionary<string, int> rightEquationSide)
        {
            overraTextReaction = string.Empty;
            for (int i = 0; i < leftEquationSide.Count; i++)
            {
                var item = leftEquationSide.ElementAt(i);
                if (i != leftEquationSide.Count - 1)
                    overraTextReaction += $"{item.Value}{item.Key}+";
                else
                    overraTextReaction += $"{item.Value}{item.Key}";
            }

            overraTextReaction += " = ";

            for (int i = 0; i < rightEquationSide.Count; i++)
            {
                var item = rightEquationSide.ElementAt(i);
                if (i != rightEquationSide.Count - 1)
                    overraTextReaction += $"{item.Value}{item.Key}+";
                else
                    overraTextReaction += $"{item.Value}{item.Key}";
            }
            return overraTextReaction;
        }

        private List<float> GetVelocityConst()
        {
            List<float> velocityConst = new List<float>();
            for (int i = 0; i < chemicalEquations!.Count; i++)
            {
                var exp = chemicalEquations[i]._PredExp;
                var ea = chemicalEquations[i]._ActivateEnergy;
                var item = exp * Math.Pow(Math.E, (double)(-ea / (8.31 * (_temperature + 273)))!);
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
            if (ChemicalEquationsStackPanel.Children!.Count > 1 && indexChemicalEquationToDelete != -1)
                ModifyChemicalEquationGroupBox.RemoveChemicalEquation(ChemicalEquationsStackPanel, chemicalEquations, indexChemicalEquationToDelete);
            else
                Logger.PrintMessageAsync("Нет химических реакций для удаления", MessageBoxImage.Error);
        }

        private void AddComponent_Click(object sender, RoutedEventArgs e)
        {
            ModifyComponentGroupBox.AddComponent(ComponentsStackPanel);
        }

        private void RemoveComponent_Click(object sender, RoutedEventArgs e)
        {
            if (ComponentsStackPanel!.Children.Count > 0 && indexChemicalComponentToDelete != -1)
            {
                ModifyComponentGroupBox.GetComponentsAndConcentration(components!, ComponentsStackPanel);

                ModifyComponentGroupBox.RemoveComponent(ComponentsStackPanel, indexChemicalComponentToDelete);

                if (components!.Count > 0)
                    components.RemoveAt(indexChemicalComponentToDelete);
            }
            else
                Logger.PrintMessageAsync("Нет компонентов для удаления", MessageBoxImage.Error);
        }

        private void GetKineticButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyComponentGroupBox.GetComponentsAndConcentration(components: components!, ComponentsStackPanel);
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
                    var itemToAdd = (ChemicalEquation)e.NewItems![0]!;
                    if (AddChemicalEquation.overralChemicalEquation! != null) 
                        ModifyChemicalEquationGroupBox.AddChemicalEquationToStackPanel(ChemicalEquationsStackPanel, itemToAdd, overralReactionText: AddChemicalEquation.overralChemicalEquation!);
                    else
                        ModifyChemicalEquationGroupBox.AddChemicalEquationToStackPanel(ChemicalEquationsStackPanel, itemToAdd, overralReactionText: itemToAdd._OverralReactionText!);
                    UpdateStechiometricAndParticularDataTable(_stechiometricDataTable!, _particularOrdersDataTable!);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    var itemToRemove = (ChemicalEquation)e.OldItems![0]!;
                    DeleteChemicalEquation(itemToRemove);                 
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
                    var itemToRemove = (ComponentClass)e.OldItems![0]!;
                    DeleteChemicalComponent(itemToRemove);
                    break;
            }
        }
        private void DeleteChemicalEquation(ChemicalEquation chemicalEquation)
        {
            List<string> components = new List<string>();
            string message = "";
       
            var leftSide = chemicalEquation._LeftEquationSide; // 1B
            var rightSide = chemicalEquation._RightEquationSide; // 1D + 1E

            _stechiometricDataTable!.Rows.RemoveAt(indexChemicalEquationToDelete);
            _particularOrdersDataTable!.Rows.RemoveAt(indexChemicalEquationToDelete);

            UpdateDataGridSource(StechiometricDataGrid, _stechiometricDataTable);
            UpdateDataGridSource(ParticularOrdersDataGrid, _particularOrdersDataTable);

            for (int i = 0; i < _stechiometricDataTable!.Columns.Count; i++)
            {
                List<int> items = new List<int>();
                for (int j = 0; j < _stechiometricDataTable!.Rows.Count; j++)
                {
                    var value = int.Parse(_stechiometricDataTable.Rows[j][i].ToString()!);

                    items.Add(value);               
                }
                message = items.All(x => x == 0) ? message + $"\n{_stechiometricDataTable!.Columns[i].ColumnName}" : message + "";
            }

            if (message != string.Empty) 
            {
                message = message.Insert(0, "Компоненты, которые необходимо удалить для корректной работы программы.\nИначе будет запущена последняя рабочая версия данных!:");
                Logger.PrintMessageAsync($"{message}", MessageBoxImage.Warning);
            }
        }
        private void DeleteChemicalComponent(ComponentClass componentClass)
        {
            string message = "";


            List<int> items = new List<int>();
            for (int j = 0; j < _stechiometricDataTable!.Rows.Count; j++)
            {
                var value = int.Parse(_stechiometricDataTable.Rows[j][_stechiometricDataTable.Columns[componentClass._ComponentName!]!].ToString()!);

                items.Add(value);
                message = value != 0 ? message + $"\n{j + 1}" : message + "";
            }
            
            if (message != string.Empty)
            {
                message = message.Insert(0, "Реакции, которые необходимо удалить для корректной работы программы.\nИначе будет запущена последняя рабочая версия данных!:");
                Logger.PrintMessageAsync($"{message}", MessageBoxImage.Warning);
            }
            _stechiometricDataTable!.Columns.RemoveAt(indexChemicalComponentToDelete);
            _particularOrdersDataTable!.Columns.RemoveAt(indexChemicalComponentToDelete);

            UpdateDataGridSource(StechiometricDataGrid, _stechiometricDataTable);
            UpdateDataGridSource(ParticularOrdersDataGrid, _particularOrdersDataTable);
        }

        private void TextBox_PreviewTextInputConcentration(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!char.IsDigit(Symb) && Symb != ',')
                e.Handled = true;
        }
        private void TextBox_PreviewTextInputTemp(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!char.IsDigit(Symb) && Symb != ',' && Symb != '-')
                e.Handled = true;
        }
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
                e.Handled = true;
        }
    }

}