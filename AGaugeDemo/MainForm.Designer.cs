namespace AGaugeDemo
{
    partial class MainForm
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
            System.Windows.Forms.AGaugeLabel aGaugeLabel7 = new System.Windows.Forms.AGaugeLabel();
            System.Windows.Forms.AGaugeRange aGaugeRange19 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange20 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange21 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeLabel aGaugeLabel8 = new System.Windows.Forms.AGaugeLabel();
            System.Windows.Forms.AGaugeRange aGaugeRange22 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange23 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange24 = new System.Windows.Forms.AGaugeRange();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.aGauge1 = new System.Windows.Forms.AGauge();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Gauge1Container = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.GaugeTestMajMarksContainer = new System.Windows.Forms.Panel();
            this.aGauge2 = new System.Windows.Forms.AGauge();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aGauge1)).BeginInit();
            this.Gauge1Container.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.GaugeTestMajMarksContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aGauge2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(3, 3);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 238);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // aGauge1
            // 
            this.aGauge1.BackColor = System.Drawing.SystemColors.Control;
            aGaugeLabel7.Color = System.Drawing.SystemColors.WindowText;
            aGaugeLabel7.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            aGaugeLabel7.Name = "GaugeLabel1";
            aGaugeLabel7.Position = new System.Drawing.Point(85, 130);
            aGaugeLabel7.Text = "0";
            this.aGauge1.GaugeLabels.Add(aGaugeLabel7);
            aGaugeRange19.Color = System.Drawing.Color.Red;
            aGaugeRange19.EndValue = 200F;
            aGaugeRange19.InnerRadius = 70;
            aGaugeRange19.InRange = false;
            aGaugeRange19.Name = "AlertRange";
            aGaugeRange19.OuterRadius = 80;
            aGaugeRange19.StartValue = 160F;
            aGaugeRange20.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            aGaugeRange20.EndValue = 160F;
            aGaugeRange20.InnerRadius = 70;
            aGaugeRange20.InRange = false;
            aGaugeRange20.Name = "GaugeRange3";
            aGaugeRange20.OuterRadius = 75;
            aGaugeRange20.StartValue = 0F;
            aGaugeRange21.Color = System.Drawing.Color.Lime;
            aGaugeRange21.EndValue = 160F;
            aGaugeRange21.InnerRadius = 75;
            aGaugeRange21.InRange = false;
            aGaugeRange21.Name = "GaugeRange2";
            aGaugeRange21.OuterRadius = 80;
            aGaugeRange21.StartValue = 0F;
            this.aGauge1.GaugeRanges.Add(aGaugeRange19);
            this.aGauge1.GaugeRanges.Add(aGaugeRange20);
            this.aGauge1.GaugeRanges.Add(aGaugeRange21);
            this.aGauge1.Location = new System.Drawing.Point(53, 14);
            this.aGauge1.MaxValue = 200F;
            this.aGauge1.MinValue = 0F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Yellow;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.Olive;
            this.aGauge1.ScaleLinesMajorStepValue = 20F;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.Size = new System.Drawing.Size(205, 180);
            this.aGauge1.TabIndex = 0;
            this.aGauge1.Text = "aGauge1";
            this.aGauge1.Value = 0F;
            this.aGauge1.ValueChanged += new System.EventHandler(this.aGauge1_ValueChanged);
            this.aGauge1.ValueInRangeChanged += new System.EventHandler<System.Windows.Forms.ValueInRangeChangedEventArgs>(this.aGauge1_ValueInRangeChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(210, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 28);
            this.panel1.TabIndex = 2;
            // 
            // Gauge1Container
            // 
            this.Gauge1Container.AutoSize = true;
            this.Gauge1Container.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Gauge1Container.Controls.Add(this.aGauge1);
            this.Gauge1Container.Controls.Add(this.trackBar1);
            this.Gauge1Container.Controls.Add(this.panel1);
            this.Gauge1Container.Location = new System.Drawing.Point(3, 3);
            this.Gauge1Container.Name = "Gauge1Container";
            this.Gauge1Container.Size = new System.Drawing.Size(261, 244);
            this.Gauge1Container.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.Gauge1Container);
            this.flowLayoutPanel1.Controls.Add(this.GaugeTestMajMarksContainer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(720, 514);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // GaugeTestMajMarksContainer
            // 
            this.GaugeTestMajMarksContainer.AutoSize = true;
            this.GaugeTestMajMarksContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GaugeTestMajMarksContainer.Controls.Add(this.aGauge2);
            this.GaugeTestMajMarksContainer.Controls.Add(this.trackBar2);
            this.GaugeTestMajMarksContainer.Controls.Add(this.panel3);
            this.GaugeTestMajMarksContainer.Location = new System.Drawing.Point(270, 3);
            this.GaugeTestMajMarksContainer.Name = "GaugeTestMajMarksContainer";
            this.GaugeTestMajMarksContainer.Size = new System.Drawing.Size(261, 244);
            this.GaugeTestMajMarksContainer.TabIndex = 4;
            // 
            // aGauge2
            // 
            this.aGauge2.BackColor = System.Drawing.SystemColors.Control;
            aGaugeLabel8.Color = System.Drawing.SystemColors.WindowText;
            aGaugeLabel8.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            aGaugeLabel8.Name = "GaugeLabel1";
            aGaugeLabel8.Position = new System.Drawing.Point(85, 130);
            aGaugeLabel8.Text = "0";
            this.aGauge2.GaugeLabels.Add(aGaugeLabel8);
            aGaugeRange22.Color = System.Drawing.Color.Red;
            aGaugeRange22.EndValue = 200F;
            aGaugeRange22.InnerRadius = 70;
            aGaugeRange22.InRange = false;
            aGaugeRange22.Name = "AlertRange";
            aGaugeRange22.OuterRadius = 80;
            aGaugeRange22.StartValue = 160F;
            aGaugeRange23.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            aGaugeRange23.EndValue = 160F;
            aGaugeRange23.InnerRadius = 70;
            aGaugeRange23.InRange = false;
            aGaugeRange23.Name = "GaugeRange3";
            aGaugeRange23.OuterRadius = 75;
            aGaugeRange23.StartValue = 0F;
            aGaugeRange24.Color = System.Drawing.Color.Lime;
            aGaugeRange24.EndValue = 160F;
            aGaugeRange24.InnerRadius = 75;
            aGaugeRange24.InRange = false;
            aGaugeRange24.Name = "GaugeRange2";
            aGaugeRange24.OuterRadius = 80;
            aGaugeRange24.StartValue = 0F;
            this.aGauge2.GaugeRanges.Add(aGaugeRange22);
            this.aGauge2.GaugeRanges.Add(aGaugeRange23);
            this.aGauge2.GaugeRanges.Add(aGaugeRange24);
            this.aGauge2.Location = new System.Drawing.Point(53, 14);
            this.aGauge2.MaxValue = 200F;
            this.aGauge2.MinValue = 0F;
            this.aGauge2.Name = "aGauge2";
            this.aGauge2.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Yellow;
            this.aGauge2.NeedleColor2 = System.Drawing.Color.Olive;
            this.aGauge2.ScaleLinesMajorStepValue = 20F;
            this.aGauge2.ScaleNumbersFormat = null;
            this.aGauge2.Size = new System.Drawing.Size(205, 180);
            this.aGauge2.TabIndex = 0;
            this.aGauge2.Text = "aGauge2";
            this.aGauge2.Value = 0F;
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 20;
            this.trackBar2.Location = new System.Drawing.Point(3, 3);
            this.trackBar2.Maximum = 200;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 238);
            this.trackBar2.TabIndex = 1;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(210, 201);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(47, 28);
            this.panel3.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 514);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "GaugeDemo";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aGauge1)).EndInit();
            this.Gauge1Container.ResumeLayout(false);
            this.Gauge1Container.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.GaugeTestMajMarksContainer.ResumeLayout(false);
            this.GaugeTestMajMarksContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aGauge2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.AGauge aGauge1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Gauge1Container;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel GaugeTestMajMarksContainer;
        private System.Windows.Forms.AGauge aGauge2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Panel panel3;
    }
}

