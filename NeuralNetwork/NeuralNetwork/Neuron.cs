using System;
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
            Random r = new Random();
          
            this.Bias = r.NextDouble();
            this.Dendrites = new List<Dendrite>();
        }

        public int GetDendriteCount 
        {
            get
            {
                return Dendrites.Count;
            }
        }

    } 
}