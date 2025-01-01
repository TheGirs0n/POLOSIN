using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.UI_Methods;
using System.Windows;
using System.Windows.Controls;

namespace POLOSIN_3_PR.UI_AdditionalWindows
{
    /// <summary>
    /// Логика взаимодействия для AddChemicalEquation.xaml
    /// </summary>
    public partial class AddChemicalEquation : Window
    {
        private ChemicalEquation? _chemicalEquation;
        Dictionary<string, int> leftEquationSide = new Dictionary<string, int>();
        Dictionary<string, int> rightEquationSide = new Dictionary<string, int>();

        public AddChemicalEquation()
        {
            InitializeComponent();
            InitializeCollections();
        }

        private void InitializeCollections()
        {
            foreach (var component in MainWindow.Components!)
            {
                leftEquationSide.Add(component.ComponentName!, 0);
                rightEquationSide.Add(component.ComponentName!, 0);
            }
        }
        private void GetChemicalEquation()
        {         
            foreach (var item in LeftComponentsStackPanel.Children)
            {
                var stackPanel = (Border)item;
                StackPanel child = (StackPanel)stackPanel.Child;
                var collection = child.Children;

                var key = (TextBox)collection[1];
                var value = (TextBox)collection[3];

                leftEquationSide.Add(key.Text, int.Parse(value.Text));
            }

            foreach (var item in RightComponentsStackPanel.Children)
            {
                var stackPanel = (Border)item;
                StackPanel child = (StackPanel)stackPanel.Child;
                var collection = child.Children;

                var key = (TextBox)collection[1];
                var value = (TextBox)collection[3];

                rightEquationSide.Add(key.Text, int.Parse(value.Text));
            }

            ChemicalEquation chemicalEquation = new ChemicalEquation(leftEquationSide, rightEquationSide,
                float.Parse(EnergyActivation.Text), float.Parse(VelocityConst.Text));
        }
        private void AddComponentsToReaction_Click(object sender, RoutedEventArgs e)
        {
            LeftComponentsStackPanel.Children.Clear();
            RightComponentsStackPanel.Children.Clear();

            if (LeftChemicalComponentsCountTextBox.Text != string.Empty && RightChemicalComponentsCountTextBox.Text != string.Empty
                && (int.Parse(LeftChemicalComponentsCountTextBox.Text) <= MainWindow.Components!.Count
                || int.Parse(RightChemicalComponentsCountTextBox.Text) <= MainWindow.Components!.Count))
            {
                for (int i = 0; i < int.Parse(LeftChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquationComponents(LeftComponentsStackPanel, leftEquationSide);

                for (int i = 0; i < int.Parse(RightChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquationComponents(RightComponentsStackPanel, rightEquationSide);
            }
            else if (LeftChemicalComponentsCountTextBox.Text == string.Empty || RightChemicalComponentsCountTextBox.Text == string.Empty)
                Logger.PrintMessageAsync("Заполните оба поля", MessageBoxImage.Error);
            else if (int.Parse(LeftChemicalComponentsCountTextBox.Text) > MainWindow.Components!.Count
                || int.Parse(RightChemicalComponentsCountTextBox.Text) > MainWindow.Components!.Count)
                Logger.PrintMessageAsync("Количество компонентов в реакции не может превышать общее количество", MessageBoxImage.Error);
        }
        private void AddReaction_Click(object sender, RoutedEventArgs e)
        {
            if (LeftComponentsStackPanel.Children.Count > 0 && RightComponentsStackPanel.Children.Count > 0)
            {
                GetChemicalEquation();
            }
            else
                Logger.PrintMessageAsync("Введите компоненты с обоих сторон", MessageBoxImage.Error);
        }

        private void TextBox_PreviewTextInputConcentration(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!Char.IsDigit(Symb))
                e.Handled = true;
        }
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
                e.Handled = true;
        }

        private void GetOverralReaction_Click(object sender, RoutedEventArgs e)
        {
            if (LeftComponentsStackPanel.Children.Count > 0 && RightComponentsStackPanel.Children.Count > 0)
            {
                ReactionView.Visibility = Visibility.Visible;
                OverralReactionView.Visibility = Visibility.Visible;
            }

            //for (int i = 0; i < leftComponents.Count; i++)
            //{ 
            //    OverralReactionView.Content += $"{left}" 
            //}
        }
    }
}