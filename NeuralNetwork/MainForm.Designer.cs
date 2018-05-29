namespace NeuralNetwork
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnInitializeNetwork = new System.Windows.Forms.Button();
            this.cboxTransitFuncChoose = new System.Windows.Forms.ComboBox();
            this.numUpDownNumberOfInputs = new System.Windows.Forms.NumericUpDown();
            this.numUpDownNumberOfOutputs = new System.Windows.Forms.NumericUpDown();
            this.numUpDownEpochNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSchema = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTeachingSpeed = new System.Windows.Forms.TextBox();
            this.numHiddenLayersNum = new System.Windows.Forms.NumericUpDown();
            this.numRowsTeachingSet = new System.Windows.Forms.NumericUpDown();
            this.dataGridNeuronNumbers = new System.Windows.Forms.DataGridView();
            this.Layers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neurons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridOutputTrainSet = new System.Windows.Forms.DataGridView();
            this.Y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridInputTrainSet = new System.Windows.Forms.DataGridView();
            this.X1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWriteTrainSet = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFormFuncGraph = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnTeachNet = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumberOfInputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumberOfOutputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEpochNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenLayersNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowsTeachingSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNeuronNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOutputTrainSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInputTrainSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInitializeNetwork
            // 
            this.btnInitializeNetwork.Location = new System.Drawing.Point(170, 12);
            this.btnInitializeNetwork.Name = "btnInitializeNetwork";
            this.btnInitializeNetwork.Size = new System.Drawing.Size(109, 55);
            this.btnInitializeNetwork.TabIndex = 5;
            this.btnInitializeNetwork.Text = "Загрузить параметры сети";
            this.btnInitializeNetwork.UseVisualStyleBackColor = true;
            this.btnInitializeNetwork.Click += new System.EventHandler(this.btnInitializeNetwork_Click);
            // 
            // cboxTransitFuncChoose
            // 
            this.cboxTransitFuncChoose.FormattingEnabled = true;
            this.cboxTransitFuncChoose.Items.AddRange(new object[] {
            "Линейная",
            "Гиперболический тангенс",
            "Логистическая"});
            this.cboxTransitFuncChoose.Location = new System.Drawing.Point(22, 25);
            this.cboxTransitFuncChoose.Name = "cboxTransitFuncChoose";
            this.cboxTransitFuncChoose.Size = new System.Drawing.Size(121, 21);
            this.cboxTransitFuncChoose.TabIndex = 6;
            this.cboxTransitFuncChoose.Text = "Линейная";
            this.cboxTransitFuncChoose.SelectedIndexChanged += new System.EventHandler(this.cboxTransitFuncChoose_SelectedIndexChanged);
            // 
            // numUpDownNumberOfInputs
            // 
            this.numUpDownNumberOfInputs.Location = new System.Drawing.Point(22, 59);
            this.numUpDownNumberOfInputs.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownNumberOfInputs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownNumberOfInputs.Name = "numUpDownNumberOfInputs";
            this.numUpDownNumberOfInputs.Size = new System.Drawing.Size(120, 20);
            this.numUpDownNumberOfInputs.TabIndex = 9;
            this.numUpDownNumberOfInputs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownNumberOfInputs.ValueChanged += new System.EventHandler(this.numUpDownNumberOfInputs_ValueChanged);
            // 
            // numUpDownNumberOfOutputs
            // 
            this.numUpDownNumberOfOutputs.Location = new System.Drawing.Point(22, 98);
            this.numUpDownNumberOfOutputs.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownNumberOfOutputs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownNumberOfOutputs.Name = "numUpDownNumberOfOutputs";
            this.numUpDownNumberOfOutputs.Size = new System.Drawing.Size(120, 20);
            this.numUpDownNumberOfOutputs.TabIndex = 8;
            this.numUpDownNumberOfOutputs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownNumberOfOutputs.ValueChanged += new System.EventHandler(this.numUpDownNumberOfOutputs_ValueChanged);
            // 
            // numUpDownEpochNum
            // 
            this.numUpDownEpochNum.Location = new System.Drawing.Point(22, 137);
            this.numUpDownEpochNum.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numUpDownEpochNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownEpochNum.Name = "numUpDownEpochNum";
            this.numUpDownEpochNum.Size = new System.Drawing.Size(120, 20);
            this.numUpDownEpochNum.TabIndex = 7;
            this.numUpDownEpochNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Число входов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Выбор функции активации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Число выходов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Число скрытых слоев";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Число эпох обучения";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(163, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 48);
            this.label9.TabIndex = 12;
            this.label9.Text = "Число кортежей значений обучающей выборки";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Скорость обучения";
            // 
            // labelSchema
            // 
            this.labelSchema.AutoSize = true;
            this.labelSchema.Location = new System.Drawing.Point(167, 137);
            this.labelSchema.Name = "labelSchema";
            this.labelSchema.Size = new System.Drawing.Size(123, 13);
            this.labelSchema.TabIndex = 10;
            this.labelSchema.Text = "Инициализируйте сеть";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(567, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Входы";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(791, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Выходы";
            // 
            // txtTeachingSpeed
            // 
            this.txtTeachingSpeed.Location = new System.Drawing.Point(22, 181);
            this.txtTeachingSpeed.Name = "txtTeachingSpeed";
            this.txtTeachingSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtTeachingSpeed.TabIndex = 15;
            this.txtTeachingSpeed.Text = "0,2";
            // 
            // numHiddenLayersNum
            // 
            this.numHiddenLayersNum.Location = new System.Drawing.Point(170, 97);
            this.numHiddenLayersNum.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numHiddenLayersNum.Name = "numHiddenLayersNum";
            this.numHiddenLayersNum.Size = new System.Drawing.Size(120, 20);
            this.numHiddenLayersNum.TabIndex = 16;
            this.numHiddenLayersNum.ValueChanged += new System.EventHandler(this.numHiddenLayersNum_ValueChanged);
            // 
            // numRowsTeachingSet
            // 
            this.numRowsTeachingSet.Location = new System.Drawing.Point(159, 216);
            this.numRowsTeachingSet.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRowsTeachingSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowsTeachingSet.Name = "numRowsTeachingSet";
            this.numRowsTeachingSet.Size = new System.Drawing.Size(120, 20);
            this.numRowsTeachingSet.TabIndex = 16;
            this.numRowsTeachingSet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowsTeachingSet.ValueChanged += new System.EventHandler(this.numRowsTeachingSet_ValueChanged);
            // 
            // dataGridNeuronNumbers
            // 
            this.dataGridNeuronNumbers.AllowUserToAddRows = false;
            this.dataGridNeuronNumbers.AllowUserToDeleteRows = false;
            this.dataGridNeuronNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNeuronNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Layers,
            this.Neurons});
            this.dataGridNeuronNumbers.Location = new System.Drawing.Point(305, 12);
            this.dataGridNeuronNumbers.Name = "dataGridNeuronNumbers";
            this.dataGridNeuronNumbers.Size = new System.Drawing.Size(245, 192);
            this.dataGridNeuronNumbers.TabIndex = 17;
            // 
            // Layers
            // 
            this.Layers.HeaderText = "Слои";
            this.Layers.Name = "Layers";
            this.Layers.ReadOnly = true;
            this.Layers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Neurons
            // 
            this.Neurons.HeaderText = "Количество нейронов";
            this.Neurons.Name = "Neurons";
            this.Neurons.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridOutputTrainSet
            // 
            this.dataGridOutputTrainSet.AllowUserToAddRows = false;
            this.dataGridOutputTrainSet.AllowUserToDeleteRows = false;
            this.dataGridOutputTrainSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOutputTrainSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Y1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridOutputTrainSet.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridOutputTrainSet.Location = new System.Drawing.Point(794, 12);
            this.dataGridOutputTrainSet.Name = "dataGridOutputTrainSet";
            this.dataGridOutputTrainSet.RowHeadersVisible = false;
            this.dataGridOutputTrainSet.Size = new System.Drawing.Size(196, 192);
            this.dataGridOutputTrainSet.TabIndex = 0;
            // 
            // Y1
            // 
            this.Y1.HeaderText = "Выход1";
            this.Y1.Name = "Y1";
            // 
            // dataGridInputTrainSet
            // 
            this.dataGridInputTrainSet.AllowUserToAddRows = false;
            this.dataGridInputTrainSet.AllowUserToDeleteRows = false;
            this.dataGridInputTrainSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInputTrainSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInputTrainSet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridInputTrainSet.Location = new System.Drawing.Point(570, 12);
            this.dataGridInputTrainSet.Name = "dataGridInputTrainSet";
            this.dataGridInputTrainSet.RowHeadersVisible = false;
            this.dataGridInputTrainSet.Size = new System.Drawing.Size(196, 192);
            this.dataGridInputTrainSet.TabIndex = 0;
            // 
            // X1
            // 
            this.X1.HeaderText = "Вход1";
            this.X1.Name = "X1";
            // 
            // btnWriteTrainSet
            // 
            this.btnWriteTrainSet.Location = new System.Drawing.Point(570, 251);
            this.btnWriteTrainSet.Name = "btnWriteTrainSet";
            this.btnWriteTrainSet.Size = new System.Drawing.Size(115, 60);
            this.btnWriteTrainSet.TabIndex = 18;
            this.btnWriteTrainSet.Text = "Записать обучающую выборку";
            this.btnWriteTrainSet.UseVisualStyleBackColor = true;
            this.btnWriteTrainSet.Click += new System.EventHandler(this.btnWriteTrainSet_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.button1);
            this.splitContainer.Panel1.Controls.Add(this.btnFormFuncGraph);
            this.splitContainer.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer.Panel1.Controls.Add(this.btnTeachNet);
            this.splitContainer.Panel1.Controls.Add(this.btnWriteTrainSet);
            this.splitContainer.Panel1.Controls.Add(this.dataGridInputTrainSet);
            this.splitContainer.Panel1.Controls.Add(this.dataGridOutputTrainSet);
            this.splitContainer.Panel1.Controls.Add(this.dataGridNeuronNumbers);
            this.splitContainer.Panel1.Controls.Add(this.numRowsTeachingSet);
            this.splitContainer.Panel1.Controls.Add(this.numHiddenLayersNum);
            this.splitContainer.Panel1.Controls.Add(this.txtTeachingSpeed);
            this.splitContainer.Panel1.Controls.Add(this.label8);
            this.splitContainer.Panel1.Controls.Add(this.label7);
            this.splitContainer.Panel1.Controls.Add(this.labelSchema);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.label9);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.numUpDownEpochNum);
            this.splitContainer.Panel1.Controls.Add(this.numUpDownNumberOfOutputs);
            this.splitContainer.Panel1.Controls.Add(this.numUpDownNumberOfInputs);
            this.splitContainer.Panel1.Controls.Add(this.cboxTransitFuncChoose);
            this.splitContainer.Panel1.Controls.Add(this.btnInitializeNetwork);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.chart1);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(999, 505);
            this.splitContainer.SplitterDistance = 322;
            this.splitContainer.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 60);
            this.button1.TabIndex = 22;
            this.button1.Text = "Построить график функции активации";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFormFuncGraph
            // 
            this.btnFormFuncGraph.Enabled = false;
            this.btnFormFuncGraph.Location = new System.Drawing.Point(730, 251);
            this.btnFormFuncGraph.Name = "btnFormFuncGraph";
            this.btnFormFuncGraph.Size = new System.Drawing.Size(150, 60);
            this.btnFormFuncGraph.TabIndex = 21;
            this.btnFormFuncGraph.Text = "Построить график";
            this.btnFormFuncGraph.UseVisualStyleBackColor = true;
            this.btnFormFuncGraph.Click += new System.EventHandler(this.btnFormFuncGraph_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 273);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(278, 38);
            this.progressBar1.TabIndex = 20;
            // 
            // btnTeachNet
            // 
            this.btnTeachNet.Enabled = false;
            this.btnTeachNet.Location = new System.Drawing.Point(325, 251);
            this.btnTeachNet.Name = "btnTeachNet";
            this.btnTeachNet.Size = new System.Drawing.Size(120, 60);
            this.btnTeachNet.TabIndex = 19;
            this.btnTeachNet.Text = "Обучить сеть";
            this.btnTeachNet.UseVisualStyleBackColor = true;
            this.btnTeachNet.Click += new System.EventHandler(this.btnTeachNet_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(22, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "inputData";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "FunctionGraph";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(965, 164);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 505);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumberOfInputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumberOfOutputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownEpochNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenLayersNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowsTeachingSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNeuronNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOutputTrainSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInputTrainSet)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitializeNetwork;
        private System.Windows.Forms.ComboBox cboxTransitFuncChoose;
        private System.Windows.Forms.NumericUpDown numUpDownNumberOfInputs;
        private System.Windows.Forms.NumericUpDown numUpDownNumberOfOutputs;
        private System.Windows.Forms.NumericUpDown numUpDownEpochNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSchema;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTeachingSpeed;
        private System.Windows.Forms.NumericUpDown numHiddenLayersNum;
        private System.Windows.Forms.NumericUpDown numRowsTeachingSet;
        private System.Windows.Forms.DataGridView dataGridNeuronNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Layers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neurons;
        private System.Windows.Forms.DataGridView dataGridOutputTrainSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y1;
        private System.Windows.Forms.DataGridView dataGridInputTrainSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn X1;
        private System.Windows.Forms.Button btnWriteTrainSet;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnTeachNet;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnFormFuncGraph;
        private System.Windows.Forms.Button button1;
    }
}

