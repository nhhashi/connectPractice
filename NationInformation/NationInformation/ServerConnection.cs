using Renci.SshNet;
using System;
using System.Windows.Forms;

namespace NationInformation
{
    class ServerConnection
    {
        public bool tryConnect()
        {
            bool retval = false;

            try
            {
                // 接続先のホスト名またはIPアドレス
                var hostNameOrIpAddr = "localhost";

                // 接続先のポート番号
                var portNo = 50022;

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
                    return true;
                }
                else
                {
                    // 接続に失敗した（未接続状態である）
                    MessageBox.Show("[NG] SSH Connection failed!!");
                }

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
    }
}
