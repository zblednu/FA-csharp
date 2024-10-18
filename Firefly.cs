namespace firefly_algo
{
    public class Firefly
    {
        private double[] positionVector;
        private readonly double searchSpaceMin;
        private readonly double searchSpaceMax;

        public Firefly(int dimensionality, double searchSpaceMin, double searchSpaceMax) {
            positionVector = new double[dimensionality];
            this.searchSpaceMin = searchSpaceMin;
            this.searchSpaceMax = searchSpaceMax;

            for (int dimension = 0; dimension < dimensionality; ++dimension) {
                positionVector[dimension] = Utils.GenerateRandomDouble(searchSpaceMin, searchSpaceMax);
            }
        }

        public double[] GetPositionVector() {
            return positionVector;
        }

        public double CalculateBrightness() {
            return 1.0 / Utils.FitnessFunction(positionVector);
        }

        public void SetPositionVector(double[] vector) {
            for (int dimension = 0; dimension < positionVector.Length; ++dimension) {
                if (vector[dimension] < searchSpaceMin) {
                    positionVector[dimension] = searchSpaceMin;
                }
                else if (vector[dimension] > searchSpaceMax) {
                    positionVector[dimension] = searchSpaceMax;
                }
                else {
                    positionVector[dimension] = vector[dimension];
                }
            }
        }
    }
}