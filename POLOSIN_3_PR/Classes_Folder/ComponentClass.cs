namespace POLOSIN_3_PR.Classes_Folder
{
    public class ComponentClass
    {
        public string? _ComponentName { get; set; }

        public float? _ComponentValue { get; set; }

        public ComponentClass(string componentName, float componentValue)
        {
            _ComponentName = componentName;
            _ComponentValue = componentValue;
        }
    }
}
