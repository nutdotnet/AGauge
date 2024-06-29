using System;
using System.Drawing;

namespace AGauge
{
  public class AGaugeRange
  {
    public AGaugeRange() { }

    public AGaugeRange(Color color, Single startValue, Single endValue)
    {
      Color = color;
      _StartValue = startValue;
      _EndValue = endValue;
    }

    public AGaugeRange(Color color, Single startValue, Single endValue, Int32 innerRadius, Int32 outerRadius)
    {
      Color = color;
      _StartValue = startValue;
      _EndValue = endValue;
      InnerRadius = innerRadius;
      OuterRadius = outerRadius;
    }

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Design"),
    System.ComponentModel.DisplayName("(Name)"),
    System.ComponentModel.Description("Instance Name.")]
    public string Name { get { return _Name; } set { NotifyChanging(); _Name = value; NotifyChanged(); } }
    private string _Name; 

    [System.ComponentModel.Browsable(false)]
    public Boolean InRange { get; set; }

    private AGaugeControl Owner;
    [System.ComponentModel.Browsable(false)]
    public void SetOwner(AGaugeControl value) { Owner = value; }
    private void NotifyOwner() { if (Owner != null) Owner.RepaintControl(); }
    private void NotifyChanging()
    {
      if (Owner != null)
      {
        Owner.NotifyChanging(nameof(AGaugeControl.GaugeRanges));
      }
    }

    private void NotifyChanged()
    {
      if (Owner != null)
      {
        Owner.NotifyChanged(nameof(AGaugeControl.GaugeRanges));
      }
    }

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Appearance"),
    System.ComponentModel.Description("The color of the range.")]
    public Color Color { get { return _Color; } set { NotifyChanging(); _Color = value; NotifyOwner(); NotifyChanged(); } }
    private Color _Color;

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Limits"),
    System.ComponentModel.Description("The start value of the range, must be less than RangeEndValue.")]
    public Single StartValue
    {
      get { return _StartValue; }
      set
      {
        NotifyChanging();
        if (Owner != null)
        {
          if (value < Owner.MinValue) value = Owner.MinValue;
          if (value > Owner.MaxValue) value = Owner.MaxValue;
        }
        _StartValue = value;
        NotifyOwner();
        NotifyChanged();
      }
    }
    private Single _StartValue;

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Limits"),
    System.ComponentModel.Description("The end value of the range. Must be greater than RangeStartValue.")]
    public Single EndValue
    {
      get { return _EndValue; }
      set
      {
        NotifyChanging();
        if (Owner != null)
        {
          if (value < Owner.MinValue) value = Owner.MinValue;
          if (value > Owner.MaxValue) value = Owner.MaxValue;
        }
        _EndValue = value;
        NotifyOwner();
        NotifyChanged();
      }
    }
    private Single _EndValue;

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Appearance"),
    System.ComponentModel.Description("The inner radius of the range.")]
    public Int32 InnerRadius
    {
      get { return _InnerRadius; }
      set { if (value > 0) { NotifyChanging(); _InnerRadius = value; NotifyOwner(); NotifyChanged(); } }
    }
    private Int32 _InnerRadius = 70;

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Appearance"),
    System.ComponentModel.Description("The outer radius of the range.")]
    public Int32 OuterRadius
    {
      get { return _OuterRadius; }
      set { if (value > 0) { NotifyChanging(); _OuterRadius = value; NotifyOwner(); NotifyChanged(); } }
    }
    private Int32 _OuterRadius = 80;
  }
}
