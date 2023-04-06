using System.Data;

namespace FormsLab
{
    public enum EChartType { Pie, Bar, LogBar };
    public partial class Charts : UserControl
    {
        private EChartType _chartType = EChartType.Pie;
        private readonly Color[] _colors;
        public EChartType ChartType
        {
            get { return _chartType; }
            set { _chartType = value; }
        }
        public Charts()
        {
            _colors = new Color[10];

            float value = 0.8f;
            for (int i = 0; i < _colors.Length; i++)
            {
                float saturation = (5 + (float)i / 2) / _colors.Length;
                float hue = 360 * saturation;
                _colors[i] = SharedFunctions.GetColor(hue, saturation, value);
            }
            InitializeComponent();
        }
        private void DrawPie(Graphics g, Rectangle rect, (string ext, long val)[] data)
        {
            long sum = data.Sum(x => x.val);
            float startAngle = 0.0f;

            for (int i = 0; i < data.Length; i++)
            {
                float sweepAngle = 360 * (float)data[i].val / sum;
                using (SolidBrush brush = new(_colors[i]))
                {
                    g.FillPie(brush, rect, startAngle, sweepAngle);
                }
                using (Pen pen = new(Color.Black))
                {
                    g.DrawPie(pen, rect, startAngle, sweepAngle);
                }
                startAngle += sweepAngle;
            }
        }
        private void DrawBar(Graphics g, Rectangle rect, (string ext, long val)[] data, bool isLog, bool useFileSizeToString, bool addB)
        {
            //tło
            int margine;
            if (useFileSizeToString || addB) margine = 60;
            else margine = 40;

            Rectangle fillRect = new(rect.Left + margine, rect.Top, rect.Width - margine, rect.Height - (Font.Height + 5));
            g.FillRectangle(Brushes.LightGray, fillRect);

            //podziałka
            double[] values = data.Select(x => (double)x.val).ToArray();
            if (isLog) values = values.Select(x => Math.Log10(x)).ToArray();

            double numOfLines = 10;
            double max = values.Max();
            if (isLog) numOfLines = max + 1;

            float lineY = fillRect.Bottom - 1;
            float step = fillRect.Height / (float)numOfLines;

            StringFormat format1 = new() { Alignment = StringAlignment.Far };
            for (int i = 0; i < numOfLines; i++)
            {
                g.DrawLine(new Pen(Color.DarkGray, 2), fillRect.Left, lineY, fillRect.Right, lineY);
                Rectangle textRect = new(rect.Left - 2, (int)lineY - Font.Height + 2, margine, Font.Height);

                if (isLog)
                {
                    long num = i == 0 ? 0 : (long)Math.Pow(10, i);
                    if (i <= 3)
                    {
                        if (addB) g.DrawString(num.ToString() + "B", Font, Brushes.Black, textRect, format1);
                        else g.DrawString(num.ToString(), Font, Brushes.Black, textRect, format1);
                    }
                    else
                    {
                        if (addB) g.DrawString($"10^{i}" + "B", Font, Brushes.Black, textRect, format1);
                        else g.DrawString($"10^{i}", Font, Brushes.Black, textRect, format1);
                    }
                }
                else
                {
                    if (useFileSizeToString) g.DrawString(SharedFunctions.FileSizeToString((long)(max * i / numOfLines)), Font, Brushes.Black, textRect, format1);
                    else g.DrawString(((int)(max * i / numOfLines)).ToString(), Font, Brushes.Black, textRect, format1);
                }
                lineY -= step;
            }

            //słupki
            double scale = fillRect.Height / (max + 5);
            if (isLog) scale = fillRect.Height / (max + 1);

            int barWidth = (int)(fillRect.Width / (float)(2 * data.Length + 1));

            StringFormat format2 = new() { Alignment = StringAlignment.Center };
            for (int i = 0; i < data.Length; i++)
            {
                int barHeight = (int)(values[i] * scale);
                int barX = fillRect.Left + barWidth + 2 * i * barWidth;
                int barY = fillRect.Bottom - barHeight;

                Rectangle barRect = new(barX, barY, barWidth, barHeight);
                using (SolidBrush brush = new(_colors[i]))
                {
                    g.FillRectangle(brush, barRect);
                }
                g.DrawRectangle(new Pen(Color.Black, 1), barRect);

                string label = data[i].ext;
                int labelWidth = (int)g.MeasureString(label, Font).Width;
                int labelHeight = Font.Height + 5;
                int labelX = barX + barWidth / 2 - labelWidth / 2;
                int labelY = fillRect.Bottom + 5;

                Rectangle labelRect = new(labelX, labelY, labelWidth + 1, labelHeight);
                g.DrawString(label, Font, Brushes.Black, labelRect, format2);
            }
        }
        private void DrawLegend(Graphics g, Rectangle rect, (string ext, long val)[] data, bool useFileSizeToString)
        {
            int margine = 5;
            int legendWidth = rect.Width / 3;
            int legendHeight = rect.Height / data.Length;
            int legendX = rect.X;
            int legendY = rect.Y;

            for (int i = 0; i < data.Length; i++)
            {
                Rectangle boxRect = new(legendX, legendY + i * legendHeight, legendWidth, legendHeight - margine);
                using (SolidBrush brush = new(_colors[i]))
                {
                    g.FillRectangle(brush, boxRect);
                }
                g.DrawRectangle(new Pen(Color.Black, 1), boxRect);

                Rectangle textRect = new(legendX + legendWidth + margine, legendY + i * legendHeight + 2 * margine, 2 * legendWidth - margine, legendHeight - margine);
                using (SolidBrush brush = new(Color.Black))
                {
                    if (useFileSizeToString) g.DrawString($"{data[i].ext} - {SharedFunctions.FileSizeToString(data[i].val)}", Font, brush, textRect);
                    else g.DrawString($"{data[i].ext} - {data[i].val}", Font, brush, textRect);
                }
            }
        }
        public void DrawCharts(Graphics g, Rectangle rect, (string, long)[] counts, (string, long)[] sizes)
        {
            int margine = 10;
            int left = rect.Left;
            int top = rect.Top + margine;
            int height = rect.Height - 2 * margine;
            if (height <= margine) return;

            if (_chartType == EChartType.Pie)
            {
                int legendWidth = rect.Width / 6 - margine;
                int chartWidth = rect.Width / 2 - legendWidth - margine;

                if (chartWidth <= margine || legendWidth <= margine) return;

                Rectangle rectchart1 = new(left, top, chartWidth, height);
                Rectangle rectlegend1 = new(left + chartWidth + margine, top, legendWidth, height);
                Rectangle rectchart2 = new(left + chartWidth + legendWidth, top, chartWidth, height);
                Rectangle rectlegend2 = new(left + 2 * chartWidth + margine + legendWidth, top, legendWidth, height);

                DrawPie(g, rectchart1, counts);
                DrawLegend(g, rectlegend1, counts, false);
                DrawPie(g, rectchart2, sizes);
                DrawLegend(g, rectlegend2, sizes, true);
            }
            else
            {
                int smallmargine = 5;
                int chartWidth = rect.Width / 2;

                if (chartWidth <= smallmargine) return;

                Rectangle rectchart1 = new(left, top, chartWidth - smallmargine, height);
                Rectangle rectchart2 = new(left + chartWidth + smallmargine, top, chartWidth, height);

                if (_chartType == EChartType.Bar)
                {
                    DrawBar(g, rectchart1, counts, false, false, false);
                    DrawBar(g, rectchart2, sizes, false, true, false);
                }
                else
                {
                    DrawBar(g, rectchart1, counts, true, false, false);
                    DrawBar(g, rectchart2, sizes, true, false, true);
                }
            }
        }
    }
    public static partial class SharedFunctions
    {
        public static void SortAndGroupData(Dictionary<string, (int count, long size)> filemap, out (string, long)[] _counts, out (string, long)[] _sizes)
        {
            List<(string ext, long count)> counts = new();
            foreach (var c in filemap) counts.Add((c.Key, c.Value.count));
            counts.Sort((x, y) => y.count.CompareTo(x.count));

            _counts = new (string, long)[10];
            for (int i = 0; i < _counts.Length; i++) _counts[i] = ("", 0);
            for (int i = 0, j = 0; i < counts.Count; i++)
            {
                if (i < 9) _counts[j++] = counts[i];
                else _counts[j].Item2 += counts[i].count;
            }
            _counts[^1].Item1 = "others";

            List<(string ext, long size)> sizes = new();
            foreach (var s in filemap) sizes.Add((s.Key, s.Value.size));
            sizes.Sort((x, y) => y.size.CompareTo(x.size));

            _sizes = new (string, long)[10];
            for (int i = 0; i < _sizes.Length; i++) _sizes[i] = ("", 0);
            for (int i = 0, j = 0; i < sizes.Count; i++)
            {
                if (i < 9) _sizes[j++] = sizes[i];
                else _sizes[j].Item2 += sizes[i].size;
            }
            _sizes[^1].Item1 = "others";
        }
        public static Color GetColor(float hue, float saturation, float value)
        {
            double r, g, b;

            if (saturation <= 0)
            {
                r = value; g = value; b = value;
            }
            else
            {
                int i = (int)(Math.Floor(hue / 60)) % 6;
                double f = hue / 60 - Math.Floor(hue / 60);
                double p = value * (1 - saturation);
                double q = value * (1 - saturation * f);
                double t = value * (1 - saturation * (1 - f));

                switch (i)
                {
                    case 0:
                        r = value; g = t; b = p;
                        break;
                    case 1:
                        r = q; g = value; b = p;
                        break;
                    case 2:
                        r = p; g = value; b = t;
                        break;
                    case 3:
                        r = p; g = q; b = value;
                        break;
                    case 4:
                        r = t; g = p; b = value;
                        break;
                    default:
                        r = value; g = p; b = q;
                        break;
                }
            }
            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }
    }
}
