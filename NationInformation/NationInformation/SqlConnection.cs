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
    class SqlConnection
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SqlConnection()
        {
        }

        /// <summary>
        /// SQLの接続関数
        /// </summary>
        public void connectSQL(Form1 form)
        {
            
            // 接続に必要なパラメータ文字列を生成する
            var connectionParams = string.Format(
                "host={0}; userid={1}; password={2}; database={3}; charset={4}",
                "192.168.3.12",
                "naokidb",
                "Arh406@sql",
                "dbtest",
                "utf8"
            );

            //form.label1.Text = string.Empty;

            ///sql文
            string sql = "select * from nationInfo";

            // コネクターを作成
            MySqlConnection mysql = new MySqlConnection(connectionParams);
            ///コマンドの設定
            var command = new MySqlCommand(sql, mysql);

            // 接続開始
            mysql.Open();

            try
            {
                System.Windows.MessageBox.Show("接続完了");

            }
            catch (MySqlException ex)
            {
                // 何らかの理由で接続に失敗した
                System.Windows.MessageBox.Show(ex.StackTrace);
                throw ex;
            }

            // SELECT文の実行
            var reader = command.ExecuteReader();

            // 1行ずつ読み取ってコンソールに表示
            while (reader.Read())
            {
                //form.label1.Text += ($"{reader["id"]} 国名:{reader["nation"]}　首都:{reader["capital"]} 人口: { reader["population"]}") + "\n";

                form.dataGridView1.Rows.Add(reader["id"], reader["nation"], reader["capital"], reader["population"]);
    }

            mysql.Close();
        }
    }
}
