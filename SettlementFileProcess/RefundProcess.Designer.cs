namespace SettlementFileProcess
{
    partial class RefundProcess
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.dgvRefundLog = new System.Windows.Forms.DataGridView();
            this.Approve = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CBSTranShow = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settlementAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceFeeReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceFeePayable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettlementCurcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SETTLEMENTDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefundLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnApprove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 62);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkCheckAll);
            this.panel3.Location = new System.Drawing.Point(12, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(94, 39);
            this.panel3.TabIndex = 5;
            this.panel3.Click += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(7, 11);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(71, 17);
            this.chkCheckAll.TabIndex = 0;
            this.chkCheckAll.Text = "Check All";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // btnApprove
            // 
            this.btnApprove.Image = global::SettlementFileProcess.Properties.Resources.Check_24x24;
            this.btnApprove.Location = new System.Drawing.Point(106, 10);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(80, 39);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Process\r\n";
            this.btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // dgvRefundLog
            // 
            this.dgvRefundLog.AllowUserToAddRows = false;
            this.dgvRefundLog.AllowUserToDeleteRows = false;
            this.dgvRefundLog.AllowUserToOrderColumns = true;
            this.dgvRefundLog.AllowUserToResizeRows = false;
            this.dgvRefundLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefundLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Approve,
            this.CBSTranShow,
            this.PAN,
            this.transAmount,
            this.settlementAmount,
            this.ServiceFeeReceive,
            this.ServiceFeePayable,
            this.MerchantType,
            this.FileType,
            this.FILENAME,
            this.SettlementCurcode,
            this.SETTLEMENTDATE});
            this.dgvRefundLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefundLog.Location = new System.Drawing.Point(0, 62);
            this.dgvRefundLog.Name = "dgvRefundLog";
            this.dgvRefundLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefundLog.Size = new System.Drawing.Size(936, 199);
            this.dgvRefundLog.TabIndex = 3;
            // 
            // Approve
            // 
            this.Approve.FalseValue = "0";
            this.Approve.HeaderText = "";
            this.Approve.Name = "Approve";
            this.Approve.TrueValue = "1";
            this.Approve.Width = 30;
            // 
            // CBSTranShow
            // 
            this.CBSTranShow.HeaderText = "";
            this.CBSTranShow.Name = "CBSTranShow";
            this.CBSTranShow.Text = "Help?..";
            this.CBSTranShow.UseColumnTextForLinkValue = true;
            this.CBSTranShow.Width = 50;
            // 
            // PAN
            // 
            this.PAN.DataPropertyName = "Pan";
            this.PAN.HeaderText = "Card No";
            this.PAN.Name = "PAN";
            // 
            // transAmount
            // 
            this.transAmount.DataPropertyName = "transAmount";
            this.transAmount.HeaderText = "Transaction Amount";
            this.transAmount.Name = "transAmount";
            // 
            // settlementAmount
            // 
            this.settlementAmount.DataPropertyName = "settlementAmount";
            this.settlementAmount.HeaderText = "Settlement Amount";
            this.settlementAmount.Name = "settlementAmount";
            // 
            // ServiceFeeReceive
            // 
            this.ServiceFeeReceive.DataPropertyName = "ServiceFeeReceive";
            this.ServiceFeeReceive.HeaderText = "Service Fee Receivable";
            this.ServiceFeeReceive.Name = "ServiceFeeReceive";
            // 
            // ServiceFeePayable
            // 
            this.ServiceFeePayable.DataPropertyName = "ServiceFeePayable";
            this.ServiceFeePayable.HeaderText = "Service Fee Payable";
            this.ServiceFeePayable.Name = "ServiceFeePayable";
            // 
            // MerchantType
            // 
            this.MerchantType.DataPropertyName = "MerchantType";
            this.MerchantType.HeaderText = "Merchant Type";
            this.MerchantType.Name = "MerchantType";
            // 
            // FileType
            // 
            this.FileType.DataPropertyName = "FileType";
            this.FileType.HeaderText = "File Type";
            this.FileType.Name = "FileType";
            // 
            // FILENAME
            // 
            this.FILENAME.DataPropertyName = "FILENAME";
            this.FILENAME.HeaderText = "STFFileName";
            this.FILENAME.Name = "FILENAME";
            // 
            // SettlementCurcode
            // 
            this.SettlementCurcode.DataPropertyName = "SettlementCurcode";
            this.SettlementCurcode.HeaderText = "Settlement Currency";
            this.SettlementCurcode.Name = "SettlementCurcode";
            // 
            // SETTLEMENTDATE
            // 
            this.SETTLEMENTDATE.DataPropertyName = "SETTLEMENTDATE";
            this.SETTLEMENTDATE.HeaderText = "Settlement Date";
            this.SETTLEMENTDATE.Name = "SETTLEMENTDATE";
            // 
            // RefundProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 261);
            this.Controls.Add(this.dgvRefundLog);
            this.Controls.Add(this.panel1);
            this.Name = "RefundProcess";
            this.Text = "RefundProcess";
            this.Load += new System.EventHandler(this.RefundProcess_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefundLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.DataGridView dgvRefundLog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Approve;
        private System.Windows.Forms.DataGridViewLinkColumn CBSTranShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn transAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn settlementAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceFeeReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceFeePayable;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettlementCurcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SETTLEMENTDATE;
    }
}