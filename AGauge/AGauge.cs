// Copyright (C) 2007 A.J.Bauer
//
//  This software is provided as-is, without any express or implied
//  warranty.  In no event will the authors be held liable for any damages
//  arising from the use of this software.

//  Permission is granted to anyone to use this software for any purpose,
//  including commercial applications, and to alter it and redistribute it
//  freely, subject to the following restrictions:
//  1. The origin of this software must not be misrepresented; you must not
//     claim that you wrote the original software. if you use this software
//     in a product, an acknowledgment in the product documentation would be
//     appreciated but is not required.
//  2. Altered source versions must be plainly marked as such, and must not be
//     misrepresented as being the original software.
//  3. This notice may not be removed or altered from any source distribution.
//
// -----------------------------------------------------------------------------------
// Copyright (C) 2012 Code Artist
// 
// Added several improvement to original code created by A.J.Bauer.
// Visit: http://codearteng.blogspot.com for more information on change history.
//
// -----------------------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace System.Windows.Forms
{
    /// <summary>
    /// <para>AGauge - Copyright (C) 2007 A.J.Bauer</para>
    /// <link>http://www.codeproject.com/Articles/17559/A-fast-and-performing-gauge</link>
    /// </summary>
    [ToolboxBitmap(typeof(AGauge), "AGauge.AGauge.bmp"),
  DefaultEvent("ValueInRangeChanged"),
  Description("Displays a value on an analog gauge. Raises an event if the value enters one of the definable ranges.")]
    public partial class AGauge : Control, ISupportInitialize
    {
        #region Private Fields

        /// <summary>
        /// When initializing we allow <see cref="Value"/> to be outside
        /// outside the range <see cref="MinValue"/>-<see cref="MaxValue"/>. 
        /// This ensures that the desired values can be set regardless of 
        /// the order properties are changed. 
        /// See <see cref="ISupportInitialize"/>
        /// </summary>
        private bool m_bInitializing = false;

        protected double widthFactor;
        protected double heightFactor;
        protected float centerFactor;

        private Single fontBoundY1;
        private Single fontBoundY2;
        private bool drawCenter = true;

        private Single m_value;
        private Single m_MinValue = m_DefaultMinValue;
        private Single m_MaxValue = m_DefaultMaxValue;

        private const Single m_DefaultMinValue = -100;
        private const Single m_DefaultMaxValue = 400;

        private const Int32 m_DefaultBaseArcRadius = 80;
        private const Int32 m_DefaultBaseArcStart = 135;
        private const Int32 m_DefaultBaseArcSweep = 270;
        private const Int32 m_DefaultBaseArcWidth = 2;

        private const Int32 m_DefaultScaleLinesInterInnerRadius = 73;
        private const Int32 m_DefaultScaleLinesInterOuterRadius = 80;
        private const Int32 m_DefaultScaleLinesInterWidth = 1;

        private const Int32 m_DefaultScaleLinesMinorTicks = 9;
        private const Int32 m_DefaultScaleLinesMinorInnerRadius = 75;
        private const Int32 m_DefaultScaleLinesMinorOuterRadius = 80;
        private const Int32 m_DefaultScaleLinesMinorWidth = 1;

        private const Single m_DefaultScaleLinesMajorStepValue = 50.0f;
        private const Int32 m_DefaultScaleLinesMajorInnerRadius = 70;
        private const Int32 m_DefaultScaleLinesMajorOuterRadius = 80;
        private const Int32 m_DefaultScaleLinesMajorWidth = 2;

        private Color m_BaseArcColor = Color.Gray;
        private Int32 m_BaseArcRadius = m_DefaultBaseArcRadius;
        private Int32 m_BaseArcStart = m_DefaultBaseArcStart;
        private Int32 m_BaseArcSweep = m_DefaultBaseArcSweep;
        private Int32 m_BaseArcWidth = m_DefaultBaseArcWidth;

        private Color m_ScaleLinesInterColor = Color.Black;
        private Int32 m_ScaleLinesInterInnerRadius = m_DefaultScaleLinesInterInnerRadius;
        private Int32 m_ScaleLinesInterOuterRadius = m_DefaultScaleLinesInterOuterRadius;
        private Int32 m_ScaleLinesInterWidth = m_DefaultScaleLinesInterWidth;

        private Int32 m_ScaleLinesMinorTicks = m_DefaultScaleLinesMinorTicks;
        private Color m_ScaleLinesMinorColor = Color.Gray;
        private Int32 m_ScaleLinesMinorInnerRadius = m_DefaultScaleLinesMinorInnerRadius;
        private Int32 m_ScaleLinesMinorOuterRadius = m_DefaultScaleLinesMinorOuterRadius;
        private Int32 m_ScaleLinesMinorWidth = m_DefaultScaleLinesMinorWidth;

        private Single m_ScaleLinesMajorStepValue = m_DefaultScaleLinesMajorStepValue;
        private Color m_ScaleLinesMajorColor = Color.Black;
        private Int32 m_ScaleLinesMajorInnerRadius = m_DefaultScaleLinesMajorInnerRadius;
        private Int32 m_ScaleLinesMajorOuterRadius = m_DefaultScaleLinesMajorOuterRadius;
        private Int32 m_ScaleLinesMajorWidth = m_DefaultScaleLinesMajorWidth;

        private const Int32 m_DefaultScaleNumbersRadius = 95;
        private const Int32 m_DefaultScaleNumbersStepScaleLines = 1;
        private const Int32 m_DefaultScaleNumbersRotation = 0;
        private const Int32 m_DefaultScaleNumbersStartScaleLine = 1;

        private Int32 m_ScaleNumbersRadius = m_DefaultScaleNumbersRadius;
        private Color m_ScaleNumbersColor = Color.Black;
        private String m_ScaleNumbersFormat = string.Empty;
        private Int32 m_ScaleNumbersStartScaleLine = m_DefaultScaleNumbersStartScaleLine;
        private Int32 m_ScaleNumbersStepScaleLines = m_DefaultScaleNumbersStepScaleLines;
        private Int32 m_ScaleNumbersRotation = m_DefaultScaleNumbersRotation;


        private const NeedleType m_DefaultNeedleType = NeedleType.Advance;
        private const Int32 m_DefaultNeedleRadius = 80;
        private const AGaugeNeedleColor m_DefaultNeedleColor1 = AGaugeNeedleColor.Gray;
        private const Int32 m_DefaultNeedleWidth = 2;

        private NeedleType m_NeedleType = m_DefaultNeedleType;
        private Int32 m_NeedleRadius = m_DefaultNeedleRadius;
        private AGaugeNeedleColor m_NeedleColor1 = m_DefaultNeedleColor1;
        private Color m_NeedleColor2 = Color.DimGray;
        private Int32 m_NeedleWidth = m_DefaultNeedleWidth;

        #endregion

        #region EventHandler

        [Description("This event is raised when gauge value changed.")]
        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }

        [Description("This event is raised if the value is entering or leaving defined range.")]
        public event EventHandler<ValueInRangeChangedEventArgs> ValueInRangeChanged;

        protected virtual void OnValueInRangeChanged(object sender, ValueInRangeChangedEventArgs e)
        {
            ValueInRangeChanged?.Invoke(sender, e);
        }

        #endregion

        #region Hidden and overridden inherited properties

        public new Boolean AllowDrop { get { return false; } set { /*Do Nothing */ } }
        public new Boolean AutoSize { get { return base.AutoSize; } set { /*Do Nothing */ } }
        public new Boolean ForeColor { get { return false; } set { /*Do Nothing */ } }
        public new Boolean ImeMode { get { return false; } set { /*Do Nothing */ } }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                Refresh();
            }
        }
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Refresh();
            }
        }
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set
            {
                base.BackgroundImageLayout = value;
                Refresh();
            }
        }
        #endregion

        public AGauge()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            _GaugeRanges = new AGaugeRangeCollection(this);
            _GaugeLabels = new AGaugeLabelCollection(this);

            //Default Values
            Size = new Size(205, 180);
            UpdateScalingFactors();
        }

        #region Properties  
        [Browsable(true),
        Category(Categories.Data),
        Description("Gauge value.")]
        public Single Value
        {
            get { return m_value; }
            set
            {
                if (!m_bInitializing)
                {
                    value = Math.Min(Math.Max(value, m_MinValue), m_MaxValue);
                }

                if (m_value != value)
                {
                    m_value = value;
                    OnValueChanged(this, EventArgs.Empty);

                    foreach (AGaugeRange ptrRange in _GaugeRanges)
                    {
                        if ((m_value >= ptrRange.StartValue)
                            && (m_value <= ptrRange.EndValue))
                        {
                            //Entering Range
                            if (!ptrRange.InRange)
                            {
                                ptrRange.InRange = true;
                                OnValueInRangeChanged(this,
                                    new ValueInRangeChangedEventArgs(ptrRange, m_value, ptrRange.InRange));
                            }
                        }
                        else
                        {
                            //Leaving Range
                            if (ptrRange.InRange)
                            {
                                ptrRange.InRange = false;
                                OnValueInRangeChanged(this,
                                    new ValueInRangeChangedEventArgs(ptrRange, m_value, ptrRange.InRange));
                            }
                        }
                    }
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Appearance),
        Description("Gauge Ranges.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AGaugeRangeCollection GaugeRanges => _GaugeRanges;
        private readonly AGaugeRangeCollection _GaugeRanges;

        [Browsable(true),
        Category(Categories.Appearance),
        Description("Gauge Labels.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AGaugeLabelCollection GaugeLabels => _GaugeLabels;
        private readonly AGaugeLabelCollection _GaugeLabels;

        #region << Gauge Base >>
        public Point Center
        {
            get { return new Point(Size.Width / 2, Size.Height / 2); }
        }

        [Browsable(true),
        Category(Categories.Colors),
        Description("The color of the base arc.")]
        [DefaultValue(typeof(Color), nameof(Color.Gray))]
        public Color BaseArcColor
        {
            get { return m_BaseArcColor; }
            set
            {
                if (m_BaseArcColor != value)
                {
                    m_BaseArcColor = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The radius of the base arc.")]
        [DefaultValue(m_DefaultBaseArcRadius)]
        public Int32 BaseArcRadius
        {
            get { return m_BaseArcRadius; }
            set
            {
                if (m_BaseArcRadius != value)
                {
                    m_BaseArcRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The start angle of the base arc.")]
        [DefaultValue(m_DefaultBaseArcStart)]
        public Int32 BaseArcStart
        {
            get { return m_BaseArcStart; }
            set
            {
                if (m_BaseArcStart != value)
                {
                    m_BaseArcStart = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The sweep angle of the base arc.")]
        [DefaultValue(m_DefaultBaseArcSweep)]
        public Int32 BaseArcSweep
        {
            get { return m_BaseArcSweep; }
            set
            {
                if (m_BaseArcSweep != value)
                {
                    m_BaseArcSweep = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The width of the base arc.")]
        [DefaultValue(m_DefaultBaseArcWidth)]
        public Int32 BaseArcWidth
        {
            get { return m_BaseArcWidth; }
            set
            {
                if (m_BaseArcWidth != value)
                {
                    m_BaseArcWidth = value;
                    Refresh();
                }
            }
        }

        #endregion

        #region << Gauge Scale >>

        [Browsable(true),
        Category(Categories.Data),
        Description("The minimum value to show on the scale.")]
        [DefaultValue(m_DefaultMinValue)]
        public Single MinValue
        {
            get { return m_MinValue; }
            set
            {
                m_MinValue = value;
                if (m_MinValue > m_MaxValue)
                {
                    m_MaxValue = value;
                }

                if (!m_bInitializing)
                {
                    Value = Constrain(m_value);
                }

                m_ScaleLinesMajorStepValue = Math.Min(m_ScaleLinesMajorStepValue, m_MaxValue - m_MinValue);
                Refresh();
            }
        }

        [Browsable(true),
        Category(Categories.Data),
        Description("The maximum value to show on the scale.")]
        [DefaultValue(m_DefaultMaxValue)]
        public Single MaxValue
        {
            get { return m_MaxValue; }
            set
            {
                m_MaxValue = value;
                if (m_MaxValue < m_MinValue)
                {
                    m_MinValue = value;
                }

                if (!m_bInitializing)
                {
                    Value = Constrain(m_value);
                }

                m_ScaleLinesMajorStepValue = Math.Min(m_ScaleLinesMajorStepValue, m_MaxValue - m_MinValue);
                Refresh();
            }
        }

        [Browsable(true),
        Category(Categories.Colors),
        Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DefaultValue(typeof(Color), "Black")]
        public Color ScaleLinesInterColor
        {
            get { return m_ScaleLinesInterColor; }
            set
            {
                if (m_ScaleLinesInterColor != value)
                {
                    m_ScaleLinesInterColor = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The inner radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DefaultValue(m_DefaultScaleLinesInterInnerRadius)]
        public Int32 ScaleLinesInterInnerRadius
        {
            get { return m_ScaleLinesInterInnerRadius; }
            set
            {
                if (m_ScaleLinesInterInnerRadius != value)
                {
                    m_ScaleLinesInterInnerRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The outer radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DefaultValue(m_DefaultScaleLinesInterOuterRadius)]
        public Int32 ScaleLinesInterOuterRadius
        {
            get { return m_ScaleLinesInterOuterRadius; }
            set
            {
                if (m_ScaleLinesInterOuterRadius != value)
                {
                    m_ScaleLinesInterOuterRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The width of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DefaultValue(m_DefaultScaleLinesInterWidth)]
        public Int32 ScaleLinesInterWidth
        {
            get { return m_ScaleLinesInterWidth; }
            set
            {
                if (m_ScaleLinesInterWidth != value)
                {
                    m_ScaleLinesInterWidth = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The number of minor scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMinorTicks)]
        public Int32 ScaleLinesMinorTicks
        {
            get { return m_ScaleLinesMinorTicks; }
            set
            {
                if (m_ScaleLinesMinorTicks != value)
                {
                    m_ScaleLinesMinorTicks = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Colors),
        Description("The color of the minor scale lines.")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color ScaleLinesMinorColor
        {
            get { return m_ScaleLinesMinorColor; }
            set
            {
                if (m_ScaleLinesMinorColor != value)
                {
                    m_ScaleLinesMinorColor = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The inner radius of the minor scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMinorInnerRadius)]
        public Int32 ScaleLinesMinorInnerRadius
        {
            get { return m_ScaleLinesMinorInnerRadius; }
            set
            {
                if (m_ScaleLinesMinorInnerRadius != value)
                {
                    m_ScaleLinesMinorInnerRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The outer radius of the minor scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMinorOuterRadius)]
        public Int32 ScaleLinesMinorOuterRadius
        {
            get { return m_ScaleLinesMinorOuterRadius; }
            set
            {
                if (m_ScaleLinesMinorOuterRadius != value)
                {
                    m_ScaleLinesMinorOuterRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The width of the minor scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMinorWidth)]
        public Int32 ScaleLinesMinorWidth
        {
            get { return m_ScaleLinesMinorWidth; }
            set
            {
                if (m_ScaleLinesMinorWidth != value)
                {
                    m_ScaleLinesMinorWidth = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The step value of the major scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMajorStepValue)]
        public Single ScaleLinesMajorStepValue
        {
            get { return m_ScaleLinesMajorStepValue; }
            set
            {
                if ((m_ScaleLinesMajorStepValue != value) && (value > 0))
                {
                    m_ScaleLinesMajorStepValue = Math.Min(value, m_MaxValue - m_MinValue);
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Colors),
        Description("The color of the major scale lines.")]
        [DefaultValue(typeof(Color), "Black")]
        public Color ScaleLinesMajorColor
        {
            get { return m_ScaleLinesMajorColor; }
            set
            {
                if (m_ScaleLinesMajorColor != value)
                {
                    m_ScaleLinesMajorColor = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The inner radius of the major scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMajorInnerRadius)]
        public Int32 ScaleLinesMajorInnerRadius
        {
            get { return m_ScaleLinesMajorInnerRadius; }
            set
            {
                if (m_ScaleLinesMajorInnerRadius != value)
                {
                    m_ScaleLinesMajorInnerRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The outer radius of the major scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMajorOuterRadius)]
        public Int32 ScaleLinesMajorOuterRadius
        {
            get { return m_ScaleLinesMajorOuterRadius; }
            set
            {
                if (m_ScaleLinesMajorOuterRadius != value)
                {
                    m_ScaleLinesMajorOuterRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Scale),
        Description("The width of the major scale lines.")]
        [DefaultValue(m_DefaultScaleLinesMajorWidth)]
        public Int32 ScaleLinesMajorWidth
        {
            get { return m_ScaleLinesMajorWidth; }
            set
            {
                if (m_ScaleLinesMajorWidth != value)
                {
                    m_ScaleLinesMajorWidth = value;
                    Refresh();
                }
            }
        }

        #endregion

        #region << Gauge Scale Numbers >>

        [Browsable(true),
        Category(Categories.Labels),
        Description("The radius of the scale numbers.")]
        [DefaultValue(m_DefaultScaleNumbersRadius)]
        public Int32 ScaleNumbersRadius
        {
            get { return m_ScaleNumbersRadius; }
            set
            {
                if (m_ScaleNumbersRadius != value)
                {
                    m_ScaleNumbersRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Colors),
        Description("The color of the scale numbers.")]
        [DefaultValue(typeof(Color), "Black")]
        public Color ScaleNumbersColor
        {
            get { return m_ScaleNumbersColor; }
            set
            {
                if (m_ScaleNumbersColor != value)
                {
                    m_ScaleNumbersColor = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Labels),
        Description("The format of the scale numbers.")]
        [DefaultValue("")]
        public String ScaleNumbersFormat
        {
            get { return m_ScaleNumbersFormat; }
            set
            {
                if (m_ScaleNumbersFormat != value)
                {
                    m_ScaleNumbersFormat = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Labels),
        Description("The number of the scale line to start writing numbers next to.")]
        [DefaultValue(m_DefaultScaleNumbersStartScaleLine)]
        public Int32 ScaleNumbersStartScaleLine
        {
            get { return m_ScaleNumbersStartScaleLine; }
            set
            {
                if (m_ScaleNumbersStartScaleLine != value)
                {
                    m_ScaleNumbersStartScaleLine = Math.Max(value, 1);
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Labels),
        Description("The number of scale line steps for writing numbers.")]
        [DefaultValue(m_DefaultScaleNumbersStepScaleLines)]
        public Int32 ScaleNumbersStepScaleLines
        {
            get { return m_ScaleNumbersStepScaleLines; }
            set
            {
                if (m_ScaleNumbersStepScaleLines != value)
                {
                    m_ScaleNumbersStepScaleLines = Math.Max(value, 1);
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Labels),
        Description("The angle relative to the tangent of the base arc at a scale line that is used to rotate numbers. set to 0 for no rotation or e.g. set to 90.")]
        [DefaultValue(m_DefaultScaleNumbersRotation)]
        public Int32 ScaleNumbersRotation
        {
            get { return m_ScaleNumbersRotation; }
            set
            {
                if (m_ScaleNumbersRotation != value)
                {
                    m_ScaleNumbersRotation = value;
                    Refresh();
                }
            }
        }

        #endregion

        #region << Gauge Needle >>

        [Browsable(true),
        Category(Categories.Needle),
        Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
        [DefaultValue(typeof(NeedleType), nameof(NeedleType.Advance))]
        public NeedleType NeedleType
        {
            get { return m_NeedleType; }
            set
            {
                if (m_NeedleType != value)
                {
                    m_NeedleType = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Needle),
        Description("The radius of the needle.")]
        [DefaultValue(m_DefaultNeedleRadius)]
        public Int32 NeedleRadius
        {
            get { return m_NeedleRadius; }
            set
            {
                if (m_NeedleRadius != value)
                {
                    m_NeedleRadius = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Colors),
        Description("The first color of the needle.")]
        [DefaultValue(typeof(AGaugeNeedleColor), nameof(AGaugeNeedleColor.Gray))]
        public AGaugeNeedleColor NeedleColor1
        {
            get { return m_NeedleColor1; }
            set
            {
                if (m_NeedleColor1 != value)
                {
                    m_NeedleColor1 = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Colors),
        Description("The second color of the needle.")]
        [DefaultValue(typeof(Color), nameof(Color.DimGray))]
        public Color NeedleColor2
        {
            get { return m_NeedleColor2; }
            set
            {
                if (m_NeedleColor2 != value)
                {
                    m_NeedleColor2 = value;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category(Categories.Needle),
        Description("The width of the needle.")]
        [DefaultValue(m_DefaultNeedleWidth)]
        public Int32 NeedleWidth
        {
            get { return m_NeedleWidth; }
            set
            {
                if (m_NeedleWidth != value)
                {
                    m_NeedleWidth = value;
                    Refresh();
                }
            }
        }

        #endregion

        #endregion

        #region Helper

        private void UpdateScalingFactors()
        {
            widthFactor = 1.0 / (2 * Center.X) * Size.Width;
            heightFactor = 1.0 / (2 * Center.Y) * Size.Height;
            centerFactor = (float)Math.Min(widthFactor, heightFactor);
        }

        private void FindFontBounds()
        {
            //find upper and lower bounds for numeric characters
            Int32 c1;
            Int32 c2;
            Boolean boundfound;
            using (SolidBrush backBrush = new SolidBrush(Color.White))
            using (SolidBrush foreBrush = new SolidBrush(Color.Black))
            {
                using (Bitmap bmpMeasure = new Bitmap(5, 5))
                using (Graphics gMeasure = Graphics.FromImage(bmpMeasure))
                {
                    SizeF boundingBox = gMeasure.MeasureString("0123456789", Font, -1, StringFormat.GenericTypographic);
                    using (var b = new Bitmap((Int32)boundingBox.Width, (Int32)boundingBox.Height))
                    using (var g = Graphics.FromImage(b))
                    {
                        g.FillRectangle(backBrush, 0.0F, 0.0F, boundingBox.Width, boundingBox.Height);
                        g.DrawString("0123456789", Font, foreBrush, 0.0F, 0.0F, StringFormat.GenericTypographic);

                        fontBoundY1 = 0;
                        fontBoundY2 = 0;
                        c1 = 0;
                        boundfound = false;
                        while ((c1 < b.Height) && (!boundfound))
                        {
                            c2 = 0;
                            while ((c2 < b.Width) && (!boundfound))
                            {
                                if (b.GetPixel(c2, c1) != backBrush.Color)
                                {
                                    fontBoundY1 = c1;
                                    boundfound = true;
                                }
                                c2++;
                            }
                            c1++;
                        }

                        c1 = b.Height - 1;
                        boundfound = false;
                        while ((0 < c1) && (!boundfound))
                        {
                            c2 = 0;
                            while ((c2 < b.Width) && (!boundfound))
                            {
                                if (b.GetPixel(c2, c1) != backBrush.Color)
                                {
                                    fontBoundY2 = c1;
                                    boundfound = true;
                                }
                                c2++;
                            }
                            c1--;
                        }
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void RepaintControl()
        {
            Refresh();
        }

        internal void NotifyChanging(string strPropertyName)
        {
            var ChangeService = (IComponentChangeService)Site?.GetService(typeof(IComponentChangeService));
            if (ChangeService != null)
            {
                var pd = TypeDescriptor.GetProperties(this).Find(nameof(strPropertyName), false);
                ChangeService.OnComponentChanging(this, pd);
            }
        }

        internal void NotifyChanged(string strPropertyName)
        {
            var ChangeService = (IComponentChangeService)Site?.GetService(typeof(IComponentChangeService));
            if (ChangeService != null)
            {
                var pd = TypeDescriptor.GetProperties(this).Find(nameof(strPropertyName), false);
                ChangeService.OnComponentChanged(this, pd, null, null);
            }
        }


        #endregion

        #region Base member overrides

        protected sealed override void OnPaintBackground(PaintEventArgs pevent)
        {
            BackgroundPreRender(pevent.Graphics);
            RenderDefaultBackground(pevent.Graphics);
            BackgroundPostRender(pevent.Graphics);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if ((Width < 10) || (Height < 10))
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            #region Needle
            Single brushAngle = (Int32)(m_BaseArcStart + (m_value - m_MinValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue)) % 360;
            if (brushAngle < 0) brushAngle += 360;
            Double needleAngle = brushAngle * Math.PI / 180;

            int needleWidth = (int)(m_NeedleWidth * centerFactor);
            int needleRadius = (int)(m_NeedleRadius * centerFactor);
            switch (m_NeedleType)
            {
                case NeedleType.Advance:
                    PointF[] points = new PointF[3];

                    Int32 subcol = (Int32)((brushAngle + 225) % 180 * 100 / 180);
                    Int32 subcol2 = (Int32)((brushAngle + 135) % 180 * 100 / 180);

                    using (var brNeedle = new SolidBrush(m_NeedleColor2))
                    {
                        e.Graphics.FillEllipse(brNeedle, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                    }

                    Color clr1 = Color.White;
                    Color clr2 = Color.White;
                    Color clr3 = Color.White;
                    Color clr4 = Color.White;

                    switch (m_NeedleColor1)
                    {
                        case AGaugeNeedleColor.Gray:
                            clr1 = Color.FromArgb(80 + subcol, 80 + subcol, 80 + subcol);
                            clr2 = Color.FromArgb(180 - subcol, 180 - subcol, 180 - subcol);
                            clr3 = Color.FromArgb(80 + subcol2, 80 + subcol2, 80 + subcol2);
                            clr4 = Color.FromArgb(180 - subcol2, 180 - subcol2, 180 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Gray, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case AGaugeNeedleColor.Red:
                            clr1 = Color.FromArgb(145 + subcol, subcol, subcol);
                            clr2 = Color.FromArgb(245 - subcol, 100 - subcol, 100 - subcol);
                            clr3 = Color.FromArgb(145 + subcol2, subcol2, subcol2);
                            clr4 = Color.FromArgb(245 - subcol2, 100 - subcol2, 100 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Red, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case AGaugeNeedleColor.Green:
                            clr1 = Color.FromArgb(subcol, 145 + subcol, subcol);
                            clr2 = Color.FromArgb(100 - subcol, 245 - subcol, 100 - subcol);
                            clr3 = Color.FromArgb(subcol2, 145 + subcol2, subcol2);
                            clr4 = Color.FromArgb(100 - subcol2, 245 - subcol2, 100 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Green, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case AGaugeNeedleColor.Blue:
                            clr1 = Color.FromArgb(subcol, subcol, 145 + subcol);
                            clr2 = Color.FromArgb(100 - subcol, 100 - subcol, 245 - subcol);
                            clr3 = Color.FromArgb(subcol2, subcol2, 145 + subcol2);
                            clr4 = Color.FromArgb(100 - subcol2, 100 - subcol2, 245 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Blue, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case AGaugeNeedleColor.Magenta:
                            clr1 = Color.FromArgb(subcol, 145 + subcol, 145 + subcol);
                            clr2 = Color.FromArgb(100 - subcol, 245 - subcol, 245 - subcol);
                            clr3 = Color.FromArgb(subcol2, 145 + subcol2, 145 + subcol2);
                            clr4 = Color.FromArgb(100 - subcol2, 245 - subcol2, 245 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Magenta, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case AGaugeNeedleColor.Violet:
                            clr1 = Color.FromArgb(145 + subcol, subcol, 145 + subcol);
                            clr2 = Color.FromArgb(245 - subcol, 100 - subcol, 245 - subcol);
                            clr3 = Color.FromArgb(145 + subcol2, subcol2, 145 + subcol2);
                            clr4 = Color.FromArgb(245 - subcol2, 100 - subcol2, 245 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Violet, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case AGaugeNeedleColor.Yellow:
                            clr1 = Color.FromArgb(145 + subcol, 145 + subcol, subcol);
                            clr2 = Color.FromArgb(245 - subcol, 245 - subcol, 100 - subcol);
                            clr3 = Color.FromArgb(145 + subcol2, 145 + subcol2, subcol2);
                            clr4 = Color.FromArgb(245 - subcol2, 245 - subcol2, 100 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Violet, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case AGaugeNeedleColor.White:
                            clr1 = Color.FromArgb(80 + subcol, 80 + subcol, 80 + subcol);
                            clr2 = Color.FromArgb(255 - subcol, 255 - subcol, 255 - subcol);
                            clr3 = Color.FromArgb(80 + subcol2, 80 + subcol2, 80 + subcol2);
                            clr4 = Color.FromArgb(255 - subcol2, 255 - subcol2, 255 - subcol2);
                            //e.Graphics.DrawEllipse(Pens.Violet, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                    }

                    if (Math.Floor((Single)((brushAngle + 225) % 360 / 180.0)) == 0)
                    {
                        Color clrTemp = clr1;
                        clr1 = clr2;
                        clr2 = clrTemp;
                    }

                    if (Math.Floor((Single)((brushAngle + 135) % 360 / 180.0)) == 0)
                    {
                        clr4 = clr3;
                    }

                    using (Brush brush1 = new SolidBrush(clr1))
                    using (Brush brush2 = new SolidBrush(clr2))
                    using (Brush brush3 = new SolidBrush(clr3))
                    using (Brush brush4 = new SolidBrush(clr4))
                    {
                        points[0].X = (Single)(Center.X + needleRadius * Math.Cos(needleAngle));
                        points[0].Y = (Single)(Center.Y + needleRadius * Math.Sin(needleAngle));
                        points[1].X = (Single)(Center.X - needleRadius / 20 * Math.Cos(needleAngle));
                        points[1].Y = (Single)(Center.Y - needleRadius / 20 * Math.Sin(needleAngle));
                        points[2].X = (Single)(Center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                        points[2].Y = (Single)(Center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                        e.Graphics.FillPolygon(brush1, points);

                        points[2].X = (Single)(Center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                        points[2].Y = (Single)(Center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                        e.Graphics.FillPolygon(brush2, points);

                        points[0].X = (Single)(Center.X - (needleRadius / 20 - 1) * Math.Cos(needleAngle));
                        points[0].Y = (Single)(Center.Y - (needleRadius / 20 - 1) * Math.Sin(needleAngle));
                        points[1].X = (Single)(Center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                        points[1].Y = (Single)(Center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                        points[2].X = (Single)(Center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                        points[2].Y = (Single)(Center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                        e.Graphics.FillPolygon(brush4, points);

                        points[0].X = (Single)(Center.X - needleRadius / 20 * Math.Cos(needleAngle));
                        points[0].Y = (Single)(Center.Y - needleRadius / 20 * Math.Sin(needleAngle));
                        points[1].X = (Single)(Center.X + needleRadius * Math.Cos(needleAngle));
                        points[1].Y = (Single)(Center.Y + needleRadius * Math.Sin(needleAngle));

                        using (var pnNeedle = new Pen(m_NeedleColor2))
                        {
                            e.Graphics.DrawLine(pnNeedle, Center.X, Center.Y, points[0].X, points[0].Y);
                            e.Graphics.DrawLine(pnNeedle, Center.X, Center.Y, points[1].X, points[1].Y);
                        }
                    }
                    break;
                case NeedleType.Simple:
                    Point startPoint = new Point((Int32)(Center.X - needleRadius / 8 * Math.Cos(needleAngle)),
                            (Int32)(Center.Y - needleRadius / 8 * Math.Sin(needleAngle)));
                    Point endPoint = new Point((Int32)(Center.X + needleRadius * Math.Cos(needleAngle)),
                                             (Int32)(Center.Y + needleRadius * Math.Sin(needleAngle)));

                    using (var brDisk = new SolidBrush(m_NeedleColor2))
                    {
                        e.Graphics.FillEllipse(brDisk, Center.X - needleWidth * 3, Center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                    }

                    using (var pnLine = new Pen(GetColor(m_NeedleColor1), needleWidth))
                    {
                        e.Graphics.DrawLine(pnLine, Center.X, Center.Y, endPoint.X, endPoint.Y);
                        e.Graphics.DrawLine(pnLine, Center.X, Center.Y, startPoint.X, startPoint.Y);
                    }
                    break;
            }
            #endregion

            PostRender(e.Graphics);

#if DEBUG
            if (drawCenter)
            {

                using (Pen drawPen = new Pen(Color.Red, 0.1f))
                {
                    e.Graphics.DrawLine(drawPen, Center.X, Center.Y - 10, Center.X, Center.Y + 10);
                    e.Graphics.DrawLine(drawPen, Center.X - 10, Center.Y, Center.X + 10, Center.Y);
                    // e.Graphics.Flush();
                }
            }
#endif

        }

        private Color GetColor(AGaugeNeedleColor clr)
        {
            switch (clr)
            {
                case AGaugeNeedleColor.Gray:
                    return Color.DarkGray;
                case AGaugeNeedleColor.Red:
                    return Color.Red;
                case AGaugeNeedleColor.Green:
                    return Color.Green;
                case AGaugeNeedleColor.Blue:
                    return Color.Blue;
                case AGaugeNeedleColor.Yellow:
                    return Color.Yellow;
                case AGaugeNeedleColor.Violet:
                    return Color.Violet;
                case AGaugeNeedleColor.Magenta:
                    return Color.Magenta;
                case AGaugeNeedleColor.White:
                    return Color.White;
                default:
                    Debug.Fail("Missing enumeration");
                    return Color.DarkGray;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Refresh();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            UpdateScalingFactors();
        }

        public void BeginInit()
        {
            m_bInitializing = true;
        }

        public void EndInit()
        {
            m_bInitializing = false;
            if (Value < MinValue || Value > MaxValue)
            {
                Value = Constrain(m_value);
            }
        }

        private float Constrain(float fCurrentValue)
        {
            if (fCurrentValue < MinValue)
            {
                return MinValue;
            }
            if (fCurrentValue > MaxValue)
            {
                return MaxValue;
            }
            return fCurrentValue;
        }
        #endregion

        #region Render components



        public virtual void BackgroundPreRender(Graphics graphics) { }

        public virtual void BackgroundPostRender(Graphics graphics) { }

        /// <summary>
        /// Renders the default gauge background directly to the graphics object.
        /// </summary>
        /// <param name="graphics"></param>
        /// <returns></returns>
        private void RenderDefaultBackground(Graphics ggr)
        {
            FindFontBounds();

            using (GraphicsPath gp = new GraphicsPath())
            {
                using (var brBackground = new SolidBrush(BackColor))
                {
                    ggr.FillRectangle(brBackground, ClientRectangle);
                }

                #region BackgroundImage
                if (BackgroundImage != null)
                {
                    switch (BackgroundImageLayout)
                    {
                        case ImageLayout.Center:
                            ggr.DrawImageUnscaled(BackgroundImage, Width / 2 - BackgroundImage.Width / 2, Height / 2 - BackgroundImage.Height / 2);
                            break;
                        case ImageLayout.None:
                            ggr.DrawImageUnscaled(BackgroundImage, 0, 0);
                            break;
                        case ImageLayout.Stretch:
                            ggr.DrawImage(BackgroundImage, 0, 0, Width, Height);
                            break;
                        case ImageLayout.Tile:
                            Int32 pixelOffsetX = 0;
                            Int32 pixelOffsetY = 0;
                            while (pixelOffsetX < Width)
                            {
                                pixelOffsetY = 0;
                                while (pixelOffsetY < Height)
                                {
                                    ggr.DrawImageUnscaled(BackgroundImage, pixelOffsetX, pixelOffsetY);
                                    pixelOffsetY += BackgroundImage.Height;
                                }
                                pixelOffsetX += BackgroundImage.Width;
                            }
                            break;
                        case ImageLayout.Zoom:
                            if (BackgroundImage.Width / Width < (Single)(BackgroundImage.Height / Height))
                            {
                                ggr.DrawImage(BackgroundImage, 0, 0, Height, Height);
                            }
                            else
                            {
                                ggr.DrawImage(BackgroundImage, 0, 0, Width, Width);
                            }
                            break;
                    }
                }
                #endregion

                ggr.SmoothingMode = SmoothingMode.HighQuality;
                ggr.PixelOffsetMode = PixelOffsetMode.HighQuality;


                #region _GaugeRanges
                Single rangeStartAngle;
                Single rangeSweepAngle;
                foreach (AGaugeRange ptrRange in _GaugeRanges)
                {
                    if (ptrRange.EndValue > ptrRange.StartValue)
                    {
                        rangeStartAngle = m_BaseArcStart + (ptrRange.StartValue - m_MinValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue);
                        rangeSweepAngle = (ptrRange.EndValue - ptrRange.StartValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue);
                        gp.Reset();
                        int outerRadius = (int)(ptrRange.OuterRadius * centerFactor);
                        gp.AddPie(new Rectangle(Center.X - outerRadius, Center.Y - outerRadius,
                            2 * outerRadius, 2 * outerRadius), rangeStartAngle, rangeSweepAngle);
                        gp.Reverse();
                        int innerRadius = (int)(ptrRange.InnerRadius * centerFactor);
                        gp.AddPie(new Rectangle(Center.X - innerRadius, Center.Y - innerRadius,
                            2 * innerRadius, 2 * innerRadius), rangeStartAngle, rangeSweepAngle);
                        gp.Reverse();
                        ggr.SetClip(gp);
                        using (var brRange = new SolidBrush(ptrRange.Color))
                        {
                            ggr.FillPie(brRange, new Rectangle(Center.X - outerRadius, Center.Y - outerRadius, 2 * outerRadius, 2 * outerRadius), rangeStartAngle, rangeSweepAngle);
                        }
                    }
                }
                #endregion

                ggr.SetClip(ClientRectangle);
                RenderDefaultArc(ggr);

                #region ScaleNumbers
                String valueText = "";
                SizeF boundingBox;
                Single countValue = 0;
                Int32 counter1 = 0;
                var Format = StringFormat.GenericTypographic;
                Format.Alignment = StringAlignment.Near;

                using (var pnMajorScaleLines = new Pen(m_ScaleLinesMajorColor, (int)(m_ScaleLinesMajorWidth * centerFactor)))
                using (var brScaleNumbers = new SolidBrush(m_ScaleNumbersColor))
                {
                    while (countValue <= (m_MaxValue - m_MinValue))
                    {
                        valueText = (m_MinValue + countValue).ToString(m_ScaleNumbersFormat);
                        ggr.ResetTransform();
                        boundingBox = ggr.MeasureString(valueText, Font, -1, StringFormat.GenericTypographic);

                        gp.Reset();
                        int scaleLinesMajorOuterRadius = (int)(m_ScaleLinesMajorOuterRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesMajorOuterRadius, Center.Y - scaleLinesMajorOuterRadius, 2 * scaleLinesMajorOuterRadius, 2 * scaleLinesMajorOuterRadius));
                        gp.Reverse();
                        int scaleLinesMajorInnerRadius = (int)(m_ScaleLinesMajorInnerRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesMajorInnerRadius, Center.Y - scaleLinesMajorInnerRadius, 2 * scaleLinesMajorInnerRadius, 2 * scaleLinesMajorInnerRadius));
                        gp.Reverse();
                        ggr.SetClip(gp);

                        ggr.DrawLine(pnMajorScaleLines,
                        Center.X,
                        Center.Y,
                        (Single)(Center.X + 2 * scaleLinesMajorOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0)),
                        (Single)(Center.Y + 2 * scaleLinesMajorOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0)));

                        gp.Reset();
                        int scaleLinesMinorOuterRadius = (int)(m_ScaleLinesMinorOuterRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesMinorOuterRadius, Center.Y - scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius));
                        gp.Reverse();
                        int scaleLinesMinorInnerRadius = (int)(m_ScaleLinesMinorInnerRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesMinorInnerRadius, Center.Y - scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius));
                        gp.Reverse();
                        ggr.SetClip(gp);

                        if (countValue < (m_MaxValue - m_MinValue))
                        {
                            using (var pnScaleLinesInter = new Pen(m_ScaleLinesInterColor, (int)(m_ScaleLinesInterWidth * centerFactor)))
                            using (var pnScaleLinesMinorColor = new Pen(m_ScaleLinesMinorColor, (int)(m_ScaleLinesMinorWidth * centerFactor)))
                            {
                                for (Int32 counter2 = 1; counter2 <= m_ScaleLinesMinorTicks; counter2++)
                                {
                                    if (((m_ScaleLinesMinorTicks % 2) == 1) && (m_ScaleLinesMinorTicks / 2) + 1 == counter2)
                                    {
                                        gp.Reset();
                                        int scaleLinesInterOuterRadius = (int)(m_ScaleLinesInterOuterRadius * centerFactor);
                                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesInterOuterRadius, Center.Y - scaleLinesInterOuterRadius, 2 * scaleLinesInterOuterRadius, 2 * scaleLinesInterOuterRadius));
                                        gp.Reverse();
                                        int scaleLinesInterInnerRadius = (int)(m_ScaleLinesInterInnerRadius * centerFactor);
                                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesInterInnerRadius, Center.Y - scaleLinesInterInnerRadius, 2 * scaleLinesInterInnerRadius, 2 * scaleLinesInterInnerRadius));
                                        gp.Reverse();
                                        ggr.SetClip(gp);

                                        ggr.DrawLine(pnScaleLinesInter,
                                        Center.X,
                                        Center.Y,
                                        (Single)(Center.X + 2 * scaleLinesInterOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)),
                                        (Single)(Center.Y + 2 * scaleLinesInterOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)));

                                        gp.Reset();
                                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesMinorOuterRadius, Center.Y - scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius));
                                        gp.Reverse();
                                        gp.AddEllipse(new Rectangle(Center.X - scaleLinesMinorInnerRadius, Center.Y - scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius));
                                        gp.Reverse();
                                        ggr.SetClip(gp);
                                    }
                                    else
                                    {
                                        ggr.DrawLine(pnScaleLinesMinorColor,
                                        Center.X,
                                        Center.Y,
                                        (Single)(Center.X + 2 * scaleLinesMinorOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)),
                                        (Single)(Center.Y + 2 * scaleLinesMinorOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / (((Single)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue)) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)));
                                    }
                                }
                            }
                        }

                        ggr.SetClip(ClientRectangle);

                        if (m_ScaleNumbersRotation != 0)
                        {
                            ggr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                            ggr.RotateTransform(90.0F + m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue));
                        }

                        ggr.TranslateTransform((Single)(Center.X + m_ScaleNumbersRadius * centerFactor * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0f)),
                                               (Single)(Center.Y + m_ScaleNumbersRadius * centerFactor * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0f)),
                                               System.Drawing.Drawing2D.MatrixOrder.Append);


                        if (counter1 >= m_ScaleNumbersStartScaleLine - 1)
                        {
                            var ptText = new PointF(-boundingBox.Width / 2f, -fontBoundY1 - (fontBoundY2 - fontBoundY1 + 1f) / 2f);
                            ggr.DrawString(valueText, Font, brScaleNumbers, ptText.X, ptText.Y, Format);
                        }

                        countValue += m_ScaleLinesMajorStepValue;
                        counter1++;
                    }
                }
                #endregion

                ggr.ResetTransform();
                ggr.SetClip(ClientRectangle);

                if (m_ScaleNumbersRotation != 0)
                {
                    ggr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                }

                #region _GaugeLabels
                Format = StringFormat.GenericTypographic;
                Format.Alignment = StringAlignment.Center;
                foreach (AGaugeLabel ptrGaugeLabel in _GaugeLabels)
                {
                    if (!String.IsNullOrEmpty(ptrGaugeLabel.Text))
                    {
                        using (var brGaugeLabel = new SolidBrush(ptrGaugeLabel.Color))
                        {
                            ggr.DrawString(ptrGaugeLabel.Text, ptrGaugeLabel.Font, brGaugeLabel,
                                           ptrGaugeLabel.Position.X * centerFactor + Center.X,
                                           ptrGaugeLabel.Position.Y * centerFactor + Center.Y, Format);
                        }
                    }
                }
                #endregion
            }
        }

        public virtual void RenderDefaultArc(Graphics graphics)
        {
            if (m_BaseArcRadius > 0)
            {
                int baseArcRadius = (int)(m_BaseArcRadius * centerFactor);
                using (var pnArc = new Pen(m_BaseArcColor, (int)(m_BaseArcWidth * centerFactor)))
                {
                    graphics.DrawArc(pnArc, new Rectangle(Center.X - baseArcRadius, Center.Y - baseArcRadius, 2 * baseArcRadius, 2 * baseArcRadius), m_BaseArcStart, m_BaseArcSweep);
                }
            }
        }

        public virtual void PostRender(Graphics graphics) { }

        #endregion
    }


    [Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { } //Namespace Documentation
}
