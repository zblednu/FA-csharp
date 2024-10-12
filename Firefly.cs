namespace firefly_algo
{
    public class Firefly
    {
        private double[] position;

        public Firefly(int dimensionality, double[] boundaries) {
            position = new double[dimensionality];

            for (int i = 0; i < dimensionality; ++i) {
                position[i] = Utils.GenerateRandomDouble(boundaries[0], boundaries[1]);
            }
        }

        public double[] GetPosition() {
            return position;
        }

        public double GetBrightness() {
            return Utils.Evaluate(position);
        }

        public void SetPosition(int dimension, double value) {
            position[dimension] = value;
        }
    }
}