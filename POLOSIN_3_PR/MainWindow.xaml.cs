﻿using POLOSIN_3_PR.Async_Methods;
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
        private static ObservableCollection<ChemicalEquation>? _chemicalEquations;
        private static ObservableCollection<ComponentClass>? _components;
        public static ObservableCollection<ChemicalEquation>? ChemicalEquations
        {
            get => _chemicalEquations;
            set => _chemicalEquations = value;
        }
        public static ObservableCollection<ComponentClass>? Components
        {
            get => _components;
            set => _components = value;
        }

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
                ModifyComponentGroupBox.GetComponentsAndConcentration(components: Components!, ComponentsStackPanel);
                if (Components!.Count > 0)
                {
                    AddChemicalEquation addChemicalEquation = new AddChemicalEquation();
                    addChemicalEquation.Show();
                    addChemicalEquation.Owner = this;
                }
                else
                    Logger.PrintMessageAsync("Ошибка чтения данных. Проверьте корректность", MessageBoxImage.Error);
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
                && TimeTextBox.Text != string.Empty && Components!.Count > 0 && ChemicalEquations!.Count > 0)
            {

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
                    ModifyChemicalEquationGroupBox.AddChemicalEquationToStackPanel(ComponentsStackPanel, energyActivaion: item.ActivateEnergy,
                        velocityConst: item.VelocityConst ,overralReactionText: AddChemicalEquation.overralChemicalEquation!);
                    break;
            }
        }

    }
}