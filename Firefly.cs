namespace firefly_algo
{
    public class Firefly
    {
        private double xPos;
        private double yPos;
        static Random random = new Random();

        public Firefly(double min, double max) {
            xPos = GeneratePosition(min, max);
            yPos = GeneratePosition(min, max); 
        }

        private static double GeneratePosition(double min, double max) {
            double res = random.NextDouble() * (max - min) + min;

            return res;
        }

        public string GetPos() {
            return $"({xPos}; {yPos})";
        }
    }
}