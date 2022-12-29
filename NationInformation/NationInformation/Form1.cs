using System;
using System.Windows.Forms;

namespace NationInformation
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// SSH接続クラスのインスタンス生成
        /// </summary>
        ServerConnection serverConnection = new ServerConnection();
        
        /// <summary>
        /// DB接続クラスのインスタンス生成
        /// </summary>
        SqlConnection sqlConnection = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ssh接続確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //ssh通信をする
            serverConnection.tryConnect();
        }

        /// <summary>
        /// DB接続確認
        /// </summary>
        /// <remarks>
        /// データの取得をする
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ///DB接続
            sqlConnection.getDataSQL(this);
        }

        /// <summary>
        /// DB接続確認
        /// </summary>
        /// <remarks>
        /// データの追加をする
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            InsertDataForm insertDataForm = new InsertDataForm();
            insertDataForm.Show();
        }

        /// <summary>
        /// DB接続確認
        /// </summary>
        /// <remarks>
        /// データの削除をする
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection.deleteDataSQL(this);
        }
    }
}
