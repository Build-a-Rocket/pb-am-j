using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Documents;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<float> list;
        

        public Form1()
        {
            InitializeComponent();

            cartesianChart1.Series = new SeriesCollection
            {

            list = new List<float>();
            using (var fs = new StreamReader(new FileStream("file.csv", FileMode.Open, FileAccess.Read, FileShare.None, 8192, FileOptions.SequentialScan)))
            {
                var line = fs.ReadLine();
                var columns = line.Split(',');
                list.Add(Convert.ToSingle(columns[5]));
            }


            new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,10),      //First Point of First Line
                        new ObservablePoint(4,10),       //2nd POint
                        new ObservablePoint(5,10),     //------
                        new ObservablePoint(7,10),
                        new ObservablePoint(10,10)
                    },
                    PointGeometrySize = 15
                },
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,2),      //First Point of 2nd Line
                        new ObservablePoint(2,2),       //2nd POint
                        new ObservablePoint(3,2),     //------
                        new ObservablePoint(6,2),
                        new ObservablePoint(10,2)
                    },
                    PointGeometrySize = 15
                },
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,4),      //First Point of 3rd Line
                        new ObservablePoint(5,5),       //2nd POint
                        new ObservablePoint(7,7),     //------
                        new ObservablePoint(9,10),
                        new ObservablePoint(10,9)
                    },
                    PointGeometrySize = 15
                }
            };
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    internal class TextFieldParser
    {
        internal bool HasFieldsEnclosedInQuotes;
        private object path;

        public TextFieldParser(object path)
        {
            this.path = path;
        }

        public string[] CommentTokens { get; internal set; }
        public bool EndOfData { get; internal set; }

    internal string[] ReadFields()
    {
        throw new NotImplementedException();
    }

    internal void ReadLine()
        {
            throw new NotImplementedException();
        }

        internal void SetDelimiters(string[] strings)
        {
            throw new NotImplementedException();
        }
    }
}
