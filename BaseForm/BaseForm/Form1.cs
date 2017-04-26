using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseForm
{
    public partial class Form1 : Form
    {

        // Member Variable

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームのロード時に呼び出される関数
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // ?
            this.KeyPreview = true;
            // タイトルにアプリ名を表示
            this.Text = Application.ProductName +" "+Application.ProductVersion;
            // ウィンドウサイズと位置の保存
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Size = Properties.Settings.Default.Size;
            this.Location = Properties.Settings.Default.Location;

            // ウィンドウが画面の外にある場合の処理
            if (this.Left < Screen.GetWorkingArea(this).Left) this.Left = 100;
            if (this.Left >= Screen.GetWorkingArea(this).Right) this.Left = 100;

            if (this.Top < Screen.GetWorkingArea(this).Top) this.Top = 100;
            if (this.Top >= Screen.GetWorkingArea(this).Bottom) this.Top = 100;
        }

        /// <summary>
        /// メニュー -> ファイル -> 終了(X)
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        /// <summary>
        /// フォームが閉じられたときに呼び出される関数
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 画面の位置とサイズを保存
            this.WindowState = FormWindowState.Normal;
            Properties.Settings.Default.Size = this.Size;
            Properties.Settings.Default.Location = this.Location;
            // 設定保存
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// ヴァージョン情報をクリック
        /// </summary>
        private void ToolStripMenuItemVersion_Click(object sender, EventArgs e)
        {
            string s = "";

            s = Application.ProductName + " " + Application.ProductVersion + Environment.NewLine;

            // コピーライトを表示
            var fileVrsionInfo = (System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath));
            string copyright = fileVrsionInfo.LegalCopyright.ToString();
            s += copyright + Environment.NewLine + Environment.NewLine;

            // 実行ファイルを表示
            s += "実行ファイル : " + Environment.NewLine +
                Application.ExecutablePath + Environment.NewLine;

            // 実行プロセスを表示
            string bit;
            if (Environment.Is64BitProcess) bit = "64";
            else bit = "32";
            s += "(" + bit + "ビット・プロセスとして稼動)" + Environment.NewLine + Environment.NewLine;

            // OSの情報を表示
            var myComputer = new Microsoft.VisualBasic.Devices.Computer();
            s += "オペレーティングシステム:" + Environment.NewLine;
            s += myComputer.Info.OSFullName + " " + myComputer.Info.OSVersion + " ";
            string osbit;
            if (Environment.Is64BitOperatingSystem) osbit = "64";
            else osbit = "32";
            s += osbit + "ビット";

            // ヴァージョン情報を表示
            MessageBox.Show(s, "バージョン情報");
        }

        /// <summary>
        ///  READMEを表示
        /// </summary>
        private void ToolStripMenuItemReadme_Click(object sender, EventArgs e)
        {
            // ファイルから読み込む
            string s = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            s = System.IO.Path.Combine(s, "README.txt");
            if (System.IO.File.Exists(s))
                System.Diagnostics.Process.Start(s);
            else
                MessageBox.Show(s + "が見つかりません", "エラー");
        }
        /// <summary>
        /// README.htmlを表示
        /// </summary>
        private void ToolStripMenuItemWEB_Click(object sender, EventArgs e)
        {
            // ファイルから読み込む
            string s = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            s = System.IO.Path.Combine(s, "README.html");
            if (System.IO.File.Exists(s))
                System.Diagnostics.Process.Start(s);
            else
                MessageBox.Show(s + "が見つかりません", "エラー");
        }
    }
}
