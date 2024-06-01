using System;
using System.Drawing;

namespace AGauge
{
  public class AGaugeLabel
  {
    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Design"),
    System.ComponentModel.DisplayName("(Name)"),
    System.ComponentModel.Description("Instance Name.")]
    public string Name { get { return _Name; } set { NotifyChanging(); _Name = value; NotifyChanged(); } }
    private string _Name;

    [System.ComponentModel.Browsable(false)]
    public void SetOwner(AGaugeControl value) { Owner = value; }
    private AGaugeControl Owner;

    private void NotifyOwner() { if (Owner != null) Owner.RepaintControl(); }

    private void NotifyChanging()
    {
      if (Owner != null)
      {
        Owner.NotifyChanging(nameof(AGaugeControl.GaugeLabels));
      }
    }

    private void NotifyChanged()
    {
      if (Owner != null)
      {
        Owner.NotifyChanged(nameof(AGaugeControl.GaugeLabels));
      }
    }

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Appearance"),
    System.ComponentModel.Description("The color of the caption text.")]
    public Color Color { get { return _Color; } set { NotifyChanging(); _Color = value; NotifyOwner(); NotifyChanged();  } }
    private Color _Color = Color.FromKnownColor(KnownColor.WindowText);

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Appearance"),
    System.ComponentModel.Description("The text of the caption.")]
    public String Text { get { return _Text; } set { NotifyChanging(); _Text = value; NotifyOwner(); NotifyChanged(); } }
    private String _Text;

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Appearance"),
    System.ComponentModel.Description("The position of the caption.")]
    public Point Position { get { return _Position; } set { NotifyChanging(); _Position = value; NotifyOwner(); NotifyChanged(); } }
    private Point _Position;

    [System.ComponentModel.Browsable(true),
    System.ComponentModel.Category("Appearance"),
    System.ComponentModel.Description("Font of Text.")]
    public Font Font { get { return _Font; } set { NotifyChanging(); _Font = value; NotifyOwner(); NotifyChanged(); } }
    private Font _Font = DefaultFont;

    public void ResetFont() { NotifyChanging(); _Font = DefaultFont; NotifyChanged(); }
    private Boolean ShouldSerializeFont() { return (_Font != DefaultFont); }
    private static Font DefaultFont = System.Windows.Forms.Control.DefaultFont;
  }
}
