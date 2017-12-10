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
            new System.IO.StreamReader(@"TrainingExamples/" + this.FileName);
            while ((line = file.ReadLine()) != null)
            {
                int[] allValues = Array.ConvertAll(line.Split(","), s => int.Parse(s));
                this.NnToTest.Train(new TrainingExample(allValues));
            }
        }

        public void SingleQuery (int[] inputValues)
        {
            if (this.NnToTest.Query(new TrainingExample(inputValues))) {
                System.Console.WriteLine("The neural Network has found the correct value {0}", Environment.NewLine);
                System.Console.WriteLine("Expected value: {0}{1}", inputValues[0], Environment.NewLine);
            } else {
                System.Console.WriteLine("The neural Network hasn't found the correct value {0}", Environment.NewLine);
            }
        }

        public void Query ()
        {
            String line;
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"../../TrainingExamples/" + this.FileName);
            while ((line = file.ReadLine()) != null)
            {
                int[] allValues = Array.ConvertAll(line.Split("s"), s => int.Parse(s));
                SingleQuery(allValues);
            }
        }

        public static void Main ()
        {
            Test test1 = new Test(784, 10, new int[] { 100, 50, 100 } , 0.2, "mnist_test_10.csv");
            test1.Train();
            test1.Query();
        }


    }
}
