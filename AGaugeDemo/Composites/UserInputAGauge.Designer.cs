namespace AGaugeDemo.Composites
{
    partial class UserInputAGauge
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.aGauge = new AGauge.AGaugeControl();
            this.userInputAGaugeBusinessObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manualInputsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.valueInput = new AGaugeDemo.Composites.NumericInput();
            this.minInput = new AGaugeDemo.Composites.NumericInput();
            this.maxInput = new AGaugeDemo.Composites.NumericInput();
            this.majStepVal = new AGaugeDemo.Composites.NumericInput();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInputAGaugeBusinessObjectBindingSource)).BeginInit();
            this.manualInputsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Controls.Add(this.aGauge);
            this.mainPanel.Controls.Add(this.manualInputsPanel);
            this.mainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(218, 358);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.WrapContents = false;
            // 
            // aGauge
            // 
            this.aGauge.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.userInputAGaugeBusinessObjectBindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aGauge.DataBindings.Add(new System.Windows.Forms.Binding("MaxValue", this.userInputAGaugeBusinessObjectBindingSource, "MaxValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aGauge.DataBindings.Add(new System.Windows.Forms.Binding("MinValue", this.userInputAGaugeBusinessObjectBindingSource, "MinValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aGauge.DataBindings.Add(new System.Windows.Forms.Binding("ScaleLinesMajorStepValue", this.userInputAGaugeBusinessObjectBindingSource, "MajorStepValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aGauge.Location = new System.Drawing.Point(3, 3);
            this.aGauge.Name = "aGauge";
            this.aGauge.Size = new System.Drawing.Size(211, 206);
            this.aGauge.TabIndex = 0;
            this.aGauge.Text = null;
            this.aGauge.Value = 0F;
            // 
            // userInputAGaugeBusinessObjectBindingSource
            // 
            this.userInputAGaugeBusinessObjectBindingSource.DataSource = typeof(AGaugeDemo.Composites.UserInputAGauge.UserInputAGaugeBusinessObject);
            // 
            // manualInputsPanel
            // 
            this.manualInputsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manualInputsPanel.AutoSize = true;
            this.manualInputsPanel.Controls.Add(this.valueInput);
            this.manualInputsPanel.Controls.Add(this.minInput);
            this.manualInputsPanel.Controls.Add(this.maxInput);
            this.manualInputsPanel.Controls.Add(this.majStepVal);
            this.manualInputsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.manualInputsPanel.Location = new System.Drawing.Point(3, 215);
            this.manualInputsPanel.Name = "manualInputsPanel";
            this.manualInputsPanel.Size = new System.Drawing.Size(212, 140);
            this.manualInputsPanel.TabIndex = 2;
            // 
            // valueInput
            // 
            this.valueInput.AutoSize = true;
            this.valueInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.valueInput.DataBindings.Add(new System.Windows.Forms.Binding("MaxValue", this.userInputAGaugeBusinessObjectBindingSource, "MaxValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valueInput.DataBindings.Add(new System.Windows.Forms.Binding("MinValue", this.userInputAGaugeBusinessObjectBindingSource, "MinValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valueInput.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.userInputAGaugeBusinessObjectBindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valueInput.Location = new System.Drawing.Point(3, 3);
            this.valueInput.MaxValue = 0;
            this.valueInput.MinValue = 0;
            this.valueInput.Name = "valueInput";
            this.valueInput.Size = new System.Drawing.Size(194, 29);
            this.valueInput.TabIndex = 2;
            this.valueInput.Value = 0;
            // 
            // minInput
            // 
            this.minInput.AutoSize = true;
            this.minInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.minInput.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.userInputAGaugeBusinessObjectBindingSource, "MinValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.minInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minInput.Location = new System.Drawing.Point(3, 38);
            this.minInput.MaxValue = 200;
            this.minInput.MinValue = -200;
            this.minInput.Name = "minInput";
            this.minInput.Size = new System.Drawing.Size(206, 29);
            this.minInput.TabIndex = 2;
            this.minInput.Value = 0;
            // 
            // maxInput
            // 
            this.maxInput.AutoSize = true;
            this.maxInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maxInput.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.userInputAGaugeBusinessObjectBindingSource, "MaxValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxInput.Location = new System.Drawing.Point(3, 73);
            this.maxInput.MaxValue = 600;
            this.maxInput.MinValue = -200;
            this.maxInput.Name = "maxInput";
            this.maxInput.Size = new System.Drawing.Size(206, 29);
            this.maxInput.TabIndex = 3;
            this.maxInput.Value = 0;
            // 
            // majStepVal
            // 
            this.majStepVal.AutoSize = true;
            this.majStepVal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.majStepVal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.userInputAGaugeBusinessObjectBindingSource, "MajorStepValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.majStepVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.majStepVal.Location = new System.Drawing.Point(3, 108);
            this.majStepVal.MaxValue = 50;
            this.majStepVal.MinValue = 0;
            this.majStepVal.Name = "majStepVal";
            this.majStepVal.Size = new System.Drawing.Size(206, 29);
            this.majStepVal.TabIndex = 3;
            this.majStepVal.Value = 1;
            // 
            // UserInputAGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.mainPanel);
            this.Name = "UserInputAGauge";
            this.Size = new System.Drawing.Size(221, 361);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInputAGaugeBusinessObjectBindingSource)).EndInit();
            this.manualInputsPanel.ResumeLayout(false);
            this.manualInputsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AGauge.AGaugeControl aGauge;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel manualInputsPanel;
        private NumericInput valueInput;
        private NumericInput minInput;
        private NumericInput maxInput;
        private NumericInput majStepVal;
        private System.Windows.Forms.BindingSource userInputAGaugeBusinessObjectBindingSource;
    }
}
