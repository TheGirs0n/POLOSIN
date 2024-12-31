using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace POLOSIN_3_PR.UI_Methods
{
    public class ModifyChemicalEquationGroupBox
    {
        public static void AddChemicalEquation(StackPanel stackPanel)
        {
            var newStackPanel = CreateChemicalEquationStackPanel();
            stackPanel.Children.Add(newStackPanel);
        }

        private static Border CreateChemicalEquationStackPanel()
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
            componentComponent.PreviewTextInput += TextBox_PreviewTextInputConcentration;
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

        public static void AddToStackPanel(StackPanel stackPanel, List<UIElement> list)
        {
            foreach (var value in list)
                stackPanel.Children.Add(value);
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
