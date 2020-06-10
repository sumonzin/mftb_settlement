namespace SettlementFileProcess
{
    partial class CutOffStartDateandEndDateEntry
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTrandate = new System.Windows.Forms.Label();
            this.dtptranDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SettlementFileProcess.Properties.Resources.Save_24x24;
            this.btnSave.Location = new System.Drawing.Point(163, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::SettlementFileProcess.Properties.Resources.Log_Out_24x24;
            this.btnExit.Location = new System.Drawing.Point(244, 49);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 42);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "E&xit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTrandate
            // 
            this.lblTrandate.AutoSize = true;
            this.lblTrandate.Location = new System.Drawing.Point(12, 14);
            this.lblTrandate.Name = "lblTrandate";
            this.lblTrandate.Size = new System.Drawing.Size(86, 13);
            this.lblTrandate.TabIndex = 6;
            this.lblTrandate.Text = "TransactionDate";
            // 
            // dtptranDate
            // 
            this.dtptranDate.CustomFormat = "dd-MM-yyyy ";
            this.dtptranDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptranDate.Location = new System.Drawing.Point(119, 12);
            this.dtptranDate.Name = "dtptranDate";
            this.dtptranDate.Size = new System.Drawing.Size(200, 20);
            this.dtptranDate.TabIndex = 7;
            // 
            // CutOffStartDateandEndDateEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 202);
            this.Controls.Add(this.dtptranDate);
            this.Controls.Add(this.lblTrandate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(364, 241);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(364, 241);
            this.Name = "CutOffStartDateandEndDateEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CutOff StartDate and EndDate Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTrandate;
        private System.Windows.Forms.DateTimePicker dtptranDate;
    }
}