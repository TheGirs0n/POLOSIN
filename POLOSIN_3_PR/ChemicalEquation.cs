namespace POLOSIN_3_PR
{
    internal class ChemicalEquation
    {
        private Dictionary<string, int>? _LeftEquationSide { get; set; }
        public Dictionary<string, int>? LeftEquationSide
        {
            get => _LeftEquationSide;
            set => _LeftEquationSide = value;
        }
        private Dictionary<string, int>? _RightEquationSide { get; set; }
        public Dictionary<string, int>? RightEquationSide
        {
            get => RightEquationSide;
            set => RightEquationSide = value;
        }
        public ChemicalEquation(Dictionary<string, int> leftEquationSide, Dictionary<string, int> rightEquationSide)
        {
            LeftEquationSide = leftEquationSide;
            RightEquationSide = rightEquationSide;
        }
    }
}
