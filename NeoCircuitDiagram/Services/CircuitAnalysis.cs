using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoCircuitDiagram.Components.Parts;

namespace NeoCircuitDiagram.Services
{
    class CircuitAnalysis
    {
        public void GetNetwork()
        {
            foreach (Pin pin in Document.interfaceList)
            {
                if (pin.Get_type()=="pin")
                {
                    Document.pinList.Add(pin);
                }
            }

            FullPermutation(Document.pinList);
            float[,] matrix = new float[3, 4] { { 0, 2, 1, 4 }, { 1, 1, 2, 6 }, { 2, 1, 1, 7 } };
            GaussianElimination(matrix);
        }

        private bool GaussianElimination(float[,] matrix)
        {
            /// <summary>
            /// Gaussian Elimination 
            /// </summary>
            return LinearEquationSolver.Solve(matrix);
        }

        private bool FullPermutation(IList<InterfaceCanvas> elements)
        {
            if (elements.Count == 0) 
            {
                return false;
            }

            return true;
        }
    }
}
