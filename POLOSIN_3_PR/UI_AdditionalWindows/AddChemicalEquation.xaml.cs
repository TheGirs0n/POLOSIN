using POLOSIN_3_PR.UI_Methods;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace POLOSIN_3_PR.UI_AdditionalWindows
{
    /// <summary>
    /// Логика взаимодействия для AddChemicalEquation.xaml
    /// </summary>
    public partial class AddChemicalEquation : Window
    {
        public AddChemicalEquation()
        {
            InitializeComponent();
        }
        
        private void AddComponentsToReaction_Click(object sender, RoutedEventArgs e)
        {
            if (LeftChemicalComponentsCountTextBox.Text != string.Empty
                && RightChemicalComponentsCountTextBox.Text != string.Empty)
            {
                for(int i = 0; i < int.Parse(LeftChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquation(LeftComponentsStackPanel);

                for (int i = 0; i < int.Parse(RightChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquation(RightComponentsStackPanel);
            }
        }

        
    }
}