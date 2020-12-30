using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCircuitDiagram.Components.Parts
{
    class Pin : InterfaceCanvas
    {
        string type = "pin";
        public NeoCircuitDiagram.Components.Instances.Universal parent;
        List<Wire> w_from = new List<Wire>();
        List<Wire> w_to = new List<Wire>();
        List<Pin> pin_connected = new List<Pin>();
        public int[] X = new int[2];
        public int[] Y = new int[2];

        public Pin() { }
        public Pin(NeoCircuitDiagram.Components.Instances.Universal p, int x_1 = 190, int y_1 = 40, int x_2 = 200, int y_2 = 50)
        {
            parent = p;
            X[0] = x_1 + p.X[0];
            Y[0] = y_1 + p.Y[0];
            Y[1] = y_2 + p.Y[1];
            X[1] = x_2 + p.X[1];
        }
        public void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            g.DrawRectangle(p, X[0], Y[0], X[1] - X[0], Y[1] - Y[0]);
        }
        public bool mouse_On(int x, int y)
        {
            if (((X[0] <= x && x <= X[1]) || (X[1] <= x && x <= X[0])) && ((Y[0] <= y && y <= Y[1]) || (Y[1] <= y && y <= Y[0])))
            {
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
        public Wire Connect(Pin p)
        {
            if (p == this)
            {
                return null;
            }
            foreach (Pin pp in pin_connected)
            {
                if (pp == p)
                {
                    return null;
                }
            }
            Wire w = new Wire(X[0], Y[0], p.X[0], p.Y[0], this, p);
            pin_connected.Add(p);
            w_from.Add(w);
            p.pin_connected.Add(this);
            p.w_to.Add(w);
            return w;
        }
        public (int, int) Get_XY(int num)
        {
            return (X[num], Y[num]);
        }
        public void Move(int x, int y)
        {
            X[0] += x;
            X[1] += x;
            Y[0] += y;
            Y[1] += y;
            foreach (Wire w in w_from)
            {
                w.Move_XY(0, x, y);
            }
            foreach (Wire w in w_to)
            {
                w.Move_XY(1, x, y);
            }
        }
        public string Get_type()
        {
            return type;
        }
    }
}
