using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.UI_Methods;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace POLOSIN_3_PR.UI_AdditionalWindows
{
    /// <summary>
    /// Логика взаимодействия для AddChemicalEquation.xaml
    /// </summary>
    public partial class AddChemicalEquation : Window
    {
        private ChemicalEquation? _chemicalEquation;
        public AddChemicalEquation()
        {
            InitializeComponent();
        }
        
        private void AddComponentsToReaction_Click(object sender, RoutedEventArgs e)
        {
            if (LeftChemicalComponentsCountTextBox.Text != string.Empty
                && RightChemicalComponentsCountTextBox.Text != string.Empty)
            {
                for (int i = 0; i < int.Parse(LeftChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquation(LeftComponentsStackPanel);

                for (int i = 0; i < int.Parse(RightChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquation(RightComponentsStackPanel);
            }
            else
                Logger.PrintMessageAsync("Заполните оба поля", MessageBoxImage.Error);
        }
        private void AddReaction_Click(object sender, RoutedEventArgs e)
        {
            if (LeftComponentsStackPanel.Children.Count > 0 && RightComponentsStackPanel.Children.Count > 0)
            {
                
            }
        }

        private void TextBox_PreviewTextInputConcentration(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!Char.IsDigit(Symb) && Symb != ',')
                e.Handled = true;
        }
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
                e.Handled = true;
        }

        
    }
}