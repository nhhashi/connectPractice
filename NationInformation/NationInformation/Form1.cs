using MySql.Data.MySqlClient;
using System;
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
        SqlConnection sqlConnection = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ssh通信をする
            serverConnection.tryConnect();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            sqlConnection.connectSQL();
        }
    }
}
