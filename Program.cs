namespace firefly_algo {
    public class Program {
        public static void Main() {
            int populationSize = 30;
            int maxIterations = 500; 
            int dimensionality = 2;

            double attractiveness = 1;
            double absorption = 0.01;
            double randomizationFactor = 1;

            double searchSpaceMin = -100;
            double searchSpaceMax = 100;

            var algorithm = new FireflyAlgorithm(populationSize, dimensionality, searchSpaceMin, searchSpaceMax, attractiveness, absorption, randomizationFactor);
            System.Console.WriteLine(algorithm.GetBestFit().CalculateBrightness());
            algorithm.SimulateMovement(maxIterations);
            System.Console.WriteLine(algorithm.GetBestFit().CalculateBrightness());

        }
    }
}
