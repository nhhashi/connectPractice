using MySql.Data.MySqlClient;

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
        public void connectSQL()
        {
            
            // 接続に必要なパラメータ文字列を生成する
            var connectionParams = string.Format(
                "host={0}; userid={1}; password={2}; database={3}; charset={4}",
                "192.168.3.11",
                "naoki",
                "Arh406@sql",
                "mysql",
                "utf8"
            );
            
            //string connectionString = "Server = 192.168.3.11; Database = dbtest; Uid = naoki; Pwd = Arh406@sql;";

            // コネクターを作成
            MySqlConnection mysql = new MySqlConnection(connectionParams);


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

        }
    }
}
