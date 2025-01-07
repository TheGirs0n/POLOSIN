namespace POLOSIN_3_PR.Classes_Folder
{
    public class ChemicalEquation
    {
        public Dictionary<string, int>? _LeftEquationSide { get; set; }
        public Dictionary<string, int>? _RightEquationSide { get; set; }
        public float? _ActivateEnergy { get; set; }
        public float? _PredExp { get; set; }
        public string? _ActivateEnergyUnit { get; set; }
        public string? _VelocityConstUnit { get; set; }
        public string? _OverralReactionText { get; set; }

        public ChemicalEquation(Dictionary<string, int> leftEquationSide, Dictionary<string, int> rightEquationSide,
            float activateEnergy, float predExp, string activateEnergyUnit, string overralReactionText)
        {
            _LeftEquationSide = leftEquationSide;
            _RightEquationSide = rightEquationSide;
            _ActivateEnergy = activateEnergy;
            _PredExp = predExp;
            _ActivateEnergyUnit = activateEnergyUnit;
            _OverralReactionText = overralReactionText;

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
