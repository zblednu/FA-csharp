namespace firefly_algo {
    public class Program {
        public static void Main() {
            int populationSize = 10;
            int maxIterations = 100; 
            int dimensionality = 2;

            double attractiveness = 1;
            double absorption = 1;
            double randomizationFactor = 0.2;

            double spaceUpperLimit = 2;
            double spaceLowerLimit = -2;
            double[] boundaries = {spaceLowerLimit, spaceUpperLimit};

            var algorithm = new FireflyAlgorithm(populationSize, dimensionality, boundaries, attractiveness, absorption, randomizationFactor);
            algorithm.SimulateMovement(maxIterations);

            Firefly bestfit = algorithm.GetBestFit();
            foreach (double pos in bestfit.GetPosition()) {
                System.Console.WriteLine(pos);
            }
        }
    }
}
