using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using POLOSIN_3_PR.Classes_Folder;

namespace POLOSIN_3_PR.UI_Methods
{
    public class ModifyChemicalEquationGroupBox
    {
        public static void RemoveChemicalEquation(StackPanel stackPanel, ObservableCollection<ChemicalEquation>? chemicalEquations)
        {
            stackPanel.Children.RemoveAt(stackPanel.Children.Count - 1);
            chemicalEquations!.RemoveAt(chemicalEquations.Count - 1);
        }

        public static void AddChemicalEquationComponents(StackPanel stackPanel, Dictionary<string, int> components)
        {
            var newStackPanel = CreateChemicalEquationStackPanel(components);
            stackPanel.Children.Add(newStackPanel);
        }

        public static void AddChemicalEquationToStackPanel(StackPanel stackPanel, ChemicalEquation chemicalEquation, string overralReactionText)
        {
            var newStackPanel = CreateChemicalEquation(stackPanel, chemicalEquation, overralReactionText);
            stackPanel.Children.Add(newStackPanel);       
        }

        private static Border CreateChemicalEquation(StackPanel stackPanel, ChemicalEquation chemicalEquation, string overralReactionText)
        {
            Border border = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Margin = new Thickness(3),
                IsHitTestVisible = true,
                Background = new SolidColorBrush(Colors.Transparent)
            };

            List<UIElement> list = new List<UIElement>()
            {
                new Label
                {
                    Content = $"{stackPanel.Children.Count}",
                    HorizontalAlignment = HorizontalAlignment.Center
                },
                new Label
                {
                    Content = overralReactionText,
                    HorizontalAlignment = HorizontalAlignment.Center
                },
                new Label
                {
                    Content = $"{chemicalEquation._ActivateEnergy} {chemicalEquation._ActivateEnergyUnit}",
                    HorizontalAlignment = HorizontalAlignment.Center
                },
                new Label
                {
                    Content = $"{chemicalEquation._PredExp} {chemicalEquation._VelocityConstUnit}",
                    HorizontalAlignment = HorizontalAlignment.Center
                }
            };

            var stackPanelToAdd = new Grid()
            {
                
            };
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            AddToGrid(stackPanelToAdd, list);
            border.Child = stackPanelToAdd;

            return border;
        }


        private static Border CreateChemicalEquationStackPanel(Dictionary<string, int> components)
        {
            Border border = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Margin = new Thickness(3),
                IsHitTestVisible = true,
                Background = new SolidColorBrush(Colors.Transparent)
            };

            var componentComponent = new ComboBox()
            {
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(3)
            };
            componentComponent.ItemsSource = components.Keys;

            var componentConcentration = new TextBox
            {
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(3)
            };
            componentConcentration.PreviewTextInput += TextBox_PreviewTextInputConcentration;
            componentConcentration.PreviewKeyDown += TextBox_PreviewKeyDown;

            List<UIElement> list = new List<UIElement>()
            {
                new Label
                {
                    Content = "Ком-нт"
                },
                componentComponent,
                new Label
                {
                    Content = "Кол-во"
                },
                componentConcentration
            };

            var stackPanelToAdd = new Grid()
            {

            };
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            AddToGrid(stackPanelToAdd, list);
            border.Child = stackPanelToAdd;

            return border;
        }

        private static void AddToGrid(Grid grid, List<UIElement> list)
        {
            foreach (var value in list)
            {
                Grid.SetColumn(value, list.IndexOf(value));
                grid.Children.Add(value);
            }
        }

        private static void TextBox_PreviewTextInputConcentration(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!char.IsDigit(Symb) && Symb != ',')
                e.Handled = true;
        }

        private static void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
                e.Handled = true;
        }
    }
}
