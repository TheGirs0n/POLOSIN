using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace POLOSIN_3_PR.UI_Methods
{
    public class ModifyComponentGroupBox
    {
        public static void RemoveComponent(StackPanel stackPanel)
        {
            stackPanel.Children.RemoveAt(stackPanel.Children.Count - 1);
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
                IsHitTestVisible = true
            };

            var componentComponent = new TextBox
            {
                Width = 50,
                VerticalContentAlignment = VerticalAlignment.Center,
            };
            componentComponent.PreviewTextInput += TextBox_PreviewTextInputComponent;
            componentComponent.PreviewKeyDown += TextBox_PreviewKeyDown;

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
                    Content = "Концентрация"
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

        public static void AddToStackPanel(StackPanel stackPanel, List<UIElement> list)
        {
            foreach (var value in list)
                stackPanel.Children.Add(value);
        }
        public static void GetComponentsAndConcentration(ObservableCollection<ComponentClass> components, StackPanel componentsStackPanel)
        {
            string component = "";
            float concentration = 0;

            components!.Clear();

            foreach (var item in componentsStackPanel.Children)
            {
                var stackPanel = (Border)item;
                StackPanel child = (StackPanel)stackPanel.Child;
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
                        if (float.TryParse(textBoxConcentration.Text, out concentration))
                        {

                        }
                        else
                        {
                            components.Clear();
                            return;
                        }
                    }
                }
                var componentClass = new ComponentClass(component, concentration);
                components!.Add(componentClass);
            }
        }
        private static void TextBox_PreviewTextInputComponent(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!Char.IsLetter(Symb))
                e.Handled = true;
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
