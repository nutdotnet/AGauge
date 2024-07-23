using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AGaugeDemo.Composites
{
    [Description("Composite control with an AGaugeControl and list of inputs the user can manually interact with.")]
    public partial class UserInputAGauge : UserControl
    {
        private UserInputAGaugeBusinessObject businessObject = new UserInputAGaugeBusinessObject();

        public UserInputAGauge()
        {
            InitializeComponent();

            userInputAGaugeBusinessObjectBindingSource.DataSource = businessObject;
        }

        public class UserInputAGaugeBusinessObject : INotifyPropertyChanged
        {
            public int Value
            {
                get => _value;
                set
                {
                    if (_value != value && value >= MinValue)
                    {
                        _value = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private int _value = 0;

            public int MinValue
            {
                get => _minValue;
                set
                {
                    if (_minValue != value && value <= Value)
                    {
                        _minValue = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private int _minValue = -100;

            public int MaxValue
            {
                get => _maxValue;
                set
                {
                    if (_maxValue != value && value >= Value)
                    {
                        _maxValue = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private int _maxValue = 400;

            public int MajorStepValue
            {
                get => _majStepVal;
                set
                {
                    if ( _majStepVal != value)
                    {
                        _majStepVal = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private int _majStepVal = 50;

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
