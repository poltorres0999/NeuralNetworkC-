﻿using System;
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

        public double SigmoidFunction(double x)
        {
            return 1 / (1 + Math.Exp(-x));

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

            //Initialize the Input layer (dendridtes)

            for (int i = 0; i < InputNodes; i++) {
                for (int j = 0; j < HiddenLayersNodes[0]; j++) {
                    this.InputLayer[i].Dendrites.Add(new Dendrite());
                    this.InputLayer[i].Bias = 0;
                }  
            }


            //Create the dendrites, if it's the last layer, it will have as many dendrites as the neurons of the output layer
            //if not, it will have as many dendrites as the nodes of the next hidden layer.
            this.HiddenLayers.Last().ForEach((neuron) => {
                for (int k = 0; k < OutputNodes; k++){
                    neuron.Dendrites.Add(new Dendrite());
                }
            });

        }

        public void Train(TrainingExample trainingExample)
        {
            if (trainingExample.DesiredOutputs.Length != this.OutputNodes) {
                throw new Exception("The number of output nodes and the nodes of the example doesn't match");
            }

            this.Query(trainingExample);

            for (int i = 0; i < this.OutputNodes; i++) {
                this.OutputLayer[i].Delta = Math.Abs(this.OutputLayer[i].Value - trainingExample.DesiredOutputs[i]);
            }

            for (int i = this.HiddenLayers.Count; i >= 0; i--) {

                if (i == this.HiddenLayers.Count) {
                    for (int j = 0; j < HiddenLayers[i -1].Count; j++) {
                        for (int k = 0; k < this.OutputNodes; k++) {
                            this.HiddenLayers[i -1][j].Delta += Math.Abs((this.HiddenLayers[i -1][j].Value) -
                                (this.OutputLayer[k].Delta * this.HiddenLayers[i -1][j].Dendrites[k].Weight));
                        }
                    }
                } else  if (i == 0 ) {
                    for (int j = 0; j < this.InputNodes; j++) {
                        for (int k = 0; k < this.HiddenLayers[i].Count; k++) {
                            this.InputLayer[j].Delta += Math.Abs((this.InputLayer[j].Value) -
                                 (this.HiddenLayers[i][k].Delta * this.InputLayer[j].Dendrites[k].Weight));
                        }
                    }
                } else {
                    for (int j = 0; j < HiddenLayers[i - 1].Count; j++) {
                        for (int k = 0; k < this.HiddenLayers[i].Count; k++) {
                            this.HiddenLayers[i -1][j].Delta += Math.Abs((this.HiddenLayers[i -1][j].Value) -
                                 (this.HiddenLayers[i][k].Delta * this.HiddenLayers[i -1][j].Dendrites[k].Weight));
                        }
                    }
                }
            }

        }
        //TODO: nueron.value muest be 0 at the start of the loop/ return I think should be a bool
        public bool Query(TrainingExample trainingExample) {

            if (trainingExample.InitialValues.Length != this.InputLayer.Count) {
                throw new Exception("The number of initual values and the nodes of the input layer doesn't match");
            }

            for (int i = 0; i < trainingExample.InitialValues.Length; i++) {
                this.InputLayer[i].Value = trainingExample.InitialValues[i];
            }

            for (int l = 0; l < this.HiddenLayers.Count +1; l++) {
                //Calculates the input values for the first Hidden layer.
                if (l == 0) {
                    for (int i = 0; i < this.HiddenLayers[l].Count; i++) {
                        this.HiddenLayers[l][i].Value = 0;
                        for (int j = 0; j < this.InputLayer.Count; j++) {
                            this.HiddenLayers[l][i].Value += this.InputLayer[j].Value * this.InputLayer[j].Dendrites[i].Weight;
                        }
                        this.HiddenLayers[l][i].Value = SigmoidFunction(this.HiddenLayers[l][i].Value + this.HiddenLayers[l][i].Bias);
                    }
                //Calculates the input values for the Hidden Layers except the last one.
                } else if (l == this.HiddenLayers.Count) {
                    for (int i = 0; i < this.OutputNodes; i++) {
                        this.OutputLayer[i].Value = 0;
                        for (int j = 0; j < this.HiddenLayers[l - 1].Count; j++) {
                            this.OutputLayer[i].Value += this.HiddenLayers[l - 1][j].Value * this.HiddenLayers[l - 1][j].Dendrites[i].Weight;
                        }
                        this.OutputLayer[i].Value = SigmoidFunction(this.OutputLayer[i].Value + this.OutputLayer[i].Bias);
                    }
                } else
                {
                    //Calculates the input values for the last Hidden Layers.
                    for (int i = 0; i < this.HiddenLayers[l].Count; i++)
                    {
                        this.HiddenLayers[l][i].Value = 0;
                        for (int j = 0; j < this.HiddenLayers[l - 1].Count; j++)
                        {
                            this.HiddenLayers[l][i].Value += this.HiddenLayers[l - 1][j].Value * this.HiddenLayers[l - 1][j].Dendrites[i].Weight;
                        }
                        this.HiddenLayers[l][i].Value = SigmoidFunction(this.HiddenLayers[l][i].Value + this.HiddenLayers[l][i].Bias);
                    }
                }
               
                
            }

            double[] finalOutputs = new double[this.OutputNodes];

            for (int i = 0; i < this.OutputNodes; i++)
            {
                finalOutputs[i] = this.OutputLayer[i].Value;
            }

            int maxIndex = 0;
            double aux = 0.0;
            for (int i = 0; i < this.OutputNodes; i++)
            {
                if (finalOutputs[i] > aux)
                {
                    aux = finalOutputs[i];
                    maxIndex = i;
                }
            }

            return maxIndex == trainingExample.ResultIndex;
                   
        }
    }
}
