using System.Collections.Generic;

namespace NeuralNetwork
{

    class Layer: List<Neuron>{

        public Layer(int numNeuorns):base(numNeuorns){
            for(int i = 0; i < numNeuorns; i++)
            {
                this.Add(new Neuron());
            }
        }

    }

}
