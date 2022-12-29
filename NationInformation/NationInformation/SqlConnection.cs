using MySql.Data.MySqlClient;
using System.Collections.Generic;
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
        public void getDataSQL(Form1 form1)
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

            ///sql文
            string sql = "select * from nationInfo";

            // コネクターを作成
            MySqlConnection mysql = new MySqlConnection(connectionParams);
            ///コマンドの設定
            MySqlCommand command = new MySqlCommand(sql, mysql);

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

            int rows = form1.dataGridView1.Rows.Count;

            /*
            if (rows != 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    form1.dataGridView1.Rows.RemoveAt(i);
                }
            }
            */

            // SELECT文の実行
            MySqlDataReader reader = command.ExecuteReader();

            // 1行ずつ読み取ってコンソールに表示
            while (reader.Read())
            {
                //取得したデータの追加
                form1.dataGridView1.Rows.Add(reader["id"],
                                             reader["nation"],
                                             reader["capital"],
                                             reader["population"]);
            }

            //接続を閉じる
            mysql.Close();
        }

        /// <summary>
        /// SQLの接続関数
        /// </summary>
        public void insertDataSQL(InsertDataForm insertDataForm, List<string> data)
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

            ///sql文
            string sql = "insert into nationInfo(id,nation,capital,population) " +
                         "value(@id,@nation,@capital,@population)";

            // コネクターを作成
            MySqlConnection mysql = new MySqlConnection(connectionParams);
            ///コマンドの設定
            MySqlCommand command = new MySqlCommand(sql, mysql);

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

            ///
            command.Parameters.AddWithValue("@id", int.Parse(data[0]));
            command.Parameters.AddWithValue("@nation", data[1]);
            command.Parameters.AddWithValue("@capital", data[2]);
            command.Parameters.AddWithValue("@population", double.Parse(data[3]));

            try
            {
                ///クエリの実行
                command.ExecuteNonQuery();

                System.Windows.MessageBox.Show("追加完了");
            }
            catch (MySqlException ex)
            {
                // 何らかの理由で接続に失敗した
                System.Windows.MessageBox.Show("追加失敗");
                //System.Windows.MessageBox.Show(ex.StackTrace);
                throw ex;
            }

            //接続を閉じる
            mysql.Close();
        }

        /// <summary>
        /// SQLの関数
        /// </summary>
        public void deleteDataSQL(Form1 form)
        {
            //delete sql作成
            //選択した行の値
            DataGridViewCell currentCell = form.dataGridView1.CurrentCell;
            string sql = "delete from nationInfo where id = " + (currentCell.Value).ToString();

            ///noの列のみの選択を許可する
            if (currentCell.ColumnIndex != 0)
            {
                MessageBox.Show("noの列を選択してください");

                return;
            }

            // 接続に必要なパラメータ文字列を生成する
            var connectionParams = string.Format(
                "host={0}; userid={1}; password={2}; database={3}; charset={4}",
                "192.168.3.12",
                "naokidb",
                "Arh406@sql",
                "dbtest",
                "utf8"
            );

            // コネクターを作成
            MySqlConnection mysql = new MySqlConnection(connectionParams);
            ///コマンドの設定
            MySqlCommand command = new MySqlCommand(sql, mysql);

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

            try
            {
                //sql実行
                command.ExecuteNonQuery();

                MessageBox.Show("削除成功しました");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("削除失敗しました");

                // 何らかの理由で接続に失敗した
                //System.Windows.MessageBox.Show(ex.StackTrace);
                throw ex;
            }

            //接続を閉じる
            mysql.Close();
        }
    }
}
