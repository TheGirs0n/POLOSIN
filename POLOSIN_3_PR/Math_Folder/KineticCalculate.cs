using POLOSIN_3_PR.Classes_Folder;
using System.Collections.ObjectModel;
using System.Data;
using OdeLibrary;

namespace POLOSIN_3_PR.Math_Folder
{
    public class KineticCalculate
    {
        private readonly List<double> _columns = new List<double>();
        private readonly List<double> _rows = new List<double>();
        /// <summary>
        /// Расчет уравнений кинетики для уравнений chemicalEquations по компонентам components
        /// </summary>
        /// <param name="chemicalEquations">Уравнения кинетики</param>
        /// <param name="components">Компоненты</param>
        public void CalculateKinetic(ObservableCollection<ChemicalEquation>? chemicalEquations, ObservableCollection<ComponentClass>? components)
        {
            
        }
        /// <summary>
        /// Составление дифференциальных уравнений
        /// </summary>
        /// <param name="stechiometricalDataTable"></param>
        /// <param name="particularDataTable"></param>
        public void CalculateDifferentialEquations(DataTable stechiometricalDataTable, DataTable particularDataTable, List<float> velocityConst)
        {
            _columns.Clear();
            _rows.Clear();

            const double from = 0.0;
            const double to = 1;        // Чисто заглушки
            const double step = 2; 

            //var solver = new Solver();
            //var diffSystem = new LambdaOde()
            //{
            //    OdeObserver = (x, t) =>
            //    {

            //    },
            //    OdeSystem = (x, dxdt, t) =>
            //    {
            //        dxdt = ;
            //    }
            //};
            //solver.ConvenienceSolve(diffSystem, from, step, to); // Заглушка
            //solver.StepperCode = StepperTypeCode.RungeKutta4;
        }
    }
}
