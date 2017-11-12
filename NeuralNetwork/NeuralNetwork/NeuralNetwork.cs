using System;
using System.Collections.Generic;
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
        private List<Layer> HiddenLayers;
        private double LearningRate;

        public NeuralNetwork (int InputNodes, int[] HiddenLayersNodes, int OutputNodes, double learningRate)
        {
            this.InputNodes = InputNodes;
            this.HiddenLayersNodes = HiddenLayersNodes;
            this.OutputNodes = OutputNodes;
            this.LearningRate = learningRate;

            this.InputLayer = new Layer(InputNodes);
            this.OutputLayer = new Layer(OutputNodes);
            this.HiddenLayers = new List<Layer>();

            //Initialize the Input layer (nodes and dendridtes)

            for (int i = 0; i < InputNodes; i++)
            {
                this.InputLayer.Neurons.Add(new Neuron());
                for (int j = 0; j < HiddenLayersNodes[1]; i++)
                {
                    this.InputLayer.Neurons[i].Dendrites.Add(new Dendrite());
                    this.InputLayer.Neurons[i].Bias = 0;
                }  
            }

            //Initialize the Output Layer (just nodes)

            for (int o = 0; o < OutputNodes; o++)
            {
                this.OutputLayer.Neurons.Add(new Neuron());
            }
            
            //Initialize the Hidden Layers (layers, nodes and dendrites)

            for (int i = 0; i < HiddenLayersNodes.Length; i++ )
            {
                //Add the layers to the Hidden Layer Array
                this.HiddenLayers.Add(new Layer(HiddenLayersNodes[i]));

                //Create the nodes for each layer
                for (int j = 0; j < HiddenLayersNodes[i]; j++)
                {
                    this.HiddenLayers[i].Neurons.Add(new Neuron);
                }

                //Create the dendrites, if it's the last layer, it will have as many dendrites as the neurons of the output layer
                //if not, it will have as many dendrites as the nodes of the next hidden layer.
                if (i == HiddenLayersNodes.Length - 1)
                {
                    this.HiddenLayers[i].Neurons.ForEach((neuron) =>
                    {
                        for (int k = 0; k < OutputNodes; k++)
                        {
                            neuron.Dendrites.Add(new Dendrite());
                        }

                    });
                }

                this.HiddenLayers[i].Neurons.ForEach((neuron) =>
                {
                    for (int k = 0; k < HiddenLayersNodes[i+1]; k++)
                    {
                        neuron.Dendrites.Add(new Dendrite());
                    }
                    
                });
            }

        }


    }
}
