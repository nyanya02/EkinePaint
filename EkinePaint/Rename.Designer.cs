namespace EkinePaint
{
    partial class Rename
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonFileName = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxFileName.Location = new System.Drawing.Point(12, 38);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(100, 19);
            this.textBoxFileName.TabIndex = 0;
            // 
            // buttonFileName
            // 
            this.buttonFileName.Location = new System.Drawing.Point(134, 36);
            this.buttonFileName.Name = "buttonFileName";
            this.buttonFileName.Size = new System.Drawing.Size(75, 23);
            this.buttonFileName.TabIndex = 1;
            this.buttonFileName.Text = "参照";
            this.buttonFileName.UseVisualStyleBackColor = true;
            this.buttonFileName.Click += new System.EventHandler(this.buttonFileName_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(134, 94);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "開始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(43, 105);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(23, 12);
            this.labelNumber.TabIndex = 3;
            this.labelNumber.Text = "0/0";
            // 
            // Rename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 157);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonFileName);
            this.Controls.Add(this.textBoxFileName);
            this.Name = "Rename";
            this.Text = "Rename";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rename_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonFileName;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelNumber;
    }
}