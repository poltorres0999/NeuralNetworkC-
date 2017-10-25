using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    class Layer
    {
        private List<Neuron> Neurons { get; set; }
        
        public Layer (int numNeuorns)
        {
            this.Neurons = new List<Neuron>(numNeuorns);
        }

        public int GetNeuronsCount ()
        {
            return this.Neurons.Count;
        }


    }
}
