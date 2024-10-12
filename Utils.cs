using System.Data;

namespace firefly_algo
{
    public static class Utils 
    {
        static Random random = new Random();

        public static double Evaluate(double[] dimensions) {
            double res = 0;
            foreach (double coord in dimensions) {
                res += Math.Pow(coord, 2);
            }
            return 1/res;
        }
        public static double CalculateEuclideanDistance(Firefly firefly1, Firefly firefly2) {
            double res = 0;

            double[] position1 = firefly1.GetPosition();
            double[] position2 = firefly2.GetPosition();

            for (int i = 0; i < position1.Length; ++i) {
                res += Math.Pow(position1[i] - position2[i], 2);
            }

            return Math.Sqrt(res);
        } 
        public static double CalculateNewPosition(Firefly fireflyDimmer, Firefly fireflyBrighter, int dimension, double distance, double attractiveness, double absorption, double randomizationFactor) {
            double res =    fireflyDimmer.GetPosition()[dimension] + 
                            attractiveness * Math.Exp(-absorption * Math.Pow(distance, 2)) * (fireflyBrighter.GetPosition()[dimension] - fireflyDimmer.GetPosition()[dimension]) +
                            randomizationFactor * GenerateRandomDouble(-0.5, 0.5);
            return res;
        }
        public static double GenerateRandomDouble(double min, double max) {
            return random.NextDouble() * (max - min) + min;
        }
    }
}