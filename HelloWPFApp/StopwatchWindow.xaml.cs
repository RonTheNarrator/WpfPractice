using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for Stopwatch.xaml
    /// </summary>
    public partial class StopwatchWindow : Window
    {
        Stopwatch stopwatch = new();
        DispatcherTimer timer = new();

        public StopwatchWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_tick;
        }

        private void timer_tick(object? sender, EventArgs e)
        {
            UpdateTimeDisplay(stopwatch.Elapsed);
        }

        private void UpdateTimeDisplay(TimeSpan elapsed)
        {
            TimeDisplay.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                            elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                timer.Stop();
                UpdateTimeDisplay(stopwatch.Elapsed);
                button.Content = "Start";
            }
            else
            {
                stopwatch.Start();
                timer.Start();
                button.Content = "Stop";
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            UpdateTimeDisplay(stopwatch.Elapsed);
        }
    }
}
