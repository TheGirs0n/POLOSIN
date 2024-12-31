using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<UIElement> list = new List<UIElement>()
            {
                new Label {Content = "Компонент" },
                new TextBox {Width = 50, VerticalContentAlignment = VerticalAlignment.Center},
                new Label {Content = "Концентрация"},
                new TextBox {Width = 50, VerticalContentAlignment = VerticalAlignment.Center}
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
    }
}
