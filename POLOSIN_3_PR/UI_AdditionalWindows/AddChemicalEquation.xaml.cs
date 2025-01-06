using POLOSIN_3_PR.Async_Methods;
using POLOSIN_3_PR.Classes_Folder;
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
        public static string? overralChemicalEquation;
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
            foreach (var component in MainWindow.components!)
            {
                leftEquationSide.Add(component._ComponentName!, 0);
                rightEquationSide.Add(component._ComponentName!, 0);
            }
        }

        private void GetChemicalEquation()
        {
            leftEquationSide.Clear();
            rightEquationSide.Clear();

            bool checkLeft = CheckEquationSides(equationStackPanel: LeftComponentsStackPanel, equationDictionary: leftEquationSide);
            bool checkRight = CheckEquationSides(equationStackPanel:  RightComponentsStackPanel, equationDictionary: rightEquationSide);

            if (checkLeft == true && checkRight == true)
            {
                if (float.TryParse(EnergyActivation.Text, out float energy) == true
                    && float.TryParse(VelocityConst.Text, out float velocity) == true
                    && float.TryParse(PowTextBox.Text, out float power) == true)
                {
                    velocity *= (float)Math.Pow(10, power);
                    var velocityConstUnit = (TextBlock)VelocityConstTypeComboBox.SelectedItem;

                    GetOverralReactionText();

                    _chemicalEquation = new ChemicalEquation(leftEquationSide, rightEquationSide,
                        energy, velocity, velocityConstUnit.Text.ToString()!, overralChemicalEquation!);
                }
                else
                {
                    leftEquationSide.Clear();
                    rightEquationSide.Clear();

                    Logger.PrintMessageAsync("Не заданы параметры реакции. Проверьте корректность", MessageBoxImage.Error);
                }
            }
        }
        
        private bool CheckEquationSides(StackPanel equationStackPanel, Dictionary<string, int> equationDictionary)
        {
            bool check = false;

            foreach (var item in equationStackPanel.Children)
            {
                var stackPanel = (Border)item;
                Grid child = (Grid)stackPanel.Child;
                var collection = child.Children;

                var key = (ComboBox)collection[1];
                var value = (TextBox)collection[3];

                if (int.TryParse(value.Text, out int concentration) == true && key.SelectedItem.ToString() != null
                    && !equationDictionary.ContainsKey(key.SelectedItem.ToString()!))
                {
                    equationDictionary.Add(key.SelectedItem.ToString()!, concentration);
                    check = true;
                }
                else if (key.SelectedItem == null)
                {
                    Logger.PrintMessageAsync("Выберите компоненты. Проверьте корректность", MessageBoxImage.Error);

                    leftEquationSide.Clear();
                    rightEquationSide.Clear();

                    check = false;
                    return check;
                }
                else if (equationDictionary.ContainsKey(key.SelectedItem.ToString()!))
                {
                    Logger.PrintMessageAsync("Обнаружены дубликаты. Проверьте корректность", MessageBoxImage.Error);

                    leftEquationSide.Clear();
                    rightEquationSide.Clear();

                    check = false;
                    return check;
                }
                else
                {
                    Logger.PrintMessageAsync("Ошибка чтения данных. Проверьте корректность", MessageBoxImage.Error);

                    leftEquationSide.Clear();
                    rightEquationSide.Clear();

                    check = false;
                    return check;
                }
            }
            return check;
        }
        private void GetOverralReactionText()
        {
            OverralReactionView.Content = string.Empty;
            for (int i = 0; i < leftEquationSide.Count; i++)
            {
                var item = leftEquationSide.ElementAt(i);
                if (i != leftEquationSide.Count - 1)
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
            overralChemicalEquation = OverralReactionView.Content.ToString();
        }
        private void AddComponentsToReaction_Click(object sender, RoutedEventArgs e)
        {
            LeftComponentsStackPanel.Children.Clear();
            RightComponentsStackPanel.Children.Clear();

            if (LeftChemicalComponentsCountTextBox.Text != string.Empty && RightChemicalComponentsCountTextBox.Text != string.Empty
                && (int.Parse(LeftChemicalComponentsCountTextBox.Text) <= MainWindow.components!.Count
                && int.Parse(RightChemicalComponentsCountTextBox.Text) <= MainWindow.components!.Count))
            {
                for (int i = 0; i < int.Parse(LeftChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquationComponents(LeftComponentsStackPanel, leftEquationSide);

                for (int i = 0; i < int.Parse(RightChemicalComponentsCountTextBox.Text); i++)
                    ModifyChemicalEquationGroupBox.AddChemicalEquationComponents(RightComponentsStackPanel, rightEquationSide);

                //GetOverralReaction.Visibility = Visibility.Visible;
            }
            else if (LeftChemicalComponentsCountTextBox.Text == string.Empty || RightChemicalComponentsCountTextBox.Text == string.Empty)
                Logger.PrintMessageAsync("Заполните оба поля", MessageBoxImage.Error);
            else if (int.Parse(LeftChemicalComponentsCountTextBox.Text) > MainWindow.components!.Count
                || int.Parse(RightChemicalComponentsCountTextBox.Text) > MainWindow.components!.Count)
                Logger.PrintMessageAsync("Количество компонентов в реакции не может превышать общее количество", MessageBoxImage.Error);
        }
        private void AddReaction_Click(object sender, RoutedEventArgs e)
        {
            if (LeftComponentsStackPanel.Children.Count > 0 && RightComponentsStackPanel.Children.Count > 0)
            {
                GetChemicalEquation();
                if (!(_chemicalEquation == null))
                {
                    MainWindow.chemicalEquations!.Add(_chemicalEquation!);
                    this.Close();
                }
            }
            else
                Logger.PrintMessageAsync("Введите компоненты с обоих сторон", MessageBoxImage.Error);
        }

        private void TextBox_PreviewTextInputConcentration(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Symb = e.Text[0];

            if (!char.IsDigit(Symb) && Symb != ',')
                e.Handled = true;
        }
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
                e.Handled = true;
        }

        private void GetOverralReaction_Click(object sender, RoutedEventArgs e)
        {
            GetChemicalEquation();
            if (LeftComponentsStackPanel.Children.Count > 0 && RightComponentsStackPanel.Children.Count > 0)
            {
                ReactionView.Visibility = Visibility.Visible;
                OverralReactionView.Visibility = Visibility.Visible;
                GetOverralReactionText();
            }
        }
        
    }
}