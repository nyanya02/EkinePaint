namespace EkinePaint
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
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.writeArea = new System.Windows.Forms.PictureBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.picTransparent = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.writeArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransparent)).BeginInit();
            this.SuspendLayout();
            // 
            // writeArea
            // 
            this.writeArea.BackColor = System.Drawing.Color.Transparent;
            this.writeArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.writeArea.Location = new System.Drawing.Point(0, 0);
            this.writeArea.Name = "writeArea";
            this.writeArea.Size = new System.Drawing.Size(800, 450);
            this.writeArea.TabIndex = 0;
            this.writeArea.TabStop = false;
            this.writeArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseDown);
            this.writeArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseMove);
            this.writeArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseUp);
            // 
            // imageBox
            // 
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.Location = new System.Drawing.Point(0, 0);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(800, 450);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // picTransparent
            // 
            this.picTransparent.BackColor = System.Drawing.Color.Transparent;
            this.picTransparent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTransparent.Location = new System.Drawing.Point(0, 0);
            this.picTransparent.Name = "picTransparent";
            this.picTransparent.Size = new System.Drawing.Size(800, 450);
            this.picTransparent.TabIndex = 3;
            this.picTransparent.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picTransparent);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.writeArea);
            this.Name = "Form1";
            this.Text = "EkinePaint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.writeArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransparent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox writeArea;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.PictureBox picTransparent;
        private System.Windows.Forms.Label label1;
    }
}

