using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public class Network
    {
        public Network(int numOfInputs, HiddenLayersInfo hiddenLayers, int epoch, int numOfTransitFunc, double teachSpeed)
        {
            InitializeNetwork(numOfInputs, hiddenLayers, epoch, teachSpeed);
            TransitFuncChoosing(numOfTransitFunc);
        }


        #region Функция активации и ее методы

        private void TransitFuncChoosing(int i)
        {
            switch (i)
            {
                case 0:
                    TransitFuncOfNetwork = TransitFunctions.LinearFunction;
                    TransitFuncDerivativeOfNetwork = TransitFunctions.LinearFunctionDerivative;
                    break;
                case 1:
                    TransitFuncOfNetwork = TransitFunctions.HiperbolicTan;
                    TransitFuncDerivativeOfNetwork = TransitFunctions.HiperbolicTanDerivative;
                    break;
                case 2:
                    TransitFuncOfNetwork = TransitFunctions.LogisticFunction;
                    TransitFuncDerivativeOfNetwork = TransitFunctions.LogisticFunctionDerivative;
                    break;
                default:
                    TransitFuncOfNetwork = TransitFunctions.LinearFunction;
                    TransitFuncDerivativeOfNetwork = TransitFunctions.LinearFunctionDerivative;
                    break;
            }
        }

        protected delegate double TransitFunction(double input, double layerMultiplier);

        public static class TransitFunctions
        {
            public static double LinearFunction(double input, double multiplier = 1)
            {
                return input * multiplier;
            }

            public static double LinearFunctionDerivative(double input, double multiplier = 1)
            {
                return multiplier;
            }

            public static double HiperbolicTan(double input, double multiplier = 1)
            {
                return Math.Tanh(input * multiplier);
            }

            public static double HiperbolicTanDerivative(double input, double multiplier = 1)
            {
                return ((1 + HiperbolicTan(input, multiplier)) * (1 - HiperbolicTan(input, multiplier)));

            }

            public static double LogisticFunction(double input, double multiplier = 1)
            {
                return (1 / (1 + Math.Exp(-multiplier * input)));
            }

            public static double LogisticFunctionDerivative(double input, double multiplier = 1)
            {
                return (LogisticFunction(input, multiplier) * (1 - LogisticFunction(input, multiplier)));
            }
        }

        protected static TransitFunction TransitFuncOfNetwork { get; set; }
        protected static TransitFunction TransitFuncDerivativeOfNetwork { get; set; }

        #endregion

        protected HiddenLayersInfo HiddenLayers { get; set; }
        static protected double[] InputValues;
        static protected double[] OutputValues;
        static protected double[] TeachingOutputValues;
        static Layer[] Layers;
        public TrainingSet TrainSet { get; set; }
        int EpochNum { get; set; }
        static double TeachSpeed { get; set; }


        //Для одного входа и одного выхода
        public class TrainingSet
        {
            public List<double[]> X { get; private set; }
            public List<double[]> Y { get; private set; }
            public int OutputsCount { get; private set; }
            public int InputsCount { get; private set; }
            public int TeachSetLength { get; private set; }
            public double Multiplier { get; private set; }

            public TrainingSet(List<double[]> x, List<double[]> y)
            {
                OutputsCount = y.Count; InputsCount = x.Count;
                if (!IsArrayLengtsEqual(x, y)) throw new Exception("Длины входных массивов отличаюстя");
            }

            //Каждый элемент списка - массив данных для какого либо входа или выхода. Если их размеры одинаковы, то истина.
            private bool IsArrayLengtsEqual(List<double[]> x, List<double[]> y)
            {
                int[] count = new int[x.Count + y.Count];
                for (int i = 0; i < count.Length; i++)
                {
                    if (i < x.Count) count[i] = x[i].Length;
                    else count[i] = y[i - x.Count].Length;
                }
                if (count.Max() != count.Min()) return false;
                X = x; Y = y; TeachSetLength = count.Max(); Multiplier = Y.Select(z => z.Max()).Max();
                Y.Select(a => a.Select(b => b / Multiplier));
                return true;
            }


        }

        class Neuron
        {
            public struct NeuronInput
            {
                public double Value { get; set; }
                public double Weight { get; set; }
                public double Input { get { return Value * Weight; } }
                public NeuronInput(double value, double weight)
                {
                    Value = value;
                    Weight = weight;
                }
            }

            public NeuronInput[] Inputs { get; set; }
            public double Output { get; private set; }
            public double Sigma { get; private set; }

            public Neuron(NeuronInput[] input, double multiplier)
            {
                Inputs = input;
            }

            public Neuron(int numberOfLayer, double multiplier)
            {
                InitializeInputs(numberOfLayer);
            }

            private void InitializeInputs_FirstLayerNeuron()
            {
                Inputs = new NeuronInput[InputValues.Length];
            }

            private void InitializeInputs(int numOfThisLayer)
            {
                if (numOfThisLayer == 0) { InitializeInputs_FirstLayerNeuron(); return; }
                Inputs = new NeuronInput[Layers[numOfThisLayer - 1].NeuronsList.Length];
            }

            public void CalculateOutput(double multiplier)
            {
                this.Output = TransitFuncOfNetwork.Invoke(SumInputs(this.Inputs), multiplier);
            }


            public void CorrectWeights(int numberOfLayer, int numberOfThisNeuron)
            {
                CalculateSigma(numberOfLayer, numberOfThisNeuron);
                for (int i = 0; i < Inputs.Length; i++)
                {
                    double _PrevOutput;
                    if (numberOfLayer == 0) _PrevOutput = InputValues[i];
                    else _PrevOutput = Layers[numberOfLayer - 1].NeuronsList[i].Output;
                    Inputs[i].Weight = Inputs[i].Weight + TeachSpeed * Sigma * _PrevOutput;
                }


            }

            public void CorrectWeights(int numberOfLayer, int numberOfThisNeuron, double Y)
            {
                CalculateSigma_LastLayerNeuron(Y);
                for (int i = 0; i < Inputs.Length; i++)
                {
                    double _PrevOutput;
                    if (numberOfLayer == 0) _PrevOutput = InputValues[i];
                    else _PrevOutput = Layers[numberOfLayer - 1].NeuronsList[i].Output;
                    Inputs[i].Weight = Inputs[i].Weight + TeachSpeed * Sigma * _PrevOutput;
                }
            }

            private void CalculateSigma_LastLayerNeuron(double Y)
            {
                Sigma = (Y - Output) * TransitFuncDerivativeOfNetwork.Invoke(SumInputs(this.Inputs), 1);
            }

            private void CalculateSigma(int numberOfLayer, int numberOfThisNeuron)
            {
                double _partialSum = 0;
                for (int i = 0; i < Layers[numberOfLayer + 1].NeuronsList.Length; i++)
                {
                    _partialSum += Layers[numberOfLayer + 1].NeuronsList[i].Sigma * Layers[numberOfLayer + 1].NeuronsList[i].Inputs[numberOfThisNeuron].Weight;
                }
                Sigma = TransitFuncDerivativeOfNetwork.Invoke(SumInputs(this.Inputs), 1) * _partialSum;
                //MessageBox.Show(TransitFuncDerivativeOfNetwork.Invoke(Output, 1).ToString());
            }


        }

        public void InitializeNetwork(int numOfInputs, HiddenLayersInfo hiddenLayers, int epoch, double teachSpeed)
        {
            TeachSpeed = teachSpeed;
            HiddenLayers = hiddenLayers;
            InputValues = new double[numOfInputs];
            Layers = new Layer[HiddenLayers.NumberOfLayers];
            for (int i = 0; i < HiddenLayers.NumberOfLayers; i++)
            {
                Layers[i] = new Layer(hiddenLayers.NumberOfNeuronsOnEachLayer[i], i);
            }


            EpochNum = epoch;

        }

        public void SetTrainingSet(TrainingSet trainingSet)
        {
            this.TrainSet = trainingSet;
        }

        public void TeachNetwork(System.ComponentModel.BackgroundWorker worker)
        {
            RandomizeWeights();
            int _howManyActions = EpochNum * TrainSet.TeachSetLength;
            int percentage = 0;
            for (int i = 0; i < EpochNum; i++)
            {
                for (int j = 0; j < TrainSet.TeachSetLength; j++)
                {
                    SetTeachingInputs(j);
                    SetTeachingOutputs(j);

                    //ShowDataOfNN();
                    #region Прямой проход нейросети
                    StraightThrough();
                    #endregion

                    #region Обратный проход
                    BackPropagation();
                    #endregion
                    percentage = Convert.ToInt32((i * TrainSet.TeachSetLength + j) / _howManyActions);
                    worker.ReportProgress(percentage);
                }
            }
        }

        private void ShowDataOfNN()
        {
            string WeigntsMessage = "";
            string OutputsMessage = "";
            string Sigmas = "";
            foreach (Layer layer in Layers)
            {
                for (int k = 0; k < layer.NeuronsList.Length; k++)
                {
                    for (int q = 0; q < layer.NeuronsList[k].Inputs.Length; q++)
                    {
                        WeigntsMessage += layer.NeuronsList[k].Inputs[q].Weight + " ";

                    }
                    OutputsMessage += layer.NeuronsList[k].Output + " ";
                    Sigmas += layer.NeuronsList[k].Sigma + " ";
                }
            }
            MessageBox.Show($"веса:\n{WeigntsMessage}\nВыхода:\n{OutputsMessage}\nСигмы:\n{Sigmas}");
        }

        //Обратный проход нейросети
        private static void BackPropagation()
        {
            for (int i = Layers.Length - 1; i > -1; i--)
            {
                Layers[i].RecalculateWeights(i);
            }
        }

        //Прямой проход нейросети
        private void StraightThrough()
        {
            for (int i = 0; i < Layers.Length; i++)
            {
                SetInputsOfLayer(i);
                CalculateLayerOutputs(i);
            }
            SetOutputs();
            //ShowDataOfNN();
        }

        public double CalculateNet(double input)
        {
            if (InputValues.Length != 1) throw new Exception("Количество входов превышает 1");
            if (OutputValues.Length != 1) throw new Exception("Количество выходов превышает 1");
            InputValues[0] = input;
            this.StraightThrough();
            return OutputValues[0];
        }

        //Устанавливает значение входа у слоя с номером layerNumber. Для первого - значение обучающей выборки, для последующих - значения выходов нейронов предыдущего слоя
        private void SetInputsOfLayer(int layerNumber)
        {
            if (layerNumber == 0)
            {
                if (Layers[0].NeuronsList[0].Inputs.Length != InputValues.Length) { throw new Exception("Входной массив и число входов нейронов не совпадают"); }
                foreach (Neuron neuron in Layers[layerNumber].NeuronsList)
                {
                    for (int i = 0; i < neuron.Inputs.Length; i++)
                    {
                        neuron.Inputs[i].Value = InputValues[i];
                    }
                }
                return;
            }
            else
            {
                if (Layers[layerNumber].NeuronsList[0].Inputs.Length != Layers[layerNumber - 1].NeuronsList.Length) { throw new Exception($"Количество нейронов слоя {layerNumber - 1}({Layers[layerNumber - 1].NeuronsList.Length}) не совпадает с количеством входов нейронов слоя {layerNumber}({Layers[layerNumber].NeuronsList[0].Inputs.Length})"); }
                foreach (Neuron currentLayerNeuron in Layers[layerNumber].NeuronsList)
                {
                    for (int i = 0; i < currentLayerNeuron.Inputs.Length; i++)
                    {
                        foreach (Neuron previousLayerNeuron in Layers[layerNumber - 1].NeuronsList)
                        {

                            currentLayerNeuron.Inputs[i].Value = previousLayerNeuron.Output;
                        }

                    }
                }
            }
        }



        //Просчитывает выход нейронов на слое layerNumber
        private void CalculateLayerOutputs(int layerNumber)
        {
            foreach (Neuron neuron in Layers[layerNumber].NeuronsList)
            {
                neuron.CalculateOutput(1);
            }
        }

        //Устанавливает выходы равными значениям выходов последнего слоя
        private void SetOutputs()
        {
            OutputValues = new double[Layers[Layers.Length - 1].NeuronsList.Length];
            for (int i = 0; i < Layers[Layers.Length - 1].NeuronsList.Length; i++)
            {
                OutputValues[i] = Layers[Layers.Length - 1].NeuronsList[i].Output * TrainSet.Multiplier;
            }
        }

        private void SetTeachingInputs(int currentIteration)
        {
            InputValues = new double[TrainSet.InputsCount];
            for (int i = 0; i < TrainSet.InputsCount; i++)
            {
                InputValues[i] = TrainSet.X[i][currentIteration];
            }
        }

        private void SetTeachingOutputs(int currentIteration)
        {
            TeachingOutputValues = new double[TrainSet.OutputsCount];
            for (int i = 0; i < TrainSet.OutputsCount; i++)
            {
                TeachingOutputValues[i] = TrainSet.Y[i][currentIteration];
            }
        }

        //Инициализирует случайные веса в диапазоне шириной 2*limit
        void RandomizeWeights(double limit = 1)
        {
            for (int j = 0; j < Layers.Length; j++)
            {
                if (j == 0)
                {
                    foreach (Neuron neuron in Layers[j].NeuronsList)
                    {
                        for (int i = 0; i < neuron.Inputs.Length; i++)
                        {
                            neuron.Inputs[i].Weight = 1;
                        }
                    }
                    continue;
                }
                foreach (Neuron neuron in Layers[j].NeuronsList)
                {
                    for (int i = 0; i < neuron.Inputs.Length; i++)
                    {
                        neuron.Inputs[i].Weight = rnd.NextDouble() * limit;
                    }
                }
            }
        }

        Random rnd = new Random();

        class Layer
        {
            public Neuron[] NeuronsList { get; set; }

            public Layer(int numOfNeuronOnLayer, int numOfLayer)
            {
                NeuronsList = new Neuron[numOfNeuronOnLayer];
                for (int i = 0; i < numOfNeuronOnLayer; i++)
                {
                    NeuronsList[i] = new Neuron(numOfLayer, 1);

                }
            }

            public void RecalculateWeights(int layerNumber)
            {
                if (layerNumber == Layers.Length - 1)
                {
                    for (int i = 0; i < NeuronsList.Length; i++)
                    {
                        NeuronsList[i].CorrectWeights(layerNumber, i, TeachingOutputValues[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < NeuronsList.Length; i++)
                    {
                        NeuronsList[i].CorrectWeights(layerNumber, i);
                    }
                }
            }
        }


        static double SumInputs(Neuron.NeuronInput[] inputs)
        {
            double _result = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                _result += inputs[i].Input;
            }
            return _result;
        }

        public struct HiddenLayersInfo
        {
            HiddenLayersInfo(int[] numOfNeurons, int numOfLayers)
            {
                if (numOfNeurons.Length == numOfLayers)
                {
                    _numOfLayers = numOfLayers;
                    _numOfNeurons = numOfNeurons;
                }
                else throw new Exception("Несоответствие количества слоев и размерности входного массива");
            }

            int[] _numOfNeurons;
            int _numOfLayers;
            public int NumberOfLayers
            {
                get
                {
                    return _numOfLayers;
                }
                set
                {
                    if (value >= 0) _numOfLayers = value;
                    else
                    {
                        _numOfLayers = 0;
                    }
                }
            }
            public int[] NumberOfNeuronsOnEachLayer
            {
                get
                {
                    return _numOfNeurons;
                }
                set
                {
                    if (NumberOfLayers == 0) return;
                    if (value.Length == NumberOfLayers) _numOfNeurons = value;
                    else
                    {
                        if (value.Length > NumberOfLayers) Array.Copy(value, _numOfNeurons, NumberOfLayers);
                        else { _numOfNeurons = value; Array.Resize(ref _numOfNeurons, NumberOfLayers); }
                    }
                }
            }
        }

        public void ShowAllWeights()
        {
            string weights = "";
            int layerCounter = 0;
            int neurCounter = 0;
            foreach (Layer layer in Layers)
            {
                layerCounter++;
                weights += layerCounter + " layer ";
                foreach (Neuron neuron in layer.NeuronsList)
                {
                    neurCounter++;
                    weights += neurCounter +  " neur ";
                    foreach (Neuron.NeuronInput inp in neuron.Inputs)
                    {
                        weights += inp.Weight + " ";
                    }
                    weights += "\n";
                }
                weights += "\n";
            }
            MessageBox.Show(weights);
        }
    }
}
