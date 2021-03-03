using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace create_box{
    class myPoint{
        private float x;
        private float y;
        private float z;

        private float x_2D;
        private float y_2D;
        public myPoint(float x,float y,float z){
            this.x = x;
            this.y = -y;
            this.z = z;
            x_2D = 0;
            y_2D = 0;
        }
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = -value; } }
        public float Z { get { return z; } set { z = value; } }
        public float X_2D { get { return x_2D; } }
        public float Y_2D { get { return y_2D; } }
        public void moveEye(float eyeX,float eyeY,float eyeZ) {
            
            x_2D = (eyeX + x) / ((eyeZ + z)==0? 1:(eyeZ + z)); //transfer 3d x to 2d x

            y_2D = (eyeY + y) / ((eyeZ + z) == 0 ? 1 : (eyeZ + z)); //transfer 3d y to 2d y
        }
    };
    
    
}
