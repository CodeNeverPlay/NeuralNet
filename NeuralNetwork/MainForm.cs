using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NeuralNetwork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridInputTrainSet.Rows.Add();
            dataGridOutputTrainSet.Rows.Add();
        }

        private int indexOfTransFunc;
        private Network net;

        private void cboxTransitFuncChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexOfTransFunc = cboxTransitFuncChoose.SelectedIndex;
        }

        private void btnInitializeNetwork_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            int tranFun = indexOfTransFunc;
            int NumOfInputs = (int)numUpDownNumberOfInputs.Value;
            int Epoch = (int)numUpDownEpochNum.Value;
            double teachSpeed;
            if (!double.TryParse(txtTeachingSpeed.Text, out teachSpeed)) { MessageBox.Show("Не правильный формат введенной скорости обучения"); (sender as Button).Enabled = true; return; }
            if (teachSpeed > 1) teachSpeed = 1;
            if (teachSpeed < 0.1) teachSpeed = 0.1;
            txtTeachingSpeed.Text = teachSpeed.ToString();
            Network.HiddenLayersInfo hiddenLayersInfo = ReadHiddenLayersInfo();
            net = new Network(NumOfInputs, hiddenLayersInfo, Epoch, tranFun, teachSpeed);
            string schema = NumOfInputs.ToString();
            for (int i = 0; i < hiddenLayersInfo.NumberOfNeuronsOnEachLayer.Length; i++) schema += $"-{hiddenLayersInfo.NumberOfNeuronsOnEachLayer[i]}";
            MessageBox.Show($"Нейросеть инициализирована по схеме\n{schema}");
            labelSchema.Text = $"Схема: {schema}";
            (sender as Button).Enabled = true;

        }


        private void numHiddenLayersNum_ValueChanged(object sender, EventArgs e)
        {
            int _rowsAdd = 0;
            if (dataGridNeuronNumbers.Rows.Count != (sender as NumericUpDown).Value)
            {
                _rowsAdd = (int)(sender as NumericUpDown).Value - dataGridNeuronNumbers.Rows.Count;
                if (_rowsAdd > 0)
                {
                    for (int i = 0; i < _rowsAdd; i++)
                    {
                        string name = "Слой " + Convert.ToString(dataGridNeuronNumbers.Rows.Count + 1);
                        dataGridNeuronNumbers.Rows.Add(name, 1);
                    }
                }
                else
                    for (int i = 1; i <= -_rowsAdd; i++)
                    {
                        dataGridNeuronNumbers.Rows.RemoveAt(dataGridNeuronNumbers.Rows.Count - 1);
                    }
            }
            else return;

        }

        //Передача инфы по слоям
        private Network.HiddenLayersInfo ReadHiddenLayersInfo()
        {
            Network.HiddenLayersInfo result = new Network.HiddenLayersInfo();
            result.NumberOfLayers = (int)numHiddenLayersNum.Value + 1;
            result.NumberOfNeuronsOnEachLayer = new int[result.NumberOfLayers];
            for (int i = 0; i < result.NumberOfLayers - 1; i++)
            {
                int temp;
                if (int.TryParse(dataGridNeuronNumbers.Rows[i].Cells["Neurons"].Value.ToString(), out temp))
                {
                    if (temp < 1 || temp > 20) { throw new Exception($"Обнаружено некорректное значение на слое {i + 1}"); }
                    result.NumberOfNeuronsOnEachLayer[i] = temp;
                }
                else throw new Exception($"Поле ввода заполнено некорректно. Невозможно прочитать количество нейронов на слое {i + 1}");
            }
            result.NumberOfNeuronsOnEachLayer[result.NumberOfLayers - 1] = (int)numUpDownNumberOfOutputs.Value;
            return result;
        }

        private Network.TrainingSet ReadTrainingSet()
        {
            List<double[]> listX;
            List<double[]> listY;

            if (!GetDataFromGridTrainSet(dataGridInputTrainSet, out listX)) MessageBox.Show("Как минимум одна ячейка не была прочитана корректно в массиве X");
            if (!GetDataFromGridTrainSet(dataGridOutputTrainSet, out listY)) MessageBox.Show("Как минимум одна ячейка не была прочитана корректно в массиве Y");

            return new Network.TrainingSet(listX, listY);
        }

        private bool GetDataFromGridTrainSet(DataGridView dataGrid, out List<double[]> list)
        {
            list = new List<double[]>(dataGrid.ColumnCount);
            bool IsAllCellsWroteCorrectly = true;
            for (int i = 0; i < dataGrid.ColumnCount; i++)
            {
                double[] singleRow = new double[dataGrid.RowCount];

                for (int j = 0; j < dataGrid.RowCount; j++)
                {
                    double _temp = 0;
                    if (double.TryParse(dataGrid[i, j].Value.ToString(), out _temp)) singleRow[j] = _temp;
                    else { singleRow[j] = 0; IsAllCellsWroteCorrectly = false; }
                }
                list.Add(singleRow);
            }
            return IsAllCellsWroteCorrectly;
        }

        #region Работа с строками и столцами грид вью

        private void numUpDownNumberOfInputs_ValueChanged(object sender, EventArgs e)
        {
            int _columnsAdd = 0;
            if (dataGridInputTrainSet.Columns.Count != (sender as NumericUpDown).Value)
            {
                _columnsAdd = (int)(sender as NumericUpDown).Value - dataGridInputTrainSet.Columns.Count;
                if (_columnsAdd > 0)
                {
                    for (int i = 0; i < _columnsAdd; i++)
                    {
                        string name = "Вход" + Convert.ToString(dataGridInputTrainSet.Columns.Count + 1);
                        string input = "input" + Convert.ToString(dataGridInputTrainSet.Columns.Count + 1);
                        dataGridInputTrainSet.Columns.Add(input, name);
                    }
                }
                else
                    for (int i = 1; i <= -_columnsAdd; i++)
                    {
                        dataGridInputTrainSet.Columns.RemoveAt(dataGridInputTrainSet.Columns.Count - 1);
                    }
            }
        }

        private void numUpDownNumberOfOutputs_ValueChanged(object sender, EventArgs e)
        {
            int _columnsAdd = 0;
            if (dataGridOutputTrainSet.Columns.Count != (sender as NumericUpDown).Value)
            {
                _columnsAdd = (int)(sender as NumericUpDown).Value - dataGridOutputTrainSet.Columns.Count;
                if (_columnsAdd > 0)
                {
                    for (int i = 0; i < _columnsAdd; i++)
                    {
                        string name = "Выход" + Convert.ToString(dataGridOutputTrainSet.Columns.Count + 1);
                        string input = "Output" + Convert.ToString(dataGridOutputTrainSet.Columns.Count + 1);
                        dataGridOutputTrainSet.Columns.Add(input, name);
                    }
                }
                else
                    for (int i = 1; i <= -_columnsAdd; i++)
                    {
                        dataGridOutputTrainSet.Columns.RemoveAt(dataGridOutputTrainSet.Columns.Count - 1);
                    }
            }
        }

        private void numRowsTeachingSet_ValueChanged(object sender, EventArgs e)
        {
            int _rowsAdd = 0;
            if (dataGridInputTrainSet.Rows.Count != (sender as NumericUpDown).Value)
            {
                _rowsAdd = (int)(sender as NumericUpDown).Value - dataGridInputTrainSet.Rows.Count;
                if (_rowsAdd > 0)
                {
                    for (int i = 0; i < _rowsAdd; i++)
                    {
                        dataGridInputTrainSet.Rows.Add();
                        dataGridOutputTrainSet.Rows.Add();
                    }
                }
                else
                    for (int i = 1; i <= -_rowsAdd; i++)
                    {
                        dataGridInputTrainSet.Rows.RemoveAt(dataGridInputTrainSet.Rows.Count - 1);
                        dataGridOutputTrainSet.Rows.RemoveAt(dataGridInputTrainSet.Rows.Count - 1);
                    }
            }
            else return;
        }

        #endregion

        private void btnWriteTrainSet_Click(object sender, EventArgs e)
        {
            if (net == null) { MessageBox.Show("Сначала инициализируй сеть"); return; }
            (sender as Button).Enabled = false;
            Network.TrainingSet ts = ReadTrainingSet();
            net.SetTrainingSet(ts);
            ReatToChart(ts);
            (sender as Button).Enabled = true;
            btnTeachNet.Enabled = true;
        }

        private void ReatToChart(Network.TrainingSet ts)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            for (int i = 0; i < ts.TeachSetLength; i++)
            {
                chart1.Series[0].Points.AddXY(ts.X[0][i], ts.Y[0][i]);
            }
        }

        private void btnTeachNet_Click(object sender, EventArgs e)
        {
            if (net == null) { MessageBox.Show("Для начала инициализируй сеть"); return; }
            if (net.TrainSet == null) { MessageBox.Show("Обучающая выборка не задана"); return; }
            (sender as Button).Enabled = false;
            btnInitializeNetwork.Enabled = false;
            btnWriteTrainSet.Enabled = false;
            btnFormFuncGraph.Enabled = false;

            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null) MessageBox.Show("Сеть обучена без ошибок");
            else MessageBox.Show($"{e.Error.Message}\n{e.Error.StackTrace}");
            btnTeachNet.Enabled = true;
            btnInitializeNetwork.Enabled = true;
            btnWriteTrainSet.Enabled = true;
            btnFormFuncGraph.Enabled = true;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            net.TeachNetwork(sender as BackgroundWorker);
        }



        BackgroundWorker worker;

        private void btnFormFuncGraph_Click(object sender, EventArgs e)
        {
            try
            {
                bool _showMessage = true;
                List<double[]> minMaxGridValues = new List<double[]>(net.TrainSet.X.Count);
                foreach (double[] array in net.TrainSet.X)
                {
                    double max = array.Max();
                    double min = array.Min();
                    minMaxGridValues.Add(new double[] { min, max });
                }

                chart1.Series["FunctionGraph"].Points.Clear();
                for (double i = minMaxGridValues[0][0]; i < minMaxGridValues[0][1]; i += (minMaxGridValues[0][1] - minMaxGridValues[0][0]) / 100)
                {
                    chart1.Series["FunctionGraph"].Points.AddXY(i, net.CalculateNet(i));
                    if (_showMessage)
                    {
                        var dialogResult = MessageBox.Show($"{i.ToString()};{net.CalculateNet(i)}", "Продолжить просматривать сообщения?", MessageBoxButtons.YesNoCancel);
                        if (dialogResult == DialogResult.No) _showMessage = false;
                        if (dialogResult == DialogResult.Cancel) return;
                    }
                }
                net.ShowAllWeights();
            }
            catch (Exception ex)
            { MessageBox.Show($"{ex.Message}\n{ex.StackTrace}"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (double i = -9; i <= 10; i += 0.1)
            {
                chart1.Series[0].Points.AddXY(i, Network.TransitFunctions.HiperbolicTan(i));
                chart1.Series[1].Points.AddXY(i, Network.TransitFunctions.HiperbolicTanDerivative(i));
            }
        }
    }
}
