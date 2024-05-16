namespace AGaugeDemo
{
    partial class GaugeDemo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            AGauge.AGaugeLabel aGaugeLabel1 = new AGauge.AGaugeLabel();
            AGauge.AGaugeRange aGaugeRange1 = new AGauge.AGaugeRange();
            AGauge.AGaugeRange aGaugeRange2 = new AGauge.AGaugeRange();
            AGauge.AGaugeRange aGaugeRange3 = new AGauge.AGaugeRange();
            AGauge.AGaugeLabel aGaugeLabel2 = new AGauge.AGaugeLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Gauge1Container = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aGauge1 = new AGauge.AGauge();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.GaugeTestMajMarksContainer = new System.Windows.Forms.Panel();
            this.pnl_value = new System.Windows.Forms.Panel();
            this.tb_value = new System.Windows.Forms.TrackBar();
            this.majTicksGaugeBusinessObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nud_value = new System.Windows.Forms.NumericUpDown();
            this.lbl_value = new System.Windows.Forms.Label();
            this.gge_majTicks = new AGauge.AGauge();
            this.flowLayoutPanel1.SuspendLayout();
            this.Gauge1Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.GaugeTestMajMarksContainer.SuspendLayout();
            this.pnl_value.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.majTicksGaugeBusinessObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gge_majTicks)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.Gauge1Container);
            this.flowLayoutPanel1.Controls.Add(this.GaugeTestMajMarksContainer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(711, 527);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Gauge1Container
            // 
            this.Gauge1Container.Controls.Add(this.panel1);
            this.Gauge1Container.Controls.Add(this.aGauge1);
            this.Gauge1Container.Controls.Add(this.trackBar1);
            this.Gauge1Container.Controls.Add(this.button1);
            this.Gauge1Container.Location = new System.Drawing.Point(3, 3);
            this.Gauge1Container.Name = "Gauge1Container";
            this.Gauge1Container.Size = new System.Drawing.Size(300, 229);
            this.Gauge1Container.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(135, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 23);
            this.panel1.TabIndex = 2;
            // 
            // aGauge1
            // 
            this.aGauge1.BackColor = System.Drawing.SystemColors.Control;
            aGaugeLabel1.Color = System.Drawing.SystemColors.WindowText;
            aGaugeLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            aGaugeLabel1.Name = "GaugeLabel1";
            aGaugeLabel1.Position = new System.Drawing.Point(200, 260);
            aGaugeLabel1.Text = "0";
            this.aGauge1.GaugeLabels.Add(aGaugeLabel1);
            aGaugeRange1.Color = System.Drawing.Color.Red;
            aGaugeRange1.EndValue = 200F;
            aGaugeRange1.InnerRadius = 70;
            aGaugeRange1.InRange = false;
            aGaugeRange1.Name = "AlertRange";
            aGaugeRange1.OuterRadius = 80;
            aGaugeRange1.StartValue = 160F;
            aGaugeRange2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            aGaugeRange2.EndValue = 160F;
            aGaugeRange2.InnerRadius = 70;
            aGaugeRange2.InRange = false;
            aGaugeRange2.Name = "GaugeRange3";
            aGaugeRange2.OuterRadius = 75;
            aGaugeRange2.StartValue = 0F;
            aGaugeRange3.Color = System.Drawing.Color.Lime;
            aGaugeRange3.EndValue = 160F;
            aGaugeRange3.InnerRadius = 75;
            aGaugeRange3.InRange = false;
            aGaugeRange3.Name = "GaugeRange2";
            aGaugeRange3.OuterRadius = 80;
            aGaugeRange3.StartValue = 0F;
            this.aGauge1.GaugeRanges.Add(aGaugeRange1);
            this.aGauge1.GaugeRanges.Add(aGaugeRange2);
            this.aGauge1.GaugeRanges.Add(aGaugeRange3);
            this.aGauge1.Location = new System.Drawing.Point(51, 0);
            this.aGauge1.MaxValue = 200;
            this.aGauge1.MinValue = 0;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Yellow;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.Olive;
            this.aGauge1.ScaleLinesMajorStepValue = 20;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.Size = new System.Drawing.Size(220, 200);
            this.aGauge1.TabIndex = 0;
            this.aGauge1.Text = "aGauge1";
            this.aGauge1.Value = 0F;
            this.aGauge1.ValueInRangeChanged += new System.EventHandler<AGauge.ValueInRangeChangedEventArgs>(this.aGauge1_ValueInRangeChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 229);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(196, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GaugeTestMajMarksContainer
            // 
            this.GaugeTestMajMarksContainer.AutoSize = true;
            this.GaugeTestMajMarksContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GaugeTestMajMarksContainer.Controls.Add(this.pnl_value);
            this.GaugeTestMajMarksContainer.Controls.Add(this.gge_majTicks);
            this.GaugeTestMajMarksContainer.Location = new System.Drawing.Point(309, 3);
            this.GaugeTestMajMarksContainer.Name = "GaugeTestMajMarksContainer";
            this.GaugeTestMajMarksContainer.Size = new System.Drawing.Size(211, 221);
            this.GaugeTestMajMarksContainer.TabIndex = 4;
            // 
            // pnl_value
            // 
            this.pnl_value.Controls.Add(this.tb_value);
            this.pnl_value.Controls.Add(this.nud_value);
            this.pnl_value.Controls.Add(this.lbl_value);
            this.pnl_value.Location = new System.Drawing.Point(9, 190);
            this.pnl_value.Name = "pnl_value";
            this.pnl_value.Size = new System.Drawing.Size(199, 28);
            this.pnl_value.TabIndex = 3;
            // 
            // tb_value
            // 
            this.tb_value.AutoSize = false;
            this.tb_value.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.majTicksGaugeBusinessObjectBindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_value.Location = new System.Drawing.Point(99, 3);
            this.tb_value.Maximum = 20;
            this.tb_value.Minimum = 3;
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(97, 18);
            this.tb_value.TabIndex = 4;
            this.tb_value.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_value.Value = 3;
            // 
            // majTicksGaugeBusinessObjectBindingSource
            // 
            this.majTicksGaugeBusinessObjectBindingSource.DataSource = typeof(AGaugeDemo.GaugeDemo.MajTicksGaugeBusinessObject);
            // 
            // nud_value
            // 
            this.nud_value.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.majTicksGaugeBusinessObjectBindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_value.Location = new System.Drawing.Point(43, 3);
            this.nud_value.Name = "nud_value";
            this.nud_value.Size = new System.Drawing.Size(50, 20);
            this.nud_value.TabIndex = 3;
            // 
            // lbl_value
            // 
            this.lbl_value.AutoSize = true;
            this.lbl_value.Location = new System.Drawing.Point(6, 5);
            this.lbl_value.Name = "lbl_value";
            this.lbl_value.Size = new System.Drawing.Size(34, 13);
            this.lbl_value.TabIndex = 2;
            this.lbl_value.Text = "Value";
            // 
            // gge_majTicks
            // 
            this.gge_majTicks.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.majTicksGaugeBusinessObjectBindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            aGaugeLabel2.Color = System.Drawing.SystemColors.WindowText;
            aGaugeLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            aGaugeLabel2.Name = "valLabel";
            aGaugeLabel2.Position = new System.Drawing.Point(0, 40);
            aGaugeLabel2.Text = "";
            this.gge_majTicks.GaugeLabels.Add(aGaugeLabel2);
            this.gge_majTicks.Location = new System.Drawing.Point(3, 3);
            this.gge_majTicks.MaxValue = 20;
            this.gge_majTicks.MinValue = 3;
            this.gge_majTicks.Name = "gge_majTicks";
            this.gge_majTicks.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Yellow;
            this.gge_majTicks.NeedleColor2 = System.Drawing.Color.Olive;
            this.gge_majTicks.ScaleLinesMajorStepValue = 17;
            this.gge_majTicks.ScaleLinesMinorTicks = 3;
            this.gge_majTicks.ScaleNumbersFormat = null;
            this.gge_majTicks.Size = new System.Drawing.Size(205, 215);
            this.gge_majTicks.TabIndex = 0;
            this.gge_majTicks.Text = null;
            this.gge_majTicks.Value = 3F;
            // 
            // GaugeDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 527);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GaugeDemo";
            this.Text = "GaugeDemo";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.Gauge1Container.ResumeLayout(false);
            this.Gauge1Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.GaugeTestMajMarksContainer.ResumeLayout(false);
            this.pnl_value.ResumeLayout(false);
            this.pnl_value.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.majTicksGaugeBusinessObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gge_majTicks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel GaugeTestMajMarksContainer;
        private AGauge.AGauge gge_majTicks;
        private System.Windows.Forms.Panel Gauge1Container;
        private AGauge.AGauge aGauge1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_value;
        private System.Windows.Forms.TrackBar tb_value;
        private System.Windows.Forms.NumericUpDown nud_value;
        private System.Windows.Forms.Label lbl_value;
        private System.Windows.Forms.BindingSource majTicksGaugeBusinessObjectBindingSource;
    }
}

