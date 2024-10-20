using System.Xml.XPath;

namespace firefly_algo {
    public class Program {
        public static void Main() {
            int populationSize = 30;
            int dimensionality = 2;
            int maxIterations = 500;
            double epsilon = 1e-5;
            int numberOfRuns = 50;

            double attractiveness = 1;
            double absorption = 1;
            double randomizationFactor = 0.2;

            double searchSpaceMin = -5;
            double searchSpaceMax = 5;


            double[] parametervalues = [0.1, 0.5, 1];
            for (int experimentNumber = 0; experimentNumber < 3; experimentNumber++) {
                int[] results = new int[numberOfRuns];
                attractiveness = parametervalues[experimentNumber];
                for (int i = 0; i < numberOfRuns; ++i) {
                    var algorithm = new FireflyAlgorithm(populationSize, dimensionality, searchSpaceMin, searchSpaceMax, attractiveness, absorption, randomizationFactor, epsilon);
                    results[i] = algorithm.SimulateMovement(maxIterations);
                }

                double[] data = results.Select(x => (double)x).ToArray();
                var hist = new ScottPlot.Statistics.Histogram(data, 10);
                var plt = new ScottPlot.Plot();
                var barPlot = plt.Add.Bars(hist.Bins, hist.Counts);

                foreach (var bar in barPlot.Bars) {
                    bar.Size = hist.BinSize * 0.8;  // Bars slightly narrower than the bins
                }

                plt.Axes.Margins(bottom: 0);
                plt.YLabel("Frequency");
                plt.XLabel("Iterations");

                plt.SavePng($"histogram{experimentNumber}.png", 600, 400);
            }
        }
    }
}
