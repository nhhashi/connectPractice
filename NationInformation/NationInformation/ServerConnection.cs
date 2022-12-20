using Renci.SshNet;
using System;
using System.Windows.Forms;

namespace NationInformation
{
    class ServerConnection
    {
        SqlConnection sqlConnection = new SqlConnection();
        SshCommand cmd;
        /// <summary>
        /// 通信確立
        /// </summary>
        /// <returns></returns>
        public bool tryConnect()
        {
            bool retval = false;

            try
            {
                // 接続先のホスト名またはIPアドレス
                var hostNameOrIpAddr = "192.168.3.11";

                // 接続先のポート番号
                var portNo = 22;

                // ログインユーザー名
                var userName = "naoki";

                // ログインパスワード
                var passWord = "arh406";

                // コネクション情報
                ConnectionInfo info = new ConnectionInfo(hostNameOrIpAddr, portNo, userName,
                    new AuthenticationMethod[] {
                        new PasswordAuthenticationMethod(userName, passWord)
                        /* PrivateKeyAuthenticationMethod("キーの場所")を指定することでssh-key認証にも対応しています */
                    }
                );

                // クライアント作成
                SshClient ssh = new SshClient(info);

                // 接続開始
                ssh.Connect();

                if (ssh.IsConnected)
                {
                    // 接続に成功した（接続状態である）
                    MessageBox.Show("[OK] SSH Connection succeeded!!");   
                }
                else
                {
                    // 接続に失敗した（未接続状態である）
                    MessageBox.Show("[NG] SSH Connection failed!!");
                    return true;
                }

                executeCmd(ssh, "ls -al");
                executeCmd(ssh, "pwd");
                
                /*
                                // 送信したいコマンドを変数に入れる
                                var commandString = "mysql -u naoki -p";

                                // コマンドを作成する
                                SshCommand cmd = ssh.CreateCommand(commandString);

                                // コマンドを実行する
                                cmd.Execute();

                                // 送信したいコマンドを変数に入れる
                                commandString = "Arh406@sql";

                                // コマンドを実行する
                                cmd.Execute();


                                // 結果を変数に入れる
                                var stdOut = cmd.Result;
                                var stdErr = cmd.Error;

                                // 標準出力を表示する
                                if (stdOut != string.Empty)
                                {
                                    MessageBox.Show("日付：" + stdOut);
                                }

                                // エラー出力を表示する
                                if (cmd.ExitStatus != 0 && stdErr != string.Empty)
                                {
                                    MessageBox.Show("日付：" + stdErr);
                                }
                */

                // 接続終了
                ssh.Disconnect();


            }
            catch (Exception ex)
            {
                // エラー発生時
                MessageBox.Show(ex.Message);
                throw ex;
            }

            return retval;
        }

        private void executeCmd(SshClient ssh, string command)
        {
            // コマンドを作成する
            cmd = ssh.CreateCommand(command);

            // コマンドを実行する
            cmd.Execute();


            // 結果を変数に入れる
            var stdOut = cmd.Result;
            var stdErr = cmd.Error;

            // 標準出力を表示する
            if (stdOut != string.Empty)
            {
                MessageBox.Show("日付：" + stdOut);
            }

            // エラー出力を表示する
            if (cmd.ExitStatus != 0 && stdErr != string.Empty)
            {
                MessageBox.Show("日付：" + stdErr);
            }

        }
    }
}
