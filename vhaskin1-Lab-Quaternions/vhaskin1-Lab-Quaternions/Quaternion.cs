using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Quaternion
{
    public double a { get; set; }
    public Vector3D vector;

    public Quaternion()
    {
        a = 1;
        vector = new Vector3D();
    }

    public Quaternion(Vector3D point)
    {
        a = 0;
        vector = new Vector3D(point.XValue, 
                              point.YValue, 
                              point.ZValue, 
                              point.WValue);
    }

    public Quaternion(double newA, Vector3D newVector)    {
        a = newA;
        vector = new Vector3D(newVector.XValue, 
                              newVector.YValue, 
                              newVector.ZValue, 
                              newVector.WValue);
    }
}
