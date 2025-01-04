namespace POLOSIN_3_PR.Classes_Folder
{
    public class ComponentClass
    {
        public string? _ComponentName { get; set; }

        public float? _ComponentConcentration { get; set; }

        public ComponentClass(string componentName, float componentConcentration)
        {
            _ComponentName = componentName;
            _ComponentConcentration = componentConcentration;
        }
    }
}
