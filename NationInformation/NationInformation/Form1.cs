﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NationInformation
{
    public partial class Form1 : Form
    {
        ServerConnection serverConnection = new ServerConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ssh通信をする
            serverConnection.tryConnect();
        }
    }
}
