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
        private readonly double epsilon;


        public FireflyAlgorithm(int size, int dimensionality, double searchSpaceMin, double searchSpaceMax, double attractiveness, double absorption, double randomizationFactor, double epsilon) {
            this.size = size;
            this.dimensionality = dimensionality;
            this.searchSpaceMin = searchSpaceMin;
            this.searchSpaceMax = searchSpaceMax;
            this.attractiveness = attractiveness;
            this.absorption = absorption;
            this.randomizationFactor = randomizationFactor;
            this.epsilon = epsilon;
            population = new List<Firefly>();

            for (int i = 0; i < size; ++i) {
                population.Add(new Firefly(dimensionality, searchSpaceMin, searchSpaceMax));
            }
        }

        public int SimulateMovement(int maxIterations) {
            int iterationsNum = 0;
            while (iterationsNum < maxIterations && GetBestFit().CalculateBrightness() > epsilon) {
                foreach (Firefly firefly1 in population) {
                    foreach (Firefly firefly2 in population) {
                        if (firefly2.CalculateBrightness() < firefly1.CalculateBrightness()) {
                            Utils.UpdateFireflyPosition(firefly1, firefly2, attractiveness, absorption, randomizationFactor); 
                        }
                    }
                }
                iterationsNum++;
            }

            return iterationsNum;
        }

        public Firefly GetBestFit() {
            Firefly bestFit = population[0];
            foreach (Firefly firefly in population) {
                if (firefly.CalculateBrightness() < bestFit.CalculateBrightness()) {
                    bestFit = firefly;
                }
            }

            return bestFit;
        }

        public void MakeSnapshot(string path) {
            var plt = new ScottPlot.Plot();
            plt.Axes.SetLimits(searchSpaceMin, searchSpaceMax, searchSpaceMin, searchSpaceMax);
            plt.Axes.AutoScale();
            plt.Add.Circle(
                xCenter: 0,
                yCenter: 0,
                radius: (searchSpaceMax - searchSpaceMin) / 2);

            double center = searchSpaceMin + (searchSpaceMax - searchSpaceMin)/2;
            var centerPoint = plt.Add.ScatterPoints(new double[] {0}, new double[] {0});
            centerPoint.Color = ScottPlot.Colors.Black;
            centerPoint.MarkerSize = 10;

            foreach (Firefly firefly in population) {
                double posX = firefly.GetPositionVector()[0];
                double posY = firefly.GetPositionVector()[1];
                var point = plt.Add.ScatterPoints(new double[] {posX}, new double[] {posY});
                point.Color = ScottPlot.Colors.Green;
            }
            var bestFit = plt.Add.Scatter(new double[] {GetBestFit().GetPositionVector()[0]}, new double[] {GetBestFit().GetPositionVector()[1]});
            bestFit.Color = ScottPlot.Colors.Red;

            plt.Title("Best Fitness Over Iterations");
            plt.XLabel("X");
            plt.YLabel("Y");
            plt.Axes.SquareUnits();

            plt.SavePng(path, 400, 300);
        }
    }
}