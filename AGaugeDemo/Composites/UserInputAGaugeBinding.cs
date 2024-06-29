using AGaugeDemo.UserInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AGaugeDemo.Composites
{
    internal class UserInputAGaugeBinding : INotifyPropertyChanged
    {
        private readonly UserInputAGauge _parentControl;

        public ManualInputCollection ManualInputs
        {
            get { return _manualInputs; }
            set
            {
                if (_manualInputs != value)
                {
                    _manualInputs = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private ManualInputCollection _manualInputs;

        //public List<ManualInput<int>> ManualInputs
        //{
        //    get { return _manualInputs; }
        //}
        //private readonly List<ManualInput<int>> _manualInputs;

        public UserInputAGaugeBinding(UserInputAGauge parentControl)
        {
            _parentControl = parentControl;
            ManualInputs = new ManualInputCollection(parentControl.aGauge.GetType().GetProperties());
            ManualInputs.ListChanged += ManualInputs_ListChanged;
            ManualInputs.GetSerializer();
        }

        private void ManualInputs_ListChanged(object sender, ListChangedEventArgs e)
        {
            _parentControl.UpdateInputControlsList(sender, e);
        }

        //manualInputs.ListChanged += (object sender, ListChangedEventArgs e) =>
        //{
        //    NotifyPropertyChanged(nameof(ManualInputs));
        //};

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
