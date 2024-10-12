using System.Reflection.Metadata.Ecma335;

namespace firefly_algo
{
    public class FireflyAlgorithm
    {
        private List<Firefly> population;
        private readonly int size;
        private readonly double dimensionality;
        private readonly double[] spaceBoundaries;
        private readonly double attractiveness;
        private readonly double absorption;
        private readonly double randomizationFactor;


        public FireflyAlgorithm(int size, int dimensionality, double[] spaceBoundaries, double attractiveness, double absorption, double randomizationFactor) {
            this.size = size;
            this.dimensionality = dimensionality;
            this.spaceBoundaries = spaceBoundaries;
            this.attractiveness = attractiveness;
            this.absorption = absorption;
            this.randomizationFactor = randomizationFactor;
            population = new List<Firefly>();

            for (int i = 0; i < size; ++i) {
                population.Add(new Firefly(dimensionality, spaceBoundaries));
            }
        }

        public void SimulateMovement(int maxIterations) {
            for (int i = 0; i < maxIterations; ++i) {
                foreach (Firefly firefly1 in population) {
                    foreach (Firefly firefly2 in population) {
                        if (firefly1 == firefly2) {
                            continue;
                        }
                        else if (firefly2.GetBrightness() > firefly1.GetBrightness()) {
                            double euclideanDistance = Utils.CalculateEuclideanDistance(firefly1, firefly2);

                            for (int dimension = 0; dimension < dimensionality; ++dimension) {
                                double newPosition = Utils.CalculateNewPosition(firefly1, firefly2, dimension, euclideanDistance, attractiveness, absorption, randomizationFactor); 
                                firefly1.SetPosition(dimension, newPosition);
                            }
                        }
                    }
                }
            }
        }

        public Firefly GetBestFit() {
            double min = population[0].GetBrightness();
            Firefly bestFit = population[0];
            foreach (Firefly firefly in population) {
                if (firefly.GetBrightness() < min) {
                    min = firefly.GetBrightness();
                    bestFit = firefly;
                }
            }

            return bestFit;
        }
    }
}