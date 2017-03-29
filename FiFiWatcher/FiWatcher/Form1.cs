//
// フォルダ監視
// http://dobon.net/vb/dotnet/file/filesystemwatcher.html
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiWatcher
{
    public partial class Form1 : Form
    {
        // Watcher generate
        private System.IO.FileSystemWatcher watcher = null;

        public Form1()
        {
            InitializeComponent();

            // 監視ラベル
            Change_State_isWatch(false);

            // ボタン初期状態(最初だけ)
            btn_watchStart.Enabled = false;

            // 実行フォルダを初期地
            openFileDialog1.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

        }

        private void Change_State_isWatch(bool watching)
        {
            if (watching)
            {
                // 監視中
                btn_okFile.Enabled = false;
                btn_watchStart.Enabled = false;
                btn_watchStop.Enabled = true;
                label_watcher.Text = "監視中";
                label_watcher.ForeColor = Color.Red;
            }
            else
            {
                // 非監視
                btn_okFile.Enabled = true;
                btn_watchStart.Enabled = true;
                btn_watchStop.Enabled = false;
                label_watcher.Text = "監視停止中";
                label_watcher.ForeColor = Color.Gray;
            }
        }

        // 監視ファイルの選択ボタン
        private void btn_okFile_Click(object sender, EventArgs e)
        {
            // ダイアログオープン
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label_okFile.Text = openFileDialog1.FileName;
                btn_watchStart.Enabled = true;
            }
        }

        // 監視開始ボタン
        private void btn_watchStart_Click(object sender, EventArgs e)
        {
            // ボタンの状態変更
            Change_State_isWatch(true);

            if (watcher != null) return; // 監視中は動作しない

            watcher = new System.IO.FileSystemWatcher();

            // 監視ディレクトリ
            watcher.Path = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);

            watcher.NotifyFilter = 
                (System.IO.NotifyFilters.LastAccess
                | System.IO.NotifyFilters.LastWrite
                | System.IO.NotifyFilters.FileName
                | System.IO.NotifyFilters.DirectoryName);

            // 監視ファイル
            String watch_file = System.IO.Path.GetFileName(openFileDialog1.FileName);
            watcher.Filter = watch_file; //全てのファイルを監視

            // UIのスレッドにマーシャリングをする
            watcher.SynchronizingObject = this;

            //イベントハンドラの追加
            watcher.Changed += new System.IO.FileSystemEventHandler(watcher_Changed);
            watcher.Created += new System.IO.FileSystemEventHandler(watcher_Changed);
            watcher.Deleted += new System.IO.FileSystemEventHandler(watcher_Changed);

            //監視を開始する
            watcher.EnableRaisingEvents = true;
            debug_log(watch_file + @"の監視を開始しました");

        }

        // 監視終了ボタン
        private void btn_watchStop_Click(object sender, EventArgs e)
        {
            // ボタンの状態変更
            Change_State_isWatch(false);

            // 監視終了
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            watcher = null;

            // デバッグ
            debug_log("監視を終了しました");
        }

        //イベントハンドラ
        private void watcher_Changed(System.Object source,
            System.IO.FileSystemEventArgs e)
        {

            String watch_file = System.IO.Path.GetFileName(openFileDialog1.FileName);

            switch (e.ChangeType)
            {
                case System.IO.WatcherChangeTypes.Changed:
                    debug_log("ファイル 「" + watch_file + "」が変更されました。");
                    MessageBox.Show("ファイル 「" + watch_file + "」が変更されました。");
                    break;
                case System.IO.WatcherChangeTypes.Created:
                    debug_log("ファイル 「" + watch_file + "」が作成されました。");
                    MessageBox.Show("ファイル 「" + watch_file + "」が作成されました。");
                    break;
                case System.IO.WatcherChangeTypes.Deleted:
                    debug_log("ファイル 「" + watch_file + "」が削除されました。");
                    MessageBox.Show("ファイル 「" + watch_file + "」が削除されました。");
                    break;
            }
        }

        // debug_log
        private void debug_log(String msg)
        {
            textBox1.AppendText(msg+"\n");

        }

    }
}
