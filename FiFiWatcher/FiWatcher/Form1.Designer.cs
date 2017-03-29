namespace FiWatcher
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_okFile = new System.Windows.Forms.Label();
            this.btn_okFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_watchStart = new System.Windows.Forms.Button();
            this.btn_watchStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_watcher = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label_okFile
            // 
            this.label_okFile.AutoSize = true;
            this.label_okFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_okFile.Location = new System.Drawing.Point(88, 57);
            this.label_okFile.Name = "label_okFile";
            this.label_okFile.Size = new System.Drawing.Size(117, 12);
            this.label_okFile.TabIndex = 0;
            this.label_okFile.Text = "Please Select OK File";
            // 
            // btn_okFile
            // 
            this.btn_okFile.Location = new System.Drawing.Point(27, 52);
            this.btn_okFile.Name = "btn_okFile";
            this.btn_okFile.Size = new System.Drawing.Size(55, 23);
            this.btn_okFile.TabIndex = 1;
            this.btn_okFile.Text = "browse";
            this.btn_okFile.UseVisualStyleBackColor = true;
            this.btn_okFile.Click += new System.EventHandler(this.btn_okFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "OKファイルを選択してください";
            // 
            // btn_watchStart
            // 
            this.btn_watchStart.Location = new System.Drawing.Point(45, 189);
            this.btn_watchStart.Name = "btn_watchStart";
            this.btn_watchStart.Size = new System.Drawing.Size(134, 58);
            this.btn_watchStart.TabIndex = 3;
            this.btn_watchStart.Text = "監視開始";
            this.btn_watchStart.UseVisualStyleBackColor = true;
            this.btn_watchStart.Click += new System.EventHandler(this.btn_watchStart_Click);
            // 
            // btn_watchStop
            // 
            this.btn_watchStop.Location = new System.Drawing.Point(211, 189);
            this.btn_watchStop.Name = "btn_watchStop";
            this.btn_watchStop.Size = new System.Drawing.Size(135, 58);
            this.btn_watchStop.TabIndex = 4;
            this.btn_watchStop.Text = "監視停止";
            this.btn_watchStop.UseVisualStyleBackColor = true;
            this.btn_watchStop.Click += new System.EventHandler(this.btn_watchStop_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(27, 267);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(373, 111);
            this.textBox1.TabIndex = 5;
            // 
            // label_watcher
            // 
            this.label_watcher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_watcher.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_watcher.Location = new System.Drawing.Point(27, 101);
            this.label_watcher.Name = "label_watcher";
            this.label_watcher.Size = new System.Drawing.Size(387, 54);
            this.label_watcher.TabIndex = 6;
            this.label_watcher.Text = "監視停止中";
            this.label_watcher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(426, 394);
            this.Controls.Add(this.label_watcher);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_watchStop);
            this.Controls.Add(this.btn_watchStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_okFile);
            this.Controls.Add(this.label_okFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FiFiFile Watcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_okFile;
        private System.Windows.Forms.Button btn_okFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_watchStart;
        private System.Windows.Forms.Button btn_watchStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_watcher;
    }
}

