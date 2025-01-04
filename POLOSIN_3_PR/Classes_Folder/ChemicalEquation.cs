namespace POLOSIN_3_PR.Classes_Folder
{
    public enum ActivateEnergyType
    {
        DG = 0,
        KiloDG = 1
    };
    public enum VelocityConstType
    {
        OnePM = 0,
        KmPM = 1,
        L_MPM = 2
    };
    public class ChemicalEquation
    {
        public Dictionary<string, int>? _LeftEquationSide { get; set; }
        public Dictionary<string, int>? _RightEquationSide { get; set; }
        public float? _ActivateEnergy { get; set; }
        public float? _VelocityConst { get; set; }
        public ActivateEnergyType? _ActivateEnergyType { get; set; }
        public VelocityConstType? _VelocityConstType { get; set; }

        public ChemicalEquation(Dictionary<string, int> leftEquationSide, Dictionary<string, int> rightEquationSide,
            float activateEnergy, float velocityConst, string activateEnergyType)
        {
            _LeftEquationSide = leftEquationSide;
            _RightEquationSide = rightEquationSide;
            _ActivateEnergy = activateEnergy;
            _VelocityConst = velocityConst;

            switch (activateEnergyType)
            {
                case "Дж/моль":
                    _ActivateEnergyType = ActivateEnergyType.DG;
                    break;
                case "Кдж/моль":
                    _ActivateEnergyType = ActivateEnergyType.KiloDG;
                    break;
                default:
                    break;
                
            }

            switch (_LeftEquationSide.Values.Max())
            {
                case 1:
                    _VelocityConstType = VelocityConstType.OnePM;
                    break;
                case 2:
                    _VelocityConstType = VelocityConstType.KmPM;
                    break;
                case 3:
                    _VelocityConstType = VelocityConstType.L_MPM;
                    break;
                default:
                    break;
            }
        }
    }
}
