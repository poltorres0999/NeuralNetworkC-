using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class Neuron
    {
        public double Value { get; set; }
        public double Bias { get; set; }
        public double Delta { get; set; }
        public List<Dendrite> Dendrites { get; set; }

        public Neuron ()
        {

            this.Dendrites = new List<Dendrite>();
        }

        public int GetDendriteCount ()
        {
            return this.Dendrites.Count;
        }

    } 
}