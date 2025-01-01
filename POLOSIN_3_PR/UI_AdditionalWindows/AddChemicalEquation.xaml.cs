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
        private Dictionary<string, int> leftEquationSide = new Dictionary<string, int>();
        private Dictionary<string, int> rightEquationSide = new Dictionary<string, int>();

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

        private void GetChemicalEquation(bool isOverral)
        {
            leftEquationSide.Clear();
            rightEquationSide.Clear();

            foreach (var item in LeftComponentsStackPanel.Children)
            {
                var stackPanel = (Border)item;
                StackPanel child = (StackPanel)stackPanel.Child;
                var collection = child.Children;

                var key = (ComboBox)collection[1];
                var value = (TextBox)collection[3];

                leftEquationSide.Add(key.SelectedItem.ToString()!, int.Parse(value.Text));
            }

            foreach (var item in RightComponentsStackPanel.Children)
            {
                var stackPanel = (Border)item;
                StackPanel child = (StackPanel)stackPanel.Child;
                var collection = child.Children;

                var key = (ComboBox)collection[1];
                var value = (TextBox)collection[3];

                rightEquationSide.Add(key.SelectedItem.ToString()!, int.Parse(value.Text));
            }

            if (isOverral == false)
            {
                _chemicalEquation = new ChemicalEquation(leftEquationSide, rightEquationSide,
                    float.Parse(EnergyActivation.Text), float.Parse(VelocityConst.Text));
                MainWindow.ChemicalEquations!.Add(_chemicalEquation);
            }
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
                GetChemicalEquation(false);
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
            GetChemicalEquation(true);

            if (LeftComponentsStackPanel.Children.Count > 0 && RightComponentsStackPanel.Children.Count > 0)
            {
                ReactionView.Visibility = Visibility.Visible;
                OverralReactionView.Visibility = Visibility.Visible;
            }

            for (int i = 0; i < leftEquationSide.Count; i++)
            {
                var item = leftEquationSide.ElementAt(i);
                if(i != leftEquationSide.Count - 1)
                    OverralReactionView.Content += $"{item.Value}{item.Key}+";
                else
                    OverralReactionView.Content += $"{item.Value}{item.Key}";
            }

            OverralReactionView.Content += " = ";

            for (int i = 0; i < rightEquationSide.Count; i++)
            {
                var item = rightEquationSide.ElementAt(i);
                if (i != rightEquationSide.Count - 1)
                    OverralReactionView.Content += $"{item.Value}{item.Key}+";
                else
                    OverralReactionView.Content += $"{item.Value}{item.Key}";
            }
        }
    }
}