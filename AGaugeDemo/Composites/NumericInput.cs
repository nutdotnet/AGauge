using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AGaugeDemo.Composites
{
    /// <summary>
    /// A composite control that represents a single user input, with varius controls the user can interact with to
    /// change or view a singular value. Meant to dock inside a parent container.
    /// </summary>
    public partial class NumericInput : UserControl
    {
        #region Fields

        private NumericInputBusinessObject businessObject = new NumericInputBusinessObject();

        #endregion

        #region Designer Properties

        public new string Name { get => businessObject.Name; set { businessObject.Name = value; } }

        [Category("Data"),
            Description("Value that is represented by this control."),
            Bindable(true)]
        public int Value { get => businessObject.Value; set { businessObject.Value = value; } }

        [Category("Behavior"),
            Description("The smallest value that can be displayed and accepted by this control."),
            Bindable(true)]
        public int MinValue { get => businessObject.MinValue; set { businessObject.MinValue = value; } }

        [Category("Behavior"),
            Description("The largest value that can be displayed and accepted by this control."),
            Bindable(true)]
        public int MaxValue { get => businessObject.MaxValue; set { businessObject.MaxValue = value; } }

        #endregion

        // Make sure user-input changes are propagated up to binded listeners.
        public event EventHandler ValueChanged;

        private void OnValueChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
                ValueChanged?.Invoke(this, e);
        }

        public NumericInput()
        {
            InitializeComponent();

            businessObject.PropertyChanged += OnValueChanged;
            numericInputBusinessObjectBindingSource.DataSource = businessObject;
        }

        public NumericInput(string name) : this()
        {
            Name = name;
        }

        /// <summary>
        /// Business object to aid with databinding.
        /// </summary>
        public class NumericInputBusinessObject : INotifyPropertyChanged
        {
            #region Properties

            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private string _name;

            public int Value
            {
                get { return _value; }
                set
                {
                    if (value != _value)
                    {
                        _value = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private int _value;

            public int MinValue
            {
                get { return _minValue; }
                // Only allow setting if the new value is not equal to the old min. value, and if the new min. value
                // is less than the current Value.
                set
                {
                    if (value != _minValue && value < Value)
                    {
                        _minValue = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private int _minValue;

            public int MaxValue
            {
                get { return _maxValue; }
                set
                {
                    if (value != _maxValue && value > Value)
                    {
                        _maxValue = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private int _maxValue;

            #endregion

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
