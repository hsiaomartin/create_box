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
        Graphics GP_XYZ,GP_X,GP_Y,GP_Z,GP_Test;
        int X0;
        int Y0;
        int scale = 80;
        public Form1()
        {
            InitializeComponent();
            GP_XYZ = panel1.CreateGraphics();
            X0 = panel1.Width / 2; //center x
            Y0 = panel1.Height / 2;//center y

            GP_X = panel2.CreateGraphics();
            GP_Y = panel3.CreateGraphics();
            GP_Z = panel4.CreateGraphics();
           
        }
        public void myDrawMesh(Graphics graphics)
        {
            Pen grayPen = new Pen(Color.FromArgb(80,128,128,128), 1);
            for (int i = 0; i<=panel1.Width; i+=10)
                graphics.DrawLine(grayPen, i,0 ,i, panel1.Width);
            for (int i = 0; i <= panel1.Height; i += 10)
                graphics.DrawLine(grayPen,  0, i, panel1.Width,i);
            myDrawPoint(graphics, 0,0);
            graphics.DrawLine(new Pen(Color.Red, 2), panel1.Width/2, panel1.Height/2, panel1.Width / 2+20, panel1.Height / 2);
            graphics.DrawLine(new Pen(Color.Green, 2), panel1.Width / 2, panel1.Height / 2, panel1.Width / 2, panel1.Height / 2 - 20);
        }
        public void myDrawPoint(Graphics graphics, float x, float y)
        {
            //GPS.FillEllipse(Brushes.Red, X0 - 3, Y0 - 3, 6, 6);
            graphics.FillEllipse(Brushes.Red, X0 + x*scale-2, Y0 + y*scale-2, 4, 4);
        }
        public void myDrawLine(Graphics graphics, float x0,float y0,float x1,float y1)
        {
            graphics.DrawLine(blackPen,X0+ x0*scale,Y0+ y0 * scale, X0+x1 * scale, Y0+y1 * scale);


        }
        public void drawCube(Graphics graphics,float x,float y,float z)
        {
            graphics.Clear(Color.White);

            myDrawMesh(graphics);

            A.moveEye(x, y, z);
            B.moveEye(x, y, z);
            C.moveEye(x, y, z);
            D.moveEye(x, y, z);
            E.moveEye(x, y, z);
            F.moveEye(x, y, z);
            G.moveEye(x, y, z);
            H.moveEye(x, y, z);

            myDrawPoint(graphics, A.X_2D, A.Y_2D);
            myDrawPoint(graphics, B.X_2D, B.Y_2D);
            myDrawPoint(graphics, C.X_2D, C.Y_2D);
            myDrawPoint(graphics, D.X_2D, D.Y_2D);
            myDrawPoint(graphics, E.X_2D, E.Y_2D);
            myDrawPoint(graphics, F.X_2D, F.Y_2D);
            myDrawPoint(graphics, G.X_2D, G.Y_2D);
            myDrawPoint(graphics, H.X_2D, H.Y_2D);

            myDrawLine(graphics, A.X_2D, A.Y_2D, B.X_2D, B.Y_2D);
            myDrawLine(graphics, C.X_2D, C.Y_2D, D.X_2D, D.Y_2D);
            myDrawLine(graphics, E.X_2D, E.Y_2D, F.X_2D, F.Y_2D);
            myDrawLine(graphics, G.X_2D, G.Y_2D, H.X_2D, H.Y_2D);

            myDrawLine(graphics, A.X_2D, A.Y_2D, C.X_2D, C.Y_2D);
            myDrawLine(graphics, B.X_2D, B.Y_2D, D.X_2D, D.Y_2D);
            myDrawLine(graphics, E.X_2D, E.Y_2D, G.X_2D, G.Y_2D);
            myDrawLine(graphics, F.X_2D, F.Y_2D, H.X_2D, H.Y_2D);

            myDrawLine(graphics, A.X_2D, A.Y_2D, E.X_2D, E.Y_2D);
            myDrawLine(graphics, C.X_2D, C.Y_2D, G.X_2D, G.Y_2D);
            myDrawLine(graphics, B.X_2D, B.Y_2D, F.X_2D, F.Y_2D);
            myDrawLine(graphics, D.X_2D, D.Y_2D, H.X_2D, H.Y_2D);
/*
            //myDrawLine(myEye.X,myEye.Y,myEye.Z);
            Debug.WriteLine("----------------------------------------------");
            Debug.WriteLine("eye X: " + x + " , Y: " + y + " , Z: " + z);
            Debug.WriteLine("A X: " + A.X_2D + " , Y: " + A.Y_2D);
            Debug.WriteLine("B X: " + B.X_2D + " , Y: " + B.Y_2D);
            Debug.WriteLine("C X: " + C.X_2D + " , Y: " + C.Y_2D);
            Debug.WriteLine("D X: " + D.X_2D + " , Y: " + D.Y_2D);
            Debug.WriteLine("E X: " + E.X_2D + " , Y: " + E.Y_2D);
            Debug.WriteLine("F X: " + F.X_2D + " , Y: " + F.Y_2D);
            Debug.WriteLine("G X: " + G.X_2D + " , Y: " + G.Y_2D);
            Debug.WriteLine("H X: " + H.X_2D + " , Y: " + H.Y_2D);
            Debug.WriteLine("----------------------------------------------");
*/
        }


        private void textBox_X_TextChanged(object sender, EventArgs e)
        {
            float f;
            bool valid = float.TryParse(textBox_X.Text, out f);//check value is valid
            myEye.X = valid ? f : 0f;
            //textBox_X.Text = myEye.X.ToString();

            drawCube(GP_XYZ, myEye.X, myEye.Y, myEye.Z);
            drawCube(GP_X, myEye.X, 0f, 0f);
            drawCube(GP_Y, 0f, myEye.Y, 0f);
            drawCube(GP_Z, 0f, 0f, myEye.Z);



            camera_Print(label_XYZ, myEye.X, myEye.Y, myEye.Z);
            camera_Print(label_X, myEye.X, 0f, 0f);
            camera_Print(label_Y, 0f, myEye.Y, 0f);
            camera_Print(label_Z, 0f, 0f, myEye.Z);
        }

        private void textBox_Y_TextChanged(object sender, EventArgs e)
        {
            float f;
            bool valid = float.TryParse(textBox_Y.Text, out f);//check value is valid
            myEye.Y = valid ? f : 0f;
            //textBox_Y.Text = (-myEye.Y).ToString();


            drawCube(GP_XYZ, myEye.X, myEye.Y, myEye.Z);
            drawCube(GP_X, myEye.X, 0f, 0f);
            drawCube(GP_Y, 0f, myEye.Y, 0f);
            drawCube(GP_Z, 0f, 0f, myEye.Z);



            camera_Print(label_XYZ, myEye.X, myEye.Y, myEye.Z);
            camera_Print(label_X, myEye.X, 0f, 0f);
            camera_Print(label_Y, 0f, myEye.Y, 0f);
            camera_Print(label_Z, 0f, 0f, myEye.Z);
        }

        private void textBox_Z_TextChanged(object sender, EventArgs e)
        {
            float f;
            bool valid = float.TryParse(textBox_Z.Text, out f);//check value is valid
            myEye.Z = valid ? f : 0f;
            //textBox_Z.Text = myEye.Z.ToString(); 

            drawCube(GP_XYZ, myEye.X, myEye.Y, myEye.Z);
            drawCube(GP_X, myEye.X, 0f, 0f);
            drawCube(GP_Y, 0f, myEye.Y, 0f);
            drawCube(GP_Z, 0f, 0f, myEye.Z);

            

            camera_Print(label_XYZ, myEye.X, myEye.Y, myEye.Z);
            camera_Print(label_X, myEye.X, 0f, 0f);
            camera_Print(label_Y, 0f, myEye.Y, 0f);
            camera_Print(label_Z, 0f, 0f, myEye.Z);
        }

        public void camera_Print(Label camera,float x,float y,float z)
        {
            camera.Text = "C : ( " + x + " , " + -y + " , " + z + " )";
        }



        private void Form1_Shown(object sender, EventArgs e)
        {
            drawCube(GP_XYZ, myEye.X, myEye.Y, myEye.Z);
            drawCube(GP_X, myEye.X, 0f, 0f);
            drawCube(GP_Y, 0f, myEye.Y, 0f);
            drawCube(GP_Z, 0f, 0f, myEye.Z);



            camera_Print(label_XYZ, myEye.X, myEye.Y, myEye.Z);
            camera_Print(label_X, myEye.X, 0f, 0f);
            camera_Print(label_Y, 0f, myEye.Y, 0f);
            camera_Print(label_Z, 0f, 0f, myEye.Z);
        }


        private void trackBar_Scale_Scroll(object sender, EventArgs e)
        {
            scale = trackBar_Scale.Value;
            drawCube(GP_XYZ, myEye.X, myEye.Y, myEye.Z);
            drawCube(GP_X, myEye.X, 0f,0f);
            drawCube(GP_Y, 0f, myEye.Y, 0f);
            drawCube(GP_Z, 0f, 0f, myEye.Z);



            camera_Print(label_XYZ, myEye.X, myEye.Y, myEye.Z);
            camera_Print(label_X, myEye.X, 0f, 0f);
            camera_Print(label_Y, 0f, myEye.Y, 0f);
            camera_Print(label_Z, 0f, 0f, myEye.Z);
        }
    }
}
