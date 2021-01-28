/***
 * Motor
 ***/

using System.Drawing;

namespace NeoCircuitDiagram.Components.Instances
{
    class Motor : Universal
    {
        string tag = "Motor";
        Image texture = NeoCircuitDiagram.Components.Textures.motor_dc;

        float r = 0.1f;

        public Motor(int x_1 = 190, int y_1 = 40, int x_2 = 245, int y_2 = 90)
        {
            Parts.Pin pin = new NeoCircuitDiagram.Components.Parts.Pin(this, 190, 58, 200, 68);
            pins.Add(pin);
            pin = new NeoCircuitDiagram.Components.Parts.Pin(this, 235, 58, 245, 68);
            pins.Add(pin);
            X[0] = x_1;
            Y[0] = y_1;
            Y[1] = y_2;
            X[1] = x_2;
        }
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            Rectangle pic_box = new Rectangle(0, 0, texture.Width, texture.Height);
            Rectangle dest_box = new Rectangle(X[0], Y[0], 110, 110);
            g.DrawRectangle(p, X[0], Y[0], X[1] - X[0], Y[1] - Y[0]);
            g.DrawImage(texture, dest_box, pic_box, GraphicsUnit.Point);
        }
    }
}