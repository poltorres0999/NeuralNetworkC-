using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NeuralNetwork

{
    class TrainingExample
    {
        public int [] InitialValues { get; set; }
        public int [] DesiredOutputs { get; set; }

        public TrainingExample(int[] TrainingValues) { }
        public TrainingExample(String FilePath) {
            var directoryInfo=new DirectoryInfo(AppContext.BaseDirectory);
            var a = new System.IO.StreamReader(new FileInfo(FilePath).OpenRead());
            a.ReadLine();
        }
    }
}
