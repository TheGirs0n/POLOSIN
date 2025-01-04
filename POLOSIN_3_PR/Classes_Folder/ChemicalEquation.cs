namespace POLOSIN_3_PR.Classes_Folder
{
    public class ChemicalEquation
    {
        public Dictionary<string, int>? _LeftEquationSide { get; set; }
        public Dictionary<string, int>? _RightEquationSide { get; set; }
        public float? _ActivateEnergy { get; set; }
        public float? _VelocityConst { get; set; }
        public string? _ActivateEnergyUnit { get; set; }
        public string? _VelocityConstUnit { get; set; }

        public ChemicalEquation(Dictionary<string, int> leftEquationSide, Dictionary<string, int> rightEquationSide,
            float activateEnergy, float velocityConst, string activateEnergyUnit)
        {
            _LeftEquationSide = leftEquationSide;
            _RightEquationSide = rightEquationSide;
            _ActivateEnergy = activateEnergy;
            _VelocityConst = velocityConst;
            _ActivateEnergyUnit = activateEnergyUnit;

            switch (_LeftEquationSide.Values.Max())
            {
                case 1:
                    _VelocityConstUnit = "1/мин"; 
                    break;
                case 2:
                    _VelocityConstUnit = "л/(моль·мин)";
                    break;
                case 3:
                    _VelocityConstUnit = "Кмоль/мин"; 
                    break;
                default:
                    break;
            }
        }
    }
}
