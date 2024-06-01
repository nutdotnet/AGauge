using System.Collections;

namespace AGauge
{
  public class AGaugeRangeCollection : CollectionBase
  {
    private AGaugeControl m_Owner;
    public AGaugeRangeCollection(AGaugeControl sender) { m_Owner = sender; }
    private void NotifyChanging()
    {
      if (m_Owner != null)
      {
        m_Owner.NotifyChanging(nameof(AGaugeControl.GaugeRanges));
      }
    }

    private void NotifyChanged()
    {
      if (m_Owner != null)
      {
        m_Owner.NotifyChanged(nameof(AGaugeControl.GaugeRanges));
      }
    }

    public AGaugeRange this[int index] { get { return (AGaugeRange)List[index]; } }
    public bool Contains(AGaugeRange itemType) { return List.Contains(itemType); }
    public int Add(AGaugeRange itemType)
    {
      itemType.SetOwner(m_Owner);
      if (string.IsNullOrEmpty(itemType.Name)) itemType.Name = GetUniqueName();
      var ret = List.Add(itemType);
      if (m_Owner != null) m_Owner.RepaintControl();
      return ret;
    }
    public void Remove(AGaugeRange itemType)
    {
      List.Remove(itemType);
      if (m_Owner != null) m_Owner.RepaintControl();
    }
    public void Insert(int index, AGaugeRange itemType)
    {
      itemType.SetOwner(m_Owner);
      if (string.IsNullOrEmpty(itemType.Name)) itemType.Name = GetUniqueName();
      List.Insert(index, itemType);
      if (m_Owner != null) m_Owner.RepaintControl();
    }
    public int IndexOf(AGaugeRange itemType) { return List.IndexOf(itemType); }
    public AGaugeRange FindByName(string name)
    {
      foreach (AGaugeRange ptrRange in List)
      {
        if (ptrRange.Name == name) return ptrRange;
      }
      return null;
    }

    protected override void OnSet(int index, object oldValue, object newValue)
    {
      NotifyChanging();
    }

    protected override void OnSetComplete(int index, object oldValue, object newValue)
    {
      m_Owner?.RepaintControl();
      NotifyChanged();
    }

    protected override void OnInsert(int index, object value)
    {
      NotifyChanging();
      var Range = (AGaugeRange)value;
      if (string.IsNullOrEmpty(Range.Name))
      {
        Range.Name = GetUniqueName();
      }
      Range.SetOwner(m_Owner);
    }

    protected override void OnInsertComplete(int index, object value)
    {
      if (m_Owner != null)
      {
        m_Owner.RepaintControl();
      }
      NotifyChanged();
    }

    protected override void OnRemove(int index, object value)
    {
      NotifyChanging();
    }

    protected override void OnRemoveComplete(int index, object value)
    {
      if (m_Owner != null)
      {
        m_Owner.RepaintControl();
      }
      NotifyChanged();
    }

    protected override void OnClear()
    {
      NotifyChanging();
    }

    protected override void OnClearComplete()
    {
      if (m_Owner != null)
      {
        m_Owner.RepaintControl();
      }
      NotifyChanged();
    }

    private string GetUniqueName()
    {
      const string Prefix = "GaugeRange";
      int index = 1;
      bool valid;
      while (this.Count != 0)
      {
        valid = true;
        for (int x = 0; x < this.Count; x++)
        {
          if (this[x].Name == (Prefix + index.ToString()))
          {
            valid = false;
            break;
          }
        }
        if (valid) break;
        index++;
      };
      return Prefix + index.ToString();
    }
  }
}
