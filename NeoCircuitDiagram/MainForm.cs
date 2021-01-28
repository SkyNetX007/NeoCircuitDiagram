using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCircuitDiagram.Components.Instances;
using NeoCircuitDiagram.Components.Parts;

namespace NeoCircuitDiagram
{
    public partial class MainForm : Form
    {
        Bitmap buffer;
        Graphics bufferGraphics;
        InterfaceCanvas componentChosen, wireChosen;
        int mouse_old_X = 0;
        int mouse_old_Y = 0;
        
        public MainForm()
        {
            buffer = new Bitmap(939,535);
            bufferGraphics = Graphics.FromImage(buffer);
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Resistance ins = new Resistance();
            Document.interfaceList.Add(ins);
            Document.componentList.Add(ins);
            foreach (Pin pin in ins.pins) { Document.interfaceList.Add(pin); Document.pinList.Add(pin); }
            CanvasPaint(this.CreateGraphics());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Source ins = new Source();
            Document.interfaceList.Add(ins);
            Document.componentList.Add(ins);
            foreach (Pin pin in ins.pins) { Document.interfaceList.Add(pin); Document.pinList.Add(pin); }
            CanvasPaint(this.CreateGraphics());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Motor ins = new Motor();
            Document.interfaceList.Add(ins);
            Document.componentList.Add(ins);
            foreach (Pin pin in ins.pins) { Document.interfaceList.Add(pin); Document.pinList.Add(pin); }
            CanvasPaint(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_old_X = e.X;
            mouse_old_Y = e.Y;
            foreach (InterfaceCanvas i in Document.interfaceList)
            {
                if (i.mouse_On(e.X, e.Y))
                {
                    if (i.Get_type() == "component")
                    {
                        componentChosen = i;
                        Document.wireList.Add(i);
                    }
                    else
                    {
                        Wire w = new Wire(e.X, e.Y, e.X, e.Y, (Pin)i);
                        Document.interfaceList.Add(w);
                        wireChosen = w;
                    }
                    break;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (componentChosen != null)
            {
                componentChosen.Move(e.X - mouse_old_X, e.Y - mouse_old_Y);
                mouse_old_X = e.X;
                mouse_old_Y = e.Y;
                CanvasPaint(this.CreateGraphics());
            }
            if (wireChosen != null)
            {
                wireChosen.Move_XY(1, e.X - mouse_old_X, e.Y - mouse_old_Y);
                mouse_old_X = e.X;
                mouse_old_Y = e.Y;
                CanvasPaint(this.CreateGraphics());
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (componentChosen != null)
                componentChosen = null;
            if (wireChosen != null)
            {
                (int x, int y) = wireChosen.Get_XY(1);
                foreach (InterfaceCanvas i in Document.interfaceList)
                {
                    if (i.mouse_On(x, y))
                    {
                        if (i.Get_type() == "pin")
                        {
                            Pin p = (Pin)i;
                            Document.interfaceList.Add(((Wire)wireChosen).P_from.Connect(p));
                            break;
                        }
                    }
                }
                Document.interfaceList.Remove(wireChosen);
                wireChosen = null;
                CanvasPaint(this.CreateGraphics());
            }

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            CanvasPaint(e.Graphics);
        }

        void CanvasPaint(Graphics g)
        {
            if (Document.interfaceList.Count != 0)
            {
                Pen p = new Pen(Color.Red);
                //g.Clear(Color.White);
                bufferGraphics.Clear(Color.White);
                foreach (InterfaceCanvas i in Document.interfaceList)
                {
                    i.Draw(bufferGraphics, p);
                }
                g.DrawImage(buffer, new Point(0, 0));
            }
        }

    }
}
