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
    public partial class Form2 : Form
    {
        Pen blackPen = new Pen(Color.Black, 1);
        Graphics GP;
        int X0;
        int Y0;
        int scale = 10;

        myPoint pU = new myPoint(1f,1f,1f);
        myPoint pV = new myPoint(-1f, -1f, -1f);
        myPoint pF = new myPoint(1f, 1f, 1f);
        float a, b;

        public Form2()
        {
            InitializeComponent();
            GP = panel1.CreateGraphics();
            X0 = panel1.Width / 2; //center x
            Y0 = panel1.Height / 2;//center y
            changePos();

        }
        public  void changePos()
        {
            float f;
            bool valid = float.TryParse(textBox_a.Text, out f);//check value is valid
            a = valid ? f : 0f;
            valid = float.TryParse(textBox_b.Text, out f);//check value is valid
            b = valid ? f : 0f;

            valid = float.TryParse(textBox_ux.Text, out f);//check value is valid
            pU.X = valid ? f : 0f;
            valid = float.TryParse(textBox_uy.Text, out f);//check value is valid
            pU.Y = valid ? f : 0f;

            valid = float.TryParse(textBox_vx.Text, out f);//check value is valid
            pV.X = valid ? f : 0f;
            valid = float.TryParse(textBox_vy.Text, out f);//check value is valid
            pV.Y = valid ? f : 0f;
        }
        public void myDrawPoint(Graphics graphics,Brush c, float x, float y)
        {
            graphics.FillEllipse(c, X0 + x * scale - 3, Y0 + y * scale - 3, 6, 6);
            //graphics.FillEllipse(c, X0 + x * scale - 2, Y0 + y * scale - 2, 4, 4);
        }
        public void myDrawLine(Graphics graphics, float x0, float y0, float x1, float y1)
        {
            graphics.DrawLine(blackPen, X0 + x0 * scale, Y0 + y0 * scale, X0 + x1 * scale, Y0 + y1 * scale);


        }
        public void myDrawMesh(Graphics graphics)
        {
            graphics.Clear(Color.White);
            Pen grayPen = new Pen(Color.FromArgb(80, 128, 128, 128), 1);
            for (int i = 0; i <= panel1.Width; i += 10)
                graphics.DrawLine(grayPen, i, 0, i, panel1.Width);
            for (int i = 0; i <= panel1.Height; i += 10)
                graphics.DrawLine(grayPen, 0, i, panel1.Width, i);


            graphics.DrawLine(new Pen(Color.Red, 1), panel1.Width / 2, 0, panel1.Width/2 , panel1.Height);
            graphics.DrawLine(new Pen(Color.Red, 1), 0, panel1.Height / 2, panel1.Width , panel1.Height/2);

            graphics.DrawLine(new Pen(Color.Red, 2), panel1.Width / 2, panel1.Height / 2, panel1.Width / 2 + 20, panel1.Height / 2);
            graphics.DrawLine(new Pen(Color.Green, 2), panel1.Width / 2, panel1.Height / 2, panel1.Width / 2, panel1.Height / 2 - 20);

            myDrawPoint(graphics,Brushes.Black, 0, 0);
        }

        private void textBox_ux_TextChanged(object sender, EventArgs e)
        {
            changePos();
            myDrawMesh(GP);
            myDrawPoint(GP,Brushes.Crimson, pU.X * a, pU.Y * a);
            myDrawLine(GP, pU.X * a, pU.Y * a, 0, 0);

            myDrawPoint(GP,Brushes.Blue, pV.X * b, pV.Y * b);
            myDrawLine(GP, pV.X * b, pV.Y * b, 0, 0);

            myDrawPoint(GP, Brushes.Violet, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b);
            myDrawLine(GP, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b, 0, 0);
        }

        private void textBox_vx_TextChanged(object sender, EventArgs e)
        {
            changePos();
            myDrawMesh(GP);
            myDrawPoint(GP, Brushes.Crimson, pU.X * a, pU.Y * a);
            myDrawLine(GP, pU.X * a, pU.Y * a, 0, 0);

            myDrawPoint(GP, Brushes.Blue, pV.X * b, pV.Y * b);
            myDrawLine(GP, pV.X * b, pV.Y * b, 0, 0);

            myDrawPoint(GP, Brushes.Violet, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b);
            myDrawLine(GP, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b, 0, 0);
        }

        private void textBox_b_TextChanged(object sender, EventArgs e)
        {
            changePos();
            myDrawMesh(GP);
            myDrawPoint(GP, Brushes.Crimson, pU.X * a, pU.Y * a);
            myDrawLine(GP, pU.X * a, pU.Y * a, 0, 0);

            myDrawPoint(GP, Brushes.Blue, pV.X * b, pV.Y * b);
            myDrawLine(GP, pV.X * b, pV.Y * b, 0, 0);

            myDrawPoint(GP, Brushes.Violet, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b);
            myDrawLine(GP, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b, 0, 0);
        }

        private void textBox_uy_TextChanged(object sender, EventArgs e)
        {
            changePos();
            myDrawMesh(GP);
            myDrawPoint(GP, Brushes.Crimson, pU.X * a, pU.Y * a);
            myDrawLine(GP, pU.X * a, pU.Y * a, 0, 0);

            myDrawPoint(GP, Brushes.Blue, pV.X * b, pV.Y * b);
            myDrawLine(GP, pV.X * b, pV.Y * b, 0, 0);

            myDrawPoint(GP, Brushes.Violet, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b);
            myDrawLine(GP, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b, 0, 0);
        }

        private void textBox_vy_TextChanged(object sender, EventArgs e)
        {
            changePos();
            myDrawMesh(GP);
            myDrawPoint(GP, Brushes.Crimson, pU.X * a, pU.Y * a);
            myDrawLine(GP, pU.X * a, pU.Y * a, 0, 0);

            myDrawPoint(GP, Brushes.Blue, pV.X * b, pV.Y * b);
            myDrawLine(GP, pV.X * b, pV.Y * b, 0, 0);

            myDrawPoint(GP, Brushes.Violet, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b);
            myDrawLine(GP, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b, 0, 0);
        }

        private void textBox_a_TextChanged(object sender, EventArgs e)
        {
            changePos();
            myDrawMesh(GP);
            myDrawPoint(GP, Brushes.Crimson, pU.X * a, pU.Y * a);
            myDrawLine(GP, pU.X * a, pU.Y * a, 0, 0);

            myDrawPoint(GP, Brushes.Blue, pV.X * b, pV.Y * b);
            myDrawLine(GP, pV.X * b, pV.Y * b, 0, 0);

            myDrawPoint(GP, Brushes.Violet, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b);
            myDrawLine(GP, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b, 0, 0);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            changePos();
            myDrawMesh(GP);
            myDrawPoint(GP, Brushes.Crimson, pU.X * a, pU.Y * a);
            myDrawLine(GP, pU.X * a, pU.Y * a, 0, 0);

            myDrawPoint(GP, Brushes.Blue, pV.X * b, pV.Y * b);
            myDrawLine(GP, pV.X * b, pV.Y * b, 0, 0);

            myDrawPoint(GP, Brushes.Violet, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b);
            myDrawLine(GP, pU.X * a + pV.X * b, pU.Y * a + pV.Y * b, 0, 0);
        }
    }
}
