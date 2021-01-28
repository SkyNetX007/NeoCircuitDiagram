/***
 * Source
 ***/
using System.Drawing;

namespace NeoCircuitDiagram.Components.Instances
{
    class Source : Universal
    {
        string tag = "source";
        Image texture = NeoCircuitDiagram.Components.Textures.source_dc;

        float voltage = 5.0f;

        public Source(int x_1 = 190, int y_1 = 40, int x_2 = 250, int y_2 = 123)
        {
            Parts.Pin pin = new NeoCircuitDiagram.Components.Parts.Pin(this, 215, 40, 225, 50);
            pins.Add(pin);
            pin = new NeoCircuitDiagram.Components.Parts.Pin(this, 215, 113, 225, 123);
            pins.Add(pin);
            X[0] = x_1;
            Y[0] = y_1;
            Y[1] = y_2;
            X[1] = x_2;
        }
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen p)
        {
            Rectangle pic_box = new Rectangle(0, 0, texture.Width, texture.Height);
            Rectangle dest_box = new Rectangle(X[0], Y[0], 80, 110);
            g.DrawRectangle(p, X[0], Y[0], X[1] - X[0], Y[1] - Y[0]);
            g.DrawImage(texture, dest_box, pic_box, GraphicsUnit.Point);
        }
    }
}
