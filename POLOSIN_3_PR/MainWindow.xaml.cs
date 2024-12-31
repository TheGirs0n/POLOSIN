using POLOSIN_3_PR.UI_Methods;
using System.Windows;

namespace POLOSIN_3_PR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddChemicalEquation_Click(object sender, RoutedEventArgs e)
        {
            
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
            //ComponentsStackPanel.Children.Add();
        }
    }
}