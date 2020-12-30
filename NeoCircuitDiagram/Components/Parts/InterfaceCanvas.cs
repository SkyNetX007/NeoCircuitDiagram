using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCircuitDiagram.Components.Parts
{
    public interface InterfaceCanvas
    {
        void Draw(System.Drawing.Graphics g, System.Drawing.Pen p);
        bool mouse_On(int x, int y);
        (int, int) Get_XY(int num);
        void Set_XY(int num, int x, int y);
        void Move_XY(int num, int x, int y);
        void Move(int x, int y);
        string Get_type();
    }
}
