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

        public static void AddChemicalEquationToStackPanel(StackPanel stackPanel, float? energyActivaion,
            float? velocityConst, string overralReactionText)
        {
            var newStackPanel = CreateChemicalEquation(stackPanel, energyActivaion, velocityConst, overralReactionText);
            stackPanel.Children.Add(newStackPanel);       
        }

        private static Border CreateChemicalEquation(StackPanel stackPanel, float? energyActivaion,
            float? velocityConst, string overralReactionText)
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
                    Width = 25,
                },
                new Label
                {
                    Content = overralReactionText,
                    Width = 150
                },
                new Label
                {
                    Content = energyActivaion,
                    Width = 150
                },
                new Label
                {
                    Content = velocityConst,
                    Width = 150
                }
            };

            var stackPanelToAdd = new Grid()
            {
                
            };
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)});
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            stackPanelToAdd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            AddToStackPanel(stackPanelToAdd, list);
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
                Width = 50,
                VerticalContentAlignment = VerticalAlignment.Center,
            };
            componentComponent.ItemsSource = components.Keys;

            var componentConcentration = new TextBox
            {
                Width = 50,
                VerticalContentAlignment = VerticalAlignment.Center,
            };
            componentConcentration.PreviewTextInput += TextBox_PreviewTextInputConcentration;
            componentConcentration.PreviewKeyDown += TextBox_PreviewKeyDown;

            List<UIElement> list = new List<UIElement>()
            {
                new Label
                {
                    Content = "Компонент"
                },
                componentComponent,
                new Label
                {
                    Content = "Количество"
                },
                componentConcentration
            };

            var stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(5),
            };

            AddToStackPanel(stackPanel, list);
            border.Child = stackPanel;

            return border;
        }

        private static void AddToStackPanel(StackPanel stackPanel, List<UIElement> list)
        {
            foreach (var value in list)
                stackPanel.Children.Add(value);
        }

        private static void AddToStackPanel(Grid grid, List<UIElement> list)
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

            if (!Char.IsDigit(Symb) && Symb != ',')
                e.Handled = true;
        }

        private static void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
                e.Handled = true;
        }
    }
}
