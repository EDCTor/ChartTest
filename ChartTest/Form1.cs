using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraCharts;

namespace ChartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable CreateChartData(FileObject[] items)
        {
            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add two columns to the table.
            table.Columns.Add("Argument", typeof(String));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table.
            if ((items != null) && (items.Length > 0))
            {
                foreach(FileObject item in items)
                {
                    DataRow row = table.NewRow();
                    row["Argument"] = item.fileName;
                    row["Value"] = item.lineCount;
                    table.Rows.Add(row);
                }
            }
            
            return table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a chart.
            //ChartControl chart = new ChartControl();

            // Create an empty Bar series and add it to the chart.
            Series series = new Series("Series1", ViewType.Bar);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.LegendTextPattern = "{A}: {V}";

            this.chartControl1.Series.Add(series);

            // Generate a data table and bind the series to it.
            series.DataSource = CreateChartData(GetTestData());
             
            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Auto;
            series.ArgumentDataMember = "Argument";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)this.chartControl1.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            
            // Dock the chart into its parent and add it to the current form.
            this.chartControl1.Dock = DockStyle.Fill;
            //this.Controls.Add(chart);
        }

        private class FileObject
        {
            public string fileName;
            public int lineCount;
            public DateTime lastModified;

            public FileObject(string fileName, int lineCount, DateTime lastModified)
            {
                this.fileName = fileName;
                this.lineCount = lineCount;
                this.lastModified = lastModified;
            }
        }

        private FileObject[] GetTestData()
        {
            List<FileObject> items = new List<FileObject>();

            items.Add(new FileObject("PT_FS", 1255, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_ST", 744, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_RS", 977, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_CS", 353, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_TM", 115, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_DA", 85, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_CO", 44, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_SE", 66, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_A3", 501, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_B1", 205, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_B4", 188, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_C1", 601, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("PT_D3", 34, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("VW_TW", 92, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("VW_SC", 110, new DateTime(2016, 12, 12, 9, 33, 22)));
            items.Add(new FileObject("VW_VI", 6, new DateTime(2016, 12, 12, 9, 33, 22)));
            
            return items.ToArray();
        }
    }
}
