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
    /// <summary>
    /// add overload
    /// </summary>
    /// <param name="q1"></param>
    /// <param name="q2"></param>
    /// <returns></returns>
    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion((q1.a + q2.a), new Vector3D(q1.vector.XValue + q2.vector.XValue,
                                                          q1.vector.YValue + q2.vector.YValue,
                                                          q1.vector.ZValue + q2.vector.ZValue, 1));
    }
    /// <summary>
    /// subtract
    /// </summary>
    /// <param name="q1"></param>
    /// <param name="q2"></param>
    /// <returns></returns>
    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion((q1.a - q2.a), new Vector3D(q1.vector.XValue - q2.vector.XValue,
                                                          q1.vector.YValue - q2.vector.YValue,
                                                          q1.vector.ZValue - q2.vector.ZValue, 1));
    }

    /// <summary>
    /// 1st scalar multiply
    /// </summary>
    /// <param name="k1"></param>
    /// <param name="q1"></param>
    /// <returns></returns>
    public static Quaternion operator &(double k1, Quaternion q1)
    {
        return new Quaternion((k1 * q1.a), new Vector3D(q1.vector.XValue * k1,
                                                        q1.vector.YValue * k1,
                                                        q1.vector.ZValue * k1, 1));
    }
    /// <summary>
    /// second scalar multiply
    /// </summary>
    /// <param name="q1"></param>
    /// <param name="k1"></param>
    /// <returns></returns>
    public static Quaternion operator &(Quaternion q1, double k1)
    {
        return new Quaternion((k1 * q1.a), new Vector3D(q1.vector.XValue * k1,
                                                        q1.vector.YValue * k1,
                                                        q1.vector.ZValue * k1, 1));
    }

    //multiplication of two quaternions
    // [a1*a2 - v1*v2 , a1*v2 + a2*v1 + (v1 x v2) ]
    /// <summary>
    /// multiplication of two quaternions; order matters
    /// </summary>
    /// <param name="vector1">first vector</param>
    /// <param name="vector2">second vector</param>
    /// <returns>double</returns>
    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double newA = (q1.a * q2.a) - (q1.vector * q2.vector);
        Vector3D newV = (q1.a & q2.vector) + (q2.a & q1.vector) + (q1.vector / q2.vector);


        return new Quaternion(newA, newV);
    }
    /// <summary>
    /// magnitude of quaternion aka the Modulus
    /// </summary>
    /// <param name="q1"></param>
    /// <returns></returns>
    public static double GetMagnitude(Quaternion q1)
    {
        return Math.Sqrt((q1.a * q1.a) + (q1.vector.GetMagnitude() * q1.vector.GetMagnitude()));
    }
    /// <summary>
    /// conjugate of quaternion
    /// </summary>
    /// <param name="q1"></param>
    /// <returns></returns>
    public static Quaternion GetConjugate(Quaternion q1)
    {
        return new Quaternion(q1.a, (-1) & q1.vector);
    }
    /// <summary>
    /// inverse of quaternion.
    /// </summary>
    /// <param name="q1"></param>
    /// <returns></returns>
    public static Quaternion operator !(Quaternion q1)
    {
        double mag = Quaternion.GetMagnitude(q1);
        Quaternion conjugate = Quaternion.GetConjugate(q1);
        double oneOverMagSquared = 1 / (mag * mag);

        return oneOverMagSquared & conjugate;
    }

    /// <summary>
    /// Rotate a point around a unit vector parallel to the axis vector by angle theta
    /// </summary>
    /// <param name="point">point to be rotated</param>
    /// <param name="axis">axis vector to be rotated around</param>
    /// <param name="theta">angle theta to rotate point, in a right-hand system.</param>
    /// <returns></returns>
    public static Quaternion Rotation(Vector3D point, Vector3D axis, double theta)
    {
        Quaternion p = new Quaternion(point);
        Quaternion q = new Quaternion(Math.Cos(theta / 2), (Math.Sin(theta / 2) & !axis));
        Quaternion qStar = Quaternion.GetConjugate(q);

        Quaternion pDash = (q * (p * qStar));
        return pDash;
    }
}
