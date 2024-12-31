namespace POLOSIN_3_PR
{
    public class ComponentClass
    {
        private string? _ComponentName { get; set; }
        public string? ComponentName 
        {
            get => _ComponentName;
            set => _ComponentName = value;
        }
        private float? _ComponentValue { get; set; }
        public float? ComponentValue
        {
            get => ComponentValue;
            set => ComponentValue = value;
        }

        ComponentClass(string componentName)
        {
            ComponentName = componentName;
            ComponentValue = 0;
        }
    }
}
