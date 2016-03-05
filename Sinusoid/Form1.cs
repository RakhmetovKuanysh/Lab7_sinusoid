using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinusoid
{
    public partial class Form1 : Form
    {
        List<PointF> arr = new List<PointF>();
        Pen pen = new Pen(Color.Maroon);
        Point p1 = new Point(270, 0);
        Point p2 = new Point(270, 500);
        Point p3 = new Point(0,250);
        Point p4 = new Point(500,250);
        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();
            t.Interval = 200;
            t.Tick += T_Tick;
            t.Start();

            arr.Add(new PointF(0, 250));
            arr.Add(new PointF(0, 250));

        }

        int x = 0;

        private void T_Tick(object sender, EventArgs e)
        {
            double y = (-1)*Math.Sin(x++);
            y = 20 * y + 250;
            arr.Add(new PointF((float)x*20, (float)y));
            Refresh();
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawCurve(pen, arr.ToArray());
            e.Graphics.DrawLine(new Pen(Color.Black),p1, p2);
            e.Graphics.DrawLine(new Pen(Color.Black), p3, p4);
        }
    }
}
