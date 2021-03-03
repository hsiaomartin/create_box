using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace create_box
{       

    public partial class Form1 : Form
    {
        myPoint myEye= new myPoint(2f,3f,5f);
        myPoint A = new myPoint(1f, 1f, 1f);
        myPoint B = new myPoint(-1f, 1f, 1f);
        myPoint C = new myPoint(1f, -1f, 1f);
        myPoint D = new myPoint(-1f, -1f, 1f);
        myPoint E = new myPoint(1f, 1f, -1f);
        myPoint F = new myPoint(-1f, 1f, -1f);
        myPoint G = new myPoint(1f, -1f, -1f);
        myPoint H = new myPoint(-1f, -1f, -1f);
        Pen blackPen = new Pen(Color.Black, 1);
        Graphics GPS;
        int X0;
        int Y0;
        int scale = 80;
        public Form1()
        {
            InitializeComponent();
            GPS = panel1.CreateGraphics();
            X0 = panel1.Width / 2; //center x
            Y0 = panel1.Height / 2;//center y
        }
        public void myDrawMesh()
        {
            Pen grayPen = new Pen(Color.FromArgb(80,128,128,128), 1);
            for (int i = 0; i<=panel1.Width; i+=10)
                GPS.DrawLine(grayPen, i,0 ,i, panel1.Width);
            for (int i = 0; i <= panel1.Height; i += 10)
                GPS.DrawLine(grayPen,  0, i, panel1.Width,i);
            myDrawPoint(0,0);
            GPS.DrawLine(new Pen(Color.Red, 2), panel1.Width/2, panel1.Height/2, panel1.Width / 2+20, panel1.Height / 2);
            GPS.DrawLine(new Pen(Color.Green, 2), panel1.Width / 2, panel1.Height / 2, panel1.Width / 2, panel1.Height / 2 - 20);
        }
        public void myDrawPoint(float x, float y)
        {
            //GPS.FillEllipse(Brushes.Red, X0 - 3, Y0 - 3, 6, 6);
            GPS.FillEllipse(Brushes.Red, X0 + x*scale-2, Y0 + y*scale-2, 4, 4);
        }
        public void myDrawLine(float x0,float y0,float x1,float y1)
        {
            GPS.DrawLine(blackPen,X0+ x0*scale,Y0+ y0 * scale, X0+x1 * scale, Y0+y1 * scale);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void drawCube()
        {
            GPS.Clear(Color.White);
            myDrawMesh();




            float f;
            bool valid = float.TryParse(textBox_X.Text, out f);//check value is valid
            myEye.X = valid ? f : 0f;
            valid = float.TryParse(textBox_Y.Text, out f);
            myEye.Y = valid ? f : 0f;
            valid = float.TryParse(textBox_Z.Text, out f);
            myEye.Z = valid ? f : 0f;

            A.moveEye(myEye.X, myEye.Y, myEye.Z);
            B.moveEye(myEye.X, myEye.Y, myEye.Z);
            C.moveEye(myEye.X, myEye.Y, myEye.Z);
            D.moveEye(myEye.X, myEye.Y, myEye.Z);
            E.moveEye(myEye.X, myEye.Y, myEye.Z);
            F.moveEye(myEye.X, myEye.Y, myEye.Z);
            G.moveEye(myEye.X, myEye.Y, myEye.Z);
            H.moveEye(myEye.X, myEye.Y, myEye.Z);

            myDrawPoint(A.X_2D, A.Y_2D);
            myDrawPoint(B.X_2D, B.Y_2D);
            myDrawPoint(C.X_2D, C.Y_2D);
            myDrawPoint(D.X_2D, D.Y_2D);
            myDrawPoint(E.X_2D, E.Y_2D);
            myDrawPoint(F.X_2D, F.Y_2D);
            myDrawPoint(G.X_2D, G.Y_2D);
            myDrawPoint(H.X_2D, H.Y_2D);

            myDrawLine(A.X_2D,A.Y_2D,B.X_2D,B.Y_2D);
            myDrawLine(C.X_2D, C.Y_2D, D.X_2D, D.Y_2D);
            myDrawLine(E.X_2D, E.Y_2D, F.X_2D, F.Y_2D);
            myDrawLine(G.X_2D, G.Y_2D, H.X_2D, H.Y_2D);

            myDrawLine(A.X_2D, A.Y_2D, C.X_2D, C.Y_2D);
            myDrawLine(B.X_2D, B.Y_2D, D.X_2D, D.Y_2D);
            myDrawLine(E.X_2D, E.Y_2D, G.X_2D, G.Y_2D);
            myDrawLine(F.X_2D, F.Y_2D, H.X_2D, H.Y_2D);

            myDrawLine(A.X_2D, A.Y_2D, E.X_2D, E.Y_2D);
            myDrawLine(C.X_2D, C.Y_2D, G.X_2D, G.Y_2D);
            myDrawLine(B.X_2D, B.Y_2D, F.X_2D, F.Y_2D);
            myDrawLine(D.X_2D, D.Y_2D, H.X_2D, H.Y_2D);

            //myDrawLine(myEye.X,myEye.Y,myEye.Z);
            Debug.WriteLine("eye X: " + myEye.X + " , Y: " + myEye.Y + " , Z: " + myEye.Z);
            Debug.WriteLine("A X: " + A.X_2D + " , Y: " + A.Y_2D);
            Debug.WriteLine("B X: " + B.X_2D + " , Y: " + B.Y_2D);
            Debug.WriteLine("C X: " + C.X_2D + " , Y: " + C.Y_2D);
            Debug.WriteLine("D X: " + D.X_2D + " , Y: " + D.Y_2D);
            Debug.WriteLine("E X: " + E.X_2D + " , Y: " + E.Y_2D);
            Debug.WriteLine("F X: " + F.X_2D + " , Y: " + F.Y_2D);
            Debug.WriteLine("G X: " + G.X_2D + " , Y: " + G.Y_2D);
            Debug.WriteLine("H X: " + H.X_2D + " , Y: " + H.Y_2D);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drawCube();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            drawCube();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void trackBar_Scale_Scroll(object sender, EventArgs e)
        {
            scale = trackBar_Scale.Value;
            drawCube();
        }
    }
}
