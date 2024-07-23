using System;

namespace AGaugeClassic
{
  /// <summary>
  /// Event argument for <see cref="ValueInRangeChanged"/> event.
  /// </summary>
  public class ValueInRangeChangedEventArgs : EventArgs
  {
    /// <summary>
    /// Affected GaugeRange
    /// </summary>
    public AGaugeRange Range { get; private set; }
    /// <summary>
    /// Gauge Value
    /// </summary>
    public Single Value { get; private set; }
    /// <summary>
    /// True if value is within current range.
    /// </summary>
    public bool InRange { get; private set; }
    public ValueInRangeChangedEventArgs(AGaugeRange range, Single value, bool inRange)
    {
      Range = range;
      Value = value;
      InRange = inRange;
    }
  }
}
