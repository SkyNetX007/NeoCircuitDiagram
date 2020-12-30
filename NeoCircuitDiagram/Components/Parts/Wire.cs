using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCircuitDiagram.Components.Parts
{
    class Wire : InterfaceCanvas
    {
        string type = "wire";
        public int[] X = new int[2];
        public int[] Y = new int[2];
        public Pin P_to;
        public Pin P_from;
        public Wire(int x = 0, int y = 0, int x_2 = 0, int y_2 = 0, Pin p_from = null, Pin p_to = null)
        {
            X[0] = x;
            Y[0] = y;
            Y[1] = y_2;
            X[1] = x_2;
            P_to = p_to;
            P_from = p_from;
        }
        public void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            //g.DrawLine(p, X[0], Y[0], X[1], Y[1]);
            g.DrawLine(p, X[0], Y[0], X[1], Y[0]);
            g.DrawLine(p, X[1], Y[0], X[1], Y[1]);
        }
        public bool mouse_On(int x, int y)
        {
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
        }
        public string Get_type()
        {
            return (type);
        }
    }
}
