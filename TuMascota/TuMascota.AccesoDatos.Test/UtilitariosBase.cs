using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuMascota.AccesoDatos.Test
{
    public static class UtilitariosBase
    {
        private static readonly Random random = new Random();
        public static double RandomNumberDecimalBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
        public static double RandomNumberDecimalSeedBetween(double minValue, double maxValue)
        {
            var ran = new Random(Guid.NewGuid().GetHashCode());
            var next = ran.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
        public static int RandomNumberIntegerBetween(int minValue, int maxValue)
        {
            var next = random.Next(minValue, maxValue);
            return next;
        }
        public static int RandomNumberIntegerSeedBetween(int minValue, int maxValue)
        {
            var ran = new Random(Guid.NewGuid().GetHashCode());
            var next = ran.Next();
            return minValue + (next * (maxValue - minValue));
        }
        public static bool RandomBoolNumber()
        {
            return (random.Next(0, 1) > 0);
        }
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
