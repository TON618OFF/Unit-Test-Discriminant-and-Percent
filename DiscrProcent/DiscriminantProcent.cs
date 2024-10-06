using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscrProcent
{
    public class DiscriminantProcent
    {

        public static double[] CorniDiscriminanta(double a, double b, double c)
        {
            double discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                return new double[0];
            }
            else if (discriminant == 0)
            {
                double sqrt = -b / (2 * a);
                return new double[] { sqrt };
            }
            else
            {
                double sqrtD = Math.Sqrt(discriminant);
                double sqrt1 = (-b + sqrtD) / (2 * a);
                double sqrt2 = (-b - sqrtD) / (2 * a);
                return new double[] { sqrt1, sqrt2 };
            }
        }

        public static double CalcProcent(double num, double procent)
        {
            return num * procent / 100;
        }

    }
}
