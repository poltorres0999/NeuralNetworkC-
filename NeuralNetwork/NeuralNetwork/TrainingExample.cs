using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NeuralNetwork

{
    class TrainingExample {
        public int [] InitialValues { get; set; }
        public double [] DesiredOutputs { get; set; }
        public int ResultIndex;

        public TrainingExample(int[] TrainingValues) {

            this.DesiredOutputs = new double[10];
            this.DesiredOutputs[TrainingValues[0]] = 0.99;
            this.ResultIndex = TrainingValues[0];
            this.InitialValues = TrainingValues.Skip(1).ToArray();
             
        }
    }
}
