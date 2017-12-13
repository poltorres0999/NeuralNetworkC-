using System.Collections.Generic;

namespace NeuralNetwork{

    class LayerList:List<Layer> {

        public LayerList(int[] hiddenLayers):base(hiddenLayers.Length){
            for (int i=0; i < hiddenLayers.Length; i++) {
                var layer = new Layer(hiddenLayers[i]);
                if (i < hiddenLayers.Length - 1) {
                    for (int k = 0; k < hiddenLayers[i]; k++) {
                        for (int j = 0; j < hiddenLayers[i + 1]; j++){
                            layer[k].Dendrites.Add(new Dendrite());
                        }
                    }
                    
                }
                this.Add(layer);
            }
        }

    }

}
