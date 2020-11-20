﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BPMCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public long PreviousTicks;

        public struct KeyPress
        {
            public DateTime Time { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            PreviousTicks = DateTime.Now.Ticks;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double differenceTicks = DateTime.Now.Ticks - PreviousTicks;
            double differenceMillis = differenceTicks / 10000d;
            double differenceSeconds = differenceMillis / 1000d;
            double bpm = 60.0d / differenceSeconds;
            double bpmRounded = Math.Round(bpm, 2);

            SetBPMText(bpmRounded.ToString());

            PreviousTicks = DateTime.Now.Ticks;
        }

        private void SetBPMText(string text)
        {
            BPM.Text = text;
        }
    }
}
