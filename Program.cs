namespace firefly_algo {
    public class Program {
        public static void Main() {
            int populationSize = 10;
            int maxIterations = 100; 
            int dimensionality = 2;

            double attractiveness = 1;
            double absorption = 1;
            double randomizationFactor = 0.2;

            double searchSpaceMin = -40;
            double searchSpaceMax = 4.3;

            var algorithm = new FireflyAlgorithm(populationSize, dimensionality, searchSpaceMin, searchSpaceMax, attractiveness, absorption, randomizationFactor);
            Firefly bestfit = algorithm.GetBestFit();

            algorithm.SimulateMovement(maxIterations);
            Firefly afterBestfit = algorithm.GetBestFit();

            foreach (double pos in bestfit.GetPositionVector()) {
                System.Console.WriteLine(pos);
            }
            foreach (double pos in afterBestfit.GetPositionVector()) {
                System.Console.WriteLine(pos);
            }

            System.Console.WriteLine(bestfit == afterBestfit);
        }
    }
}
