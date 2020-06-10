namespace SettlementFileProcess
{
    partial class DataReconcile
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMPUSTFData = new System.Windows.Forms.DataGridView();
            this.MPUIncData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPUIncFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPUOGAmoung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPUOGFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCBSSFTData = new System.Windows.Forms.DataGridView();
            this.CBSIncAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBSIncFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBSOGAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBSOGFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnhide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMPUSTFData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCBSSFTData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMPUSTFData);
            this.groupBox1.Location = new System.Drawing.Point(32, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MPU Settlement Data";
            // 
            // dgvMPUSTFData
            // 
            this.dgvMPUSTFData.AllowUserToAddRows = false;
            this.dgvMPUSTFData.AllowUserToDeleteRows = false;
            this.dgvMPUSTFData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMPUSTFData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MPUIncData,
            this.MPUIncFee,
            this.MPUOGAmoung,
            this.MPUOGFee});
            this.dgvMPUSTFData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMPUSTFData.Location = new System.Drawing.Point(3, 16);
            this.dgvMPUSTFData.Name = "dgvMPUSTFData";
            this.dgvMPUSTFData.Size = new System.Drawing.Size(878, 55);
            this.dgvMPUSTFData.TabIndex = 0;
            // 
            // MPUIncData
            // 
            this.MPUIncData.HeaderText = "Incoming Data";
            this.MPUIncData.Name = "MPUIncData";
            this.MPUIncData.Width = 200;
            // 
            // MPUIncFee
            // 
            this.MPUIncFee.HeaderText = "Incoming Fee";
            this.MPUIncFee.Name = "MPUIncFee";
            this.MPUIncFee.Width = 200;
            // 
            // MPUOGAmoung
            // 
            this.MPUOGAmoung.HeaderText = "Outgoing Amount";
            this.MPUOGAmoung.Name = "MPUOGAmoung";
            this.MPUOGAmoung.Width = 200;
            // 
            // MPUOGFee
            // 
            this.MPUOGFee.HeaderText = "Outgoing Fee";
            this.MPUOGFee.Name = "MPUOGFee";
            this.MPUOGFee.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCBSSFTData);
            this.groupBox2.Location = new System.Drawing.Point(35, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(884, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CBS Settlement Data";
            // 
            // dgvCBSSFTData
            // 
            this.dgvCBSSFTData.AllowUserToAddRows = false;
            this.dgvCBSSFTData.AllowUserToDeleteRows = false;
            this.dgvCBSSFTData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCBSSFTData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CBSIncAmount,
            this.CBSIncFee,
            this.CBSOGAmount,
            this.CBSOGFee});
            this.dgvCBSSFTData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCBSSFTData.Location = new System.Drawing.Point(3, 16);
            this.dgvCBSSFTData.Name = "dgvCBSSFTData";
            this.dgvCBSSFTData.Size = new System.Drawing.Size(878, 55);
            this.dgvCBSSFTData.TabIndex = 0;
            // 
            // CBSIncAmount
            // 
            this.CBSIncAmount.HeaderText = "Incoming Data";
            this.CBSIncAmount.Name = "CBSIncAmount";
            this.CBSIncAmount.Width = 200;
            // 
            // CBSIncFee
            // 
            this.CBSIncFee.HeaderText = "Incoming Fee";
            this.CBSIncFee.Name = "CBSIncFee";
            this.CBSIncFee.Width = 200;
            // 
            // CBSOGAmount
            // 
            this.CBSOGAmount.HeaderText = "Outgoing Amount";
            this.CBSOGAmount.Name = "CBSOGAmount";
            this.CBSOGAmount.Width = 200;
            // 
            // CBSOGFee
            // 
            this.CBSOGFee.HeaderText = "Outgoing Fee";
            this.CBSOGFee.Name = "CBSOGFee";
            this.CBSOGFee.Width = 200;
            // 
            // btnhide
            // 
            this.btnhide.Location = new System.Drawing.Point(812, 199);
            this.btnhide.Name = "btnhide";
            this.btnhide.Size = new System.Drawing.Size(101, 27);
            this.btnhide.TabIndex = 2;
            this.btnhide.Text = "&Hide";
            this.btnhide.UseVisualStyleBackColor = true;
            this.btnhide.Click += new System.EventHandler(this.btnhide_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(653, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataReconcile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 238);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnhide);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataReconcile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataReconcile";
            this.Load += new System.EventHandler(this.DataReconcile_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMPUSTFData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCBSSFTData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMPUSTFData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCBSSFTData;
        private System.Windows.Forms.Button btnhide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPUIncData;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPUIncFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPUOGAmoung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPUOGFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBSIncAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBSIncFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBSOGAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBSOGFee;

    }
}