namespace firefly_algo
{
    public static class Utils 
    {
        static Random random = new Random();

        public static double FitnessFunction(double[] positionVector) {
            double res = 0;
            foreach (double coord in positionVector) {
                res += Math.Pow(coord, 2);
            }

            return res;
        }

        public static double CalculateEuclideanDistance(double[] vector1, double[] vector2) {
            double dist = 0;
            for (int dimension = 0; dimension < vector1.Length; ++dimension) {
                dist += Math.Pow(vector1[dimension] - vector2[dimension], 2);
            }

            return dist;
        } 

        public static void UpdateFireflyPosition(Firefly fireflyDimmer, Firefly fireflyBrighter, double baseAttractiveness, double absorption, double randomizationFactor) {
            int dimensionality = fireflyDimmer.GetPositionVector().Length;
            double[] brighterVector = fireflyBrighter.GetPositionVector();
            double[] dimmerVector = fireflyDimmer.GetPositionVector();
            double[] tmp = dimmerVector;

            double euclideanDistance = Utils.CalculateEuclideanDistance(fireflyDimmer.GetPositionVector(), fireflyBrighter.GetPositionVector());
            double attractiveness = baseAttractiveness * Math.Exp(-absorption * Math.Pow(euclideanDistance, 2));

            for (int dimension = 0; dimension < dimensionality; ++dimension) {
                tmp[dimension] =    dimmerVector[dimension] +
                                    attractiveness * (brighterVector[dimension] - dimmerVector[dimension]) +
                                    randomizationFactor * GenerateRandomDouble(-0.5, 0.5);
            }

            fireflyDimmer.SetPositionVector(tmp);
        }

        public static double GenerateRandomDouble(double min, double max) {
            return random.NextDouble() * (max - min) + min;
        }
    }
}