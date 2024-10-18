namespace firefly_algo {
    public class Program {
        public static void Main() {
            int populationSize = 10;
            int maxIterations = 100; 
            int dimensionality = 2;

            double attractiveness = 1;
            double absorption = 0.01;
            double randomizationFactor = 0.2;

            double searchSpaceMin = -40;
            double searchSpaceMax = 40.3;

            var algorithm = new FireflyAlgorithm(populationSize, dimensionality, searchSpaceMin, searchSpaceMax, attractiveness, absorption, randomizationFactor);

            System.Console.WriteLine(algorithm.GetBestFit().CalculateBrightness());
            algorithm.SimulateMovement(maxIterations);
            System.Console.WriteLine(algorithm.GetBestFit().CalculateBrightness());
        }
    }
}
