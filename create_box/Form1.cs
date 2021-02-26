using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace create_box
{       

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public void DrawLineInt()
        {
            Pen blackPen = new Pen(Color.Black, 3);
            Graphics GPS = panel1.CreateGraphics();
            int center_X = panel1.Width / 2;
            int center_Y = panel1.Height / 2;
            // Create pen.
            GPS.Clear(panel1.BackColor);

            // Create coordinates of points that define line.
            int length = 60;
            int x1 = center_X;
            int y1 = center_Y;
            int x2 = x1 + length;
            int y2 = y1 + length;
            // label1.Text = degree + "°"+x2+" "+y2+" "+ Math.Cos(degree )+ " "+ Math.Sin(degree);


            // Draw line to screen.
            //GPS.DrawLine(blackPen, x1, y1, x2, y2);
            GPS.DrawEllipse(new Pen(Color.Black, 3), x1, y1, 3,3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawLineInt();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }


    }
}
