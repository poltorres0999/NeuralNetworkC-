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
        public double performance;

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

        public Boolean SingleQuery (int[] inputValues)
        {
            if (this.NnToTest.Query(new TrainingExample(inputValues))) {
                
                return true;

            } else {
               

                return false;
            }
        }

        public void Query ()
        {
            String line;
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"TrainingExamples/" + this.FileName);
            int Counter = 0;
            int CorrectValues = 0;
            while ((line = file.ReadLine()) != null)
            {
                int[] allValues = Array.ConvertAll(line.Split(","), s => int.Parse(s));
                if (SingleQuery(allValues)) {
                    CorrectValues++;
                }
                Counter++;
                
            }

            this.performance = CorrectValues / Counter;
            System.Console.WriteLine("*****************************************************", Environment.NewLine);
            System.Console.WriteLine("Performance: {0}{1}", this.performance, Environment.NewLine);
            System.Console.WriteLine("Correct values: {0}{1}", CorrectValues, Environment.NewLine);
            System.Console.WriteLine("Iterations: {0}{1}", Counter, Environment.NewLine);
            System.Console.WriteLine("*****************************************************", Environment.NewLine);


        }

        public static void Main ()
        {
            Test test1 = new Test(784, 10, new int[] { 50, 25, 100 } , 0.4, "mnist_train_100.csv");
            test1.Train();
           
            test1.Query();
            System.IO.StreamReader file = new System.IO.StreamReader(@"TrainingExamples/" + "mnist_train_100.csv");
            int[] allValues = Array.ConvertAll(file.ReadLine().Split(","), s => int.Parse(s));
            test1.SingleQuery(allValues);
        }


    }
}
