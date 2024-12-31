using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLOSIN_3_PR.ModifyCollections_Methods
{
    public class ModifyCollectionMethods
    {
        public static void AddComponentToCollection(List<ComponentClass> componentList,
            ComponentClass componentClass) => componentList.Add(componentClass);

        public static void AddReactionToCollection(List<ChemicalEquation> chemicalEquationList,
            ChemicalEquation chemicalEquation)
    }
}
