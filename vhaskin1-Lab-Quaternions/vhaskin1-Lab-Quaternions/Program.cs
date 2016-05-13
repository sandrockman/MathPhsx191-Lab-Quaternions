using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1: Operations");
        Console.WriteLine("2: Rotation");
        Console.Write("Enter Choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch(choice)
        {
            case 1:
                Calculations();
                break;
            case 2:
                Rotations();
                break;
            default:
                Console.WriteLine("incorrect input.");
                break;
        }
    }

    static void Calculations()
    {
        //quaternion 1
        double aA, aX, aY, aZ;
        aA = aX = aY = aZ = 0;
        //quaternion 2
        double bA, bX, bY, bZ;
        bA = bX = bY = bZ = 0;
        //read in quaterion 1
        Console.Write("\nPlease enter your quaternion1 A value: ");
        aA = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your quaternion1 X (or b) value: ");
        aX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your quaternion1 Y (or c) value: ");
        aY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your quaternion1 Z (or d) value: ");
        aZ = Convert.ToDouble(Console.ReadLine());
        //read in quaternion 2
        Console.Write("\nPlease enter your quaternion2 A value: ");
        bA = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your quaternion2 X (or b) value: ");
        bX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your quaternion2 Y (or c) value: ");
        bY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your quaternion2 Z (or d) value: ");
        bZ = Convert.ToDouble(Console.ReadLine());
        //create quaternions
        Quaternion P = new Quaternion(aA, new Vector3D(aX, aY, aZ, 1));
        Quaternion Q = new Quaternion(bA, new Vector3D(bX, bY, bZ, 1));
        //print out quaternions
        Console.WriteLine("\nQuaternion 1, or P, is ["+ P.a + ", <" + P.vector.XValue + ", "+ 
                                                    P.vector.YValue+", "+ P.vector.ZValue+">]");
        Console.WriteLine("Quaternion 1, or Q, is ["+ Q.a + ", <" + Q.vector.XValue + ", "+ 
                                                    Q.vector.YValue+", "+ Q.vector.ZValue+">]");
        //addition example
        Quaternion plus = P + Q;
        Console.WriteLine("\nP + Q = [" + plus.a + ", <" + plus.vector.XValue + ", " +
                                        plus.vector.YValue + ", " + plus.vector.ZValue + ">]");

        Quaternion minus = P - Q;
        Console.WriteLine("\nP - Q = [" + minus.a + ", <" + minus.vector.XValue + ", " +
                                        minus.vector.YValue + ", " + minus.vector.ZValue + ">]");
        //scalar multiplication
        Console.Write("\nPlease enter a scalar value: ");
        double scalar = Convert.ToDouble(Console.ReadLine());
        Quaternion scaleP = scalar & P;
        Console.WriteLine("Scalar multiplication of k = " + scalar + " and P");
        Console.WriteLine("kP = [" + scaleP.a + ", <" + scaleP.vector.XValue + ", " +
                                        scaleP.vector.YValue + ", " + scaleP.vector.ZValue + ">]");
        //quaternion multiplication
        Quaternion mult = P * Q;
        Console.WriteLine("\nP * Q = [" + mult.a + ", <" + mult.vector.XValue + ", " +
                                        mult.vector.YValue + ", " + mult.vector.ZValue + ">]");
        //show magnitude
        double  mag = Quaternion.GetMagnitude(P);
        Console.WriteLine("\nThe magnitude of P is: " + mag);
        //show conjugate
        Quaternion conj = Quaternion.GetConjugate(P);
        Console.WriteLine("\nThe conjugate of P is: [" + conj.a + ", <" + conj.vector.XValue + ", " +
                                        conj.vector.YValue + ", " + conj.vector.ZValue + ">]");
        //show inverse
        Quaternion inv = !P;
        Console.WriteLine("\nThe inverse of P is: [" + inv.a + ", <" + inv.vector.XValue + ", " +
                                        inv.vector.YValue + ", " + inv.vector.ZValue + ">]");

    }

    static void Rotations()
    {
        //point
        double pX, pY, pZ;
        pX = pY = pZ = 0;
        //axis of rotation parallel
        double aX, aY, aZ;
        aX = aY = aZ = 0;
        double angle = 0;
        Console.WriteLine("We will be rotating a point around the axis parallel to a vector by an angle.");
        Console.Write("Please enter your point X value: ");
        pX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your point Y value: ");
        pY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your point Z value: ");
        pZ = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nPlease enter your axis X value: ");
        aX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your axis Y value: ");
        aY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter your axis Z value: ");
        aZ = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nPlease enter your angle to rotate the point in degrees: ");
        angle = Convert.ToDouble(Console.ReadLine());

        Vector3D point = new Vector3D(pX, pY, pZ, 1);
        Vector3D axis = new Vector3D(aX, aY, aZ, 1);
        Quaternion pDash = Quaternion.Rotation(point, axis, D2R(angle));
        Console.WriteLine("\nThe rotated point P' is: [" + pDash.a + ", <" + pDash.vector.XValue + ", " +
                                        pDash.vector.YValue + ", " + pDash.vector.ZValue + ">]");
    }

    public static double D2R(double angle)
    {
        return (angle * Math.PI / 180);
    }
}
