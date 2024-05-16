using AGauge;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AGaugeDemo
{
    public partial class GaugeDemo : Form
    {
        private AGaugeLabel label;
        private AGaugeRange alert;
        private MajTicksGaugeBusinessObject majTicksGBO = new MajTicksGaugeBusinessObject();

        public GaugeDemo()
        {
            InitializeComponent();
            label = aGauge1.GaugeLabels.FindByName("GaugeLabel1");
            alert = aGauge1.GaugeRanges.FindByName("AlertRange");

            majTicksGaugeBusinessObjectBindingSource.DataSource = majTicksGBO;
        }

        #region aGauge1

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            aGauge1.Value = trackBar1.Value;
        }

        private void aGauge1_ValueChanged(object sender, EventArgs e)
        {
            label.Text = aGauge1.Value.ToString();
        }

        private void aGauge1_ValueInRangeChanged(object sender, ValueInRangeChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("InRange Event.");
            if (e.Range == alert)
            {
                panel1.BackColor = e.InRange ? Color.Red : Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //aGauge1.GaugeRanges.RemoveAt(0);
            aGauge1.GaugeRanges.Add(new AGaugeRange(Color.Blue, 40, 60));
        }

        #endregion

        #region gge_majTicks


        #endregion

        public class MajTicksGaugeBusinessObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private int _value;
            public int Value
            {
                get { return _value; }
                set
                {
                    if (value != _value) {
                        _value = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
    }
}
