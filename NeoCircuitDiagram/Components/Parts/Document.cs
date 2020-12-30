using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCircuitDiagram.Components.Parts
{
    public class Document
    {
        public static IList<InterfaceCanvas> interfaceList = new List<InterfaceCanvas>();
        public static IList<InterfaceCanvas> componentList = new List<InterfaceCanvas>();
        public static IList<InterfaceCanvas> pinList = new List<InterfaceCanvas>();
        public static IList<InterfaceCanvas> wireList = new List<InterfaceCanvas>();
    }
}
