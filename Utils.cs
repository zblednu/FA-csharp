namespace firefly_algo
{
    public static class Utils 
    {
        static Random random = new Random();

        public static double Evaluate(double[] positionVector) {
            double res = 0;
            foreach (double coord in positionVector) {
                res += Math.Pow(coord, 2);
            }

            return 1/res;
        }

        public static double CalculateEuclideanDistance(double[] vector1, double[] vector2) {
            double dist = 0;
            for (int dimension = 0; dimension < vector1.Length; ++dimension) {
                dist += Math.Pow(vector1[dimension] - vector2[dimension], 2);
            }

            return Math.Sqrt(dist);
        } 

        public static double[] CalculateNewPositionVector(Firefly fireflyDimmer, Firefly fireflyBrighter, double distance, double attractiveness, double absorption, double randomizationFactor) {
            int dimensionality = fireflyDimmer.GetPositionVector().Length;
            double[] vector = new double[dimensionality];
            
            double[] brighterVector = fireflyBrighter.GetPositionVector();
            double[] dimmerVector = fireflyDimmer.GetPositionVector();

            for (int dimension = 0; dimension < dimensionality; ++dimension) {
                vector[dimension] = dimmerVector[dimension] + 
                                attractiveness * Math.Exp(-absorption * Math.Pow(distance, 2)) * (brighterVector[dimension] - dimmerVector[dimension]) +
                                randomizationFactor * GenerateRandomDouble(-0.5, 0.5);
            }

            return vector;
        }

        public static double GenerateRandomDouble(double min, double max) {
            return random.NextDouble() * (max - min) + min;
        }
    }
}