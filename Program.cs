namespace firefly_algo {
    public class Program {
        public static void Main() {
            int populationSize = 30;
            int maxIterations = 30; 
            int dimensionality = 2;

            double attractiveness = 1;
            double absorption = 1;
            double randomizationFactor = 0.2;

            double searchSpaceMin = -4;
            double searchSpaceMax = 4.3;

            var algorithm = new FireflyAlgorithm(populationSize, dimensionality, searchSpaceMin, searchSpaceMax, attractiveness, absorption, randomizationFactor);

            System.Console.WriteLine(algorithm.GetBestFit().CalculateBrightness());
            algorithm.SimulateMovement(maxIterations);
            System.Console.WriteLine(algorithm.GetBestFit().CalculateBrightness());
        }
    }
}
