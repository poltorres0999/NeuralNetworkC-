namespace NeuralNetwork
{
    internal class Dendrite
    {
        public double Weight;

        public Dendrite ()
        {
            CryptoRandom cr = new CryptoRandom();
            this.Weight = cr.RandomValue;
        }
    }
}