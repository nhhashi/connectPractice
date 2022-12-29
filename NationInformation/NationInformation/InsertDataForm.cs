using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NationInformation
{
    public partial class InsertDataForm : Form
    {
        /// <summary>
        /// DB接続クラスのインスタンス生成
        /// </summary>
        SqlConnection sqlConnection = new SqlConnection();

        /// <summary>
        /// テキストボックスのリスト
        /// </summary>
        List<string> list = new List<string>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InsertDataForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// データ追加関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //テキストボックスの値の取得をする
            list.Add(textBox1.Text);
            list.Add(textBox2.Text);
            list.Add(textBox3.Text);
            list.Add(textBox4.Text);

            //データ挿入実行
            sqlConnection.insertDataSQL(this,list);

            //フォームを閉じる
            this.Close();
        }
    }
}
