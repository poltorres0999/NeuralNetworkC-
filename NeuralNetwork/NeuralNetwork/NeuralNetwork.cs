using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    class NeuralNetwork
    {
        private int InputNodes;
        private int[] HiddenLayersNodes;
        private int OutputNodes;

        private Layer InputLayer;
        private Layer OutputLayer;
        private LayerList HiddenLayers;
        private double LearningRate;

        public double SigmoidFunction(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }

        public NeuralNetwork (int InputNodes, int[] HiddenLayersNodes, int OutputNodes, double learningRate)
        {
            this.InputNodes = InputNodes;
            this.HiddenLayersNodes = HiddenLayersNodes;
            this.OutputNodes = OutputNodes;
            this.LearningRate = learningRate;

            this.InputLayer = new Layer(InputNodes);
            this.OutputLayer = new Layer(OutputNodes);
            this.HiddenLayers = new LayerList(HiddenLayersNodes);

            //Initialize the Input layer (nodes and dendridtes)

            for (int i = 0; i < InputNodes; i++)
            {
                this.InputLayer.Add(new Neuron());
                for (int j = 0; j < HiddenLayersNodes[1]; i++)
                {
                    this.InputLayer[i].Dendrites.Add(new Dendrite());
                    this.InputLayer[i].Bias = 0;
                }  
            }

            //Initialize the Output Layer (just nodes)

            for (int o = 0; o < OutputNodes; o++)
            {
                this.OutputLayer.Add(new Neuron());
            }

            //Initialize the Hidden Layers (layers, nodes and dendrites)

            //Create the dendrites, if it's the last layer, it will have as many dendrites as the neurons of the output layer
            //if not, it will have as many dendrites as the nodes of the next hidden layer.
            this.HiddenLayers.Last().ForEach((neuron) => 
            {
                for (int k = 0; k < OutputNodes; k++){
                    neuron.Dendrites.Add(new Dendrite());
                }
            });

        }

        public void Train(TrainingExample a) { }
        public void Query(TrainingExample a) { }


    }
}
