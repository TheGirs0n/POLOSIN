namespace POLOSIN_3_PR
{
    public class ComponentClass
    {
        private string? componentName { get; set; }
        public string? ComponentName 
        {
            get => componentName;
            set => componentName = value;
        }
        private float? componentValue { get; set; }
        public float? ComponentValue
        {
            get => ComponentValue;
            set => ComponentValue = value;
        }

        ComponentClass(string componentName)
        {
            this.componentName = componentName;
            this.componentValue = 0;
        }
    }
}
