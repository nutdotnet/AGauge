namespace AGaugeDemo.Composites
{
    partial class NumericInput
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.numericInputBusinessObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInputBusinessObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.AutoSize = false;
            this.trackBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.numericInputBusinessObjectBindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", this.numericInputBusinessObjectBindingSource, "MaxValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar.DataBindings.Add(new System.Windows.Forms.Binding("Minimum", this.numericInputBusinessObjectBindingSource, "MinValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar.Location = new System.Drawing.Point(56, 3);
            this.trackBar.MinimumSize = new System.Drawing.Size(20, 0);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(74, 20);
            this.trackBar.TabIndex = 4;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // numericInputBusinessObjectBindingSource
            // 
            this.numericInputBusinessObjectBindingSource.DataSource = typeof(AGaugeDemo.Composites.NumericInput.NumericInputBusinessObject);
            // 
            // numericUpDown
            // 
            this.numericUpDown.AutoSize = true;
            this.numericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.numericInputBusinessObjectBindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Minimum", this.numericInputBusinessObjectBindingSource, "MinValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", this.numericInputBusinessObjectBindingSource, "MaxValue", true));
            this.numericUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.numericUpDown.Location = new System.Drawing.Point(9, 3);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.numericInputBusinessObjectBindingSource, "Name", true));
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(3, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 26);
            this.label.TabIndex = 2;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Controls.Add(this.label);
            this.mainPanel.Controls.Add(this.numericUpDown);
            this.mainPanel.Controls.Add(this.trackBar);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(133, 26);
            this.mainPanel.TabIndex = 5;
            // 
            // NumericInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.mainPanel);
            this.Name = "NumericInput";
            this.Size = new System.Drawing.Size(136, 29);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInputBusinessObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.BindingSource numericInputBusinessObjectBindingSource;
    }
}
