/***
 * Resistance
 ***/
using System.Drawing;

namespace NeoCircuitDiagram.Components.Instances
{
    class Resistance : Universal
    {
        string tag = "resistance";
        Image texture = NeoCircuitDiagram.Components.Textures.resistance;

        float R = 100.0f;

        public Resistance(int x_1 = 190, int y_1 = 40, int x_2 = 280, int y_2 = 80)
        {
            Parts.Pin pin = new NeoCircuitDiagram.Components.Parts.Pin(this, 190, 58, 200, 68);
            pins.Add(pin);
            pin = new NeoCircuitDiagram.Components.Parts.Pin(this, 270, 58, 280, 68);
            pins.Add(pin);
            X[0] = x_1;
            Y[0] = y_1;
            Y[1] = y_2;
            X[1] = x_2;
        }
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            Rectangle pic_box = new Rectangle(0, 0, texture.Width, texture.Height);
            Rectangle dest_box = new Rectangle(X[0], Y[0], 80, 50);
            g.DrawRectangle(p, X[0], Y[0], X[1] - X[0], Y[1] - Y[0]);
            g.DrawImage(texture, dest_box, pic_box, GraphicsUnit.Point);
        }
    }
}
