using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NeoCircuitDiagram.Components.Instances
{
    class Universal : NeoCircuitDiagram.Components.Parts.InterfaceCanvas
    {
        string type = "component";
        public int[] X = new int[2];
        public int[] Y = new int[2];
        public List<NeoCircuitDiagram.Components.Parts.Pin> pins = new List<NeoCircuitDiagram.Components.Parts.Pin>();

        public virtual void Draw(System.Drawing.Graphics g, System.Drawing.Pen p) { }

        public bool mouse_On(int x, int y)
        {
            if (((X[0] <= x && x <= X[1]) || (X[1] <= x && x <= X[0])) && ((Y[0] <= y && y <= Y[1]) || (Y[1] <= y && y <= Y[0])))
            {
                foreach(NeoCircuitDiagram.Components.Parts.Pin p in pins)
                {
                    if (p.mouse_On(x, y))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public void Set_XY(int num, int x, int y)
        {
            X[num] = x;
            Y[num] = y;
        }
        public void Move_XY(int num, int x, int y)
        {
            X[num] += x;
            Y[num] += y;
        }
        public void Move(int x, int y)
        {
            X[0] += x;
            X[1] += x;
            Y[0] += y;
            Y[1] += y;
            foreach (NeoCircuitDiagram.Components.Parts.Pin p in pins)
            {
                p.Move(x, y);
            }
        }
        public (int, int) Get_XY(int num)
        {
            return (X[num], Y[num]);
        }
        public string Get_type()
        {
            return (type);
        }
    }
}
