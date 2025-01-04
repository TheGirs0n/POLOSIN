using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.Classes_Folder;

namespace POLOSIN_3_PR.UI_Methods
{
    public class ModifyComponentGroupBox
    {
        public static void RemoveComponent(StackPanel stackPanel, ObservableCollection<ComponentClass> componentClasses)
        {
            stackPanel.Children.RemoveAt(stackPanel.Children.Count - 1);
            componentClasses.RemoveAt(componentClasses.Count - 1);
        }
        public static void AddComponent(StackPanel stackPanel)
        {
            var newStackPanel = CreateComponentStackPanel();
            stackPanel.Children.Add(newStackPanel);
        }

        private static Border CreateComponentStackPanel()
        {
            Border border = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Margin = new Thickness(3),
                IsHitTestVisible = true,
                Background = new SolidColorBrush(Colors.Transparent),
            };

            var componentComponent = new TextBox
            {
                Margin = new Thickness(3),
                VerticalContentAlignment = VerticalAlignment.Center,
            };
            componentComponent.PreviewTextInput += TextBox_PreviewTextInputComponent;
            componentComponent.PreviewKeyDown += TextBox_PreviewKeyDown;

            var componentConcentration = new TextBox
            {
                Margin = new Thickness(3),
                VerticalContentAlignment = VerticalAlignment.Center,
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
                    Content = "Кон-ция"
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

            AddToStackPanel(stackPanelToAdd, list);
            border.Child = stackPanelToAdd;

            return border;
        }

        public static void AddToStackPanel(Grid grid, List<UIElement> list)
        {
            foreach (var value in list)
            {
                Grid.SetColumn(value, list.IndexOf(value));
                grid.Children.Add(value);
            }
        }
        public static void GetComponentsAndConcentration(ObservableCollection<ComponentClass> components, StackPanel componentsStackPanel)
        {
            string component = "";
            float concentration = 0;

            components!.Clear();

            foreach (var item in componentsStackPanel.Children)
            {
                var stackPanel = (Border)item;
                Grid child = (Grid)stackPanel.Child;
                var collection = child.Children;

                for (int i = 1; i < collection.Count; i += 2)
                {
                    if (i == 1)
                    {
                        var textBoxComponent = (TextBox)collection[i];
                        component = textBoxComponent.Text;
                    }
                    else
                    {
                        var textBoxConcentration = (TextBox)collection[i];
                        if (float.TryParse(textBoxConcentration.Text, out concentration) == false)
                        {
                            Logger.PrintMessageAsync("Ошибка чтения данных концентрации", MessageBoxImage.Error);
                            components.Clear();
                            return;
                        }
                    }
                }
                if (!components.Any(x => x._ComponentName == component))
                {
                    var componentClass = new ComponentClass(component, concentration);
                    components!.Add(componentClass);
                }
                else
                {
                    components.Clear();
                    Logger.PrintMessageAsync("Обнаружены компоненты-дубликаты", MessageBoxImage.Error);
                    return;
                }
            }
        }
        private static void TextBox_PreviewTextInputComponent(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!char.IsLetter(Symb))
                e.Handled = true;
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
