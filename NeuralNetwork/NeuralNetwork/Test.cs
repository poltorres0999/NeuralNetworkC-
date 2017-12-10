using System;

namespace NeuralNetwork
{
    class Test
    {
        public NeuralNetwork NnToTest { get; set; }
        public int InoputNodes { get; set; }
        public int OutputNodes { get; set; }
        public int[] HiddenLayers { get; set; }
        public double LearningRate { get; set; }
        public String FileName { get; set; }    

        public Test(int InputNodes, int OutputNodes, int[] HiddenLayers, double LearningRate, String FileName)
        {
            this.InoputNodes = InoputNodes;
            this.OutputNodes = OutputNodes;
            this.HiddenLayers = HiddenLayers;
            this.LearningRate = LearningRate;
            this.FileName = FileName;

            this.NnToTest = new NeuralNetwork(InputNodes, HiddenLayers, OutputNodes, LearningRate);

        }

        public void Train ()
        {
            String line; 
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"../../TrainingExamples/" + this.FileName);
            while ((line = file.ReadLine()) != null)
            {
                int[] allValues = Array.ConvertAll(line.Split("s"), s => int.Parse(s));
                this.NnToTest.Train(new TrainingExample(allValues));
            }
        }

        

    }
}
