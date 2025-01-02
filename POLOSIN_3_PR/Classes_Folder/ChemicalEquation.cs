namespace POLOSIN_3_PR.Classes_Folder
{
    public class ChemicalEquation
    {
        private Dictionary<string, int>? _LeftEquationSide { get; set; }
        private Dictionary<string, int>? _RightEquationSide { get; set; }
        private float? _ActivateEnergy { get; set; }
        private float? _VelocityConst { get; set; }
        public Dictionary<string, int>? LeftEquationSide
        {
            get => _LeftEquationSide;
            set => _LeftEquationSide = value;
        }
        public Dictionary<string, int>? RightEquationSide
        {
            get => _RightEquationSide;
            set => _RightEquationSide = value;
        }
        public float? ActivateEnergy
        {
            get => _ActivateEnergy;
            set => _ActivateEnergy = value;
        }
        public float? VelocityConst
        {
            get => _VelocityConst;
            set => _VelocityConst = value;
        }
        public ChemicalEquation(Dictionary<string, int> leftEquationSide, Dictionary<string, int> rightEquationSide,
            float activateEnergy, float velocityConst)
        {
            LeftEquationSide = leftEquationSide;
            RightEquationSide = rightEquationSide;
            ActivateEnergy = activateEnergy;
            VelocityConst = velocityConst;
        }
    }
}
