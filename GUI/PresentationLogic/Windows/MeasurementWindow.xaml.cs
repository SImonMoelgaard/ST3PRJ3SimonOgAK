﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BuissnessLogic;
using DTO;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Colors = Windows.UI.Colors;

namespace PresentationLogic.Windows
{
    /// <summary>
    /// Interaction logic for MeasurementWindow.xaml
    /// </summary>
    public partial class MeasurementWindow : Window, INotifyPropertyChanged
    {
        #region Constant Changes Graph
        private double _axisMax;
        private double _axisMin;
        public ChartValues<MeasurementModel> ChartValues { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }
        public bool IsReading { get; set; }
        #endregion

        //Attributess
        //private LineSeries measurement;

        private MainWindow mainWindow;
        private Controller controller;
        private DataWindow dataWindow;
        private List<DTO_Measurement> measurementData;
        //private LineSeries bPressure;
        //private ChartValues<double> chartBPressure;
        public string[] xAxis { get; set; }


        public SeriesCollection Measurement { get; set; }


        public MeasurementWindow(Controller cr, MainWindow mw, DataWindow dw)
        {
            InitializeComponent();
            controller = cr;
            mainWindow = mw;
            dataWindow = dw;
            MuteAlarm_B.Visibility = Visibility.Hidden;

            #region Constant Changes Graph
            var mapper = Mappers.Xy<MeasurementModel>()
                .X(model => model.Time.Ticks)
                .Y(model => model.RawData);

            Charting.For<MeasurementModel>(mapper);

            ChartValues = new ChartValues<MeasurementModel>();

            DateTimeFormatter = value => new DateTime((long) value).ToString("mm:ss");

            AxisStep = TimeSpan.FromSeconds(1).Ticks;

            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            IsReading = false;

            DataContext = this;
            #endregion
        }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        private void Start_B_Click(object sender, RoutedEventArgs e)
        {
            Stop_B.IsEnabled = false;
            IsReading = !IsReading;
            if (IsReading) Task.Factory.StartNew(Read);

            //Start_B.IsEnabled = true;
            
            //MuteAlarm_B.Visibility = Visibility.Visible;
            //MuteAlarm_B.IsEnabled = true;

            #region This works and cannot be removed
            //bPressure = new LineSeries() {PointGeometry = null};
            //chartBPressure = new ChartValues<double>();

            ////Read from file
            //measurementData = controller.ReadFromFile();

            //xAxis = new string[measurementData.Count];

            //for (int i = 0; i < measurementData.Count; i++)
            //{
            //    chartBPressure.Add(measurementData[i].mmHg);
            //    xAxis[i] = measurementData[i].Tid.ToString("s.fff");
            //}

            //bPressure.Values = chartBPressure;

            //MeasurementChart.Series = new SeriesCollection() {bPressure};


            //DataContext = this;
            #endregion
        }


        private void Read()
        {

            #region Constant Changes Graph

            var measurement = controller.ReadFromFile();

            while (IsReading)
            {
                foreach (var data in measurement)
                {
                    Thread.Sleep(20);
                    ChartValues.Add(new MeasurementModel
                    {
                        Time = data.Tid,
                        RawData = data.mmHg
                    });

                    SetAxisLimits(data.Tid);

                    if (ChartValues.Count>400)
                    {
                        ChartValues.RemoveAt(0);
                    }

                }
            }
            #endregion
        }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(8).Ticks; // and 8 seconds behind
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        private void Stop_B_Click(object sender, RoutedEventArgs e)
        {
            Start_B.IsEnabled = false;
        }

        private void MuteAlarm_B_Click(object sender, RoutedEventArgs e)
        {
            alarm_L.Visibility = Visibility.Hidden;
        
        }

        private void ExitToMainWindow_B_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }

        public void ShowGraph()
        {

        }

        public void ShowData()
        {

        }

        public void Alarm(string cpr)
        {
            int alarm = 1;
            if (alarm==1)
            {
                while (true)
                {
                    alarm_L.Text = "Alarm!";
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
