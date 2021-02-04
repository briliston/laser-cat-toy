﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace laser_cat_toy
{
    public partial class Form1 : Form
    {
        public Stopwatch stopwatch { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopwatch = Stopwatch.StartNew();
            port.Open();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            WriteToPort(new Point(e.X, e.Y));
        }
        
        public void WriteToPort(Point coordinates)
        {
            if (stopwatch.ElapsedMilliseconds > 15)
            {
                stopwatch = Stopwatch.StartNew();
                port.Write(String.Format("X{0}Y{1}", (coordinates.X / (Size.Width / 180)), ((180 - coordinates.Y) / (Size.Height / 180))));
            }
        }
    }
}
