namespace SettlementFileProcess
{
    partial class SettlementFileDownloadProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettlementFileDownloadProcess));
            this.btnstart = new System.Windows.Forms.Button();
            this.btnend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttracelog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(382, 12);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(75, 23);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnend
            // 
            this.btnend.Location = new System.Drawing.Point(382, 41);
            this.btnend.Name = "btnend";
            this.btnend.Size = new System.Drawing.Size(75, 23);
            this.btnend.TabIndex = 1;
            this.btnend.Text = "End";
            this.btnend.UseVisualStyleBackColor = true;
            this.btnend.Click += new System.EventHandler(this.btnend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttracelog);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 204);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download Status";
            // 
            // txttracelog
            // 
            this.txttracelog.Location = new System.Drawing.Point(6, 19);
            this.txttracelog.Multiline = true;
            this.txttracelog.Name = "txttracelog";
            this.txttracelog.Size = new System.Drawing.Size(352, 179);
            this.txttracelog.TabIndex = 0;
            // 
            // SettlementFileDownloadProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 228);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnend);
            this.Controls.Add(this.btnstart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettlementFileDownloadProcess";
            this.Text = "MPU File Download Process";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttracelog;
    }
}