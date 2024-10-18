namespace firefly_algo
{
    public class FireflyAlgorithm
    {
        private List<Firefly> population;
        private readonly int size;
        private readonly int dimensionality;
        private readonly double searchSpaceMin;
        private readonly double searchSpaceMax;
        private readonly double attractiveness;
        private readonly double absorption;
        private readonly double randomizationFactor;


        public FireflyAlgorithm(int size, int dimensionality, double searchSpaceMin, double searchSpaceMax, double attractiveness, double absorption, double randomizationFactor) {
            this.size = size;
            this.dimensionality = dimensionality;
            this.searchSpaceMin = searchSpaceMin;
            this.searchSpaceMax = searchSpaceMax;
            this.attractiveness = attractiveness;
            this.absorption = absorption;
            this.randomizationFactor = randomizationFactor;
            population = new List<Firefly>();

            for (int i = 0; i < size; ++i) {
                population.Add(new Firefly(dimensionality, searchSpaceMin, searchSpaceMax));
            }
        }

        public void SimulateMovement(int maxIterations) {
            int[] dataX = new int[maxIterations];
            double[] dataY = new double[maxIterations];

            for (int i = 0; i < maxIterations; ++i) {
                foreach (Firefly firefly1 in population) {
                    foreach (Firefly firefly2 in population) {
                        if (firefly1 == firefly2) {
                            continue;
                        }
                        else if (firefly2.CalculateBrightness() > firefly1.CalculateBrightness()) {
                            double euclideanDistance = Utils.CalculateEuclideanDistance(firefly1.GetPositionVector(), firefly2.GetPositionVector());

                            double[] newPosition = Utils.CalculateNewPositionVector(firefly1, firefly2, euclideanDistance, attractiveness, absorption, randomizationFactor); 
                            firefly1.SetPositionVector(newPosition);
                        }
                    }
                }
                dataX[i] = i;
                dataY[i] = GetBestFit().CalculateBrightness();
            }

            var plt = new ScottPlot.Plot();
            plt.Add.Scatter(dataX, dataY);
            plt.Axes.AutoScale();
            plt.Title("Best Fitness Over Iterations");
            plt.XLabel("Iteration");
            plt.YLabel("Best Fitness");
            plt.SavePng("plots/fitness_over_iterations.png", 1000, 1000);

        }

        public Firefly GetBestFit() {
            Firefly bestFit = population[0];
            foreach (Firefly firefly in population) {
                if (firefly.CalculateBrightness() > bestFit.CalculateBrightness()) {
                    bestFit = firefly;
                }
            }

            return bestFit;
        }
    }
}