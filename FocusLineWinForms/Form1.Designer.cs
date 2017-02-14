namespace FocusLineWinForms {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.focusLineRadio = new System.Windows.Forms.RadioButton();
            this.focusRectRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(39, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(504, 332);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // focusLineRadio
            // 
            this.focusLineRadio.AutoSize = true;
            this.focusLineRadio.Checked = true;
            this.focusLineRadio.Location = new System.Drawing.Point(39, 28);
            this.focusLineRadio.Name = "focusLineRadio";
            this.focusLineRadio.Size = new System.Drawing.Size(79, 16);
            this.focusLineRadio.TabIndex = 1;
            this.focusLineRadio.TabStop = true;
            this.focusLineRadio.Text = "Focus Line";
            this.focusLineRadio.UseVisualStyleBackColor = true;
            this.focusLineRadio.CheckedChanged += new System.EventHandler(this.focusLineRadio_CheckedChanged);
            // 
            // focusRectRadio
            // 
            this.focusRectRadio.AutoSize = true;
            this.focusRectRadio.Location = new System.Drawing.Point(39, 50);
            this.focusRectRadio.Name = "focusRectRadio";
            this.focusRectRadio.Size = new System.Drawing.Size(82, 16);
            this.focusRectRadio.TabIndex = 2;
            this.focusRectRadio.Text = "Focus Rect";
            this.focusRectRadio.UseVisualStyleBackColor = true;
            this.focusRectRadio.CheckedChanged += new System.EventHandler(this.focusRectRadio_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 478);
            this.Controls.Add(this.focusRectRadio);
            this.Controls.Add(this.focusLineRadio);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton focusLineRadio;
        private System.Windows.Forms.RadioButton focusRectRadio;
    }
}

