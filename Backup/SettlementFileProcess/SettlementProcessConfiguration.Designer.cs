namespace SettlementFileProcess
{
    partial class SettlementProcessConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettlementProcessConfiguration));
            this.gpbSettlement = new System.Windows.Forms.GroupBox();
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.dtpSchedule = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpbSettlement.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbSettlement
            // 
            this.gpbSettlement.Controls.Add(this.chkManual);
            this.gpbSettlement.Controls.Add(this.dtpSchedule);
            this.gpbSettlement.Controls.Add(this.label1);
            this.gpbSettlement.ForeColor = System.Drawing.Color.Navy;
            this.gpbSettlement.Location = new System.Drawing.Point(12, 12);
            this.gpbSettlement.Name = "gpbSettlement";
            this.gpbSettlement.Size = new System.Drawing.Size(277, 117);
            this.gpbSettlement.TabIndex = 0;
            this.gpbSettlement.TabStop = false;
            this.gpbSettlement.Text = "Settlement Process Configuration";
            // 
            // chkManual
            // 
            this.chkManual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkManual.Location = new System.Drawing.Point(44, 80);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(112, 24);
            this.chkManual.TabIndex = 6;
            this.chkManual.Text = "Need Approve";
            this.chkManual.UseVisualStyleBackColor = true;
            // 
            // dtpSchedule
            // 
            this.dtpSchedule.Checked = false;
            this.dtpSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSchedule.Location = new System.Drawing.Point(142, 45);
            this.dtpSchedule.Name = "dtpSchedule";
            this.dtpSchedule.ShowCheckBox = true;
            this.dtpSchedule.ShowUpDown = true;
            this.dtpSchedule.Size = new System.Drawing.Size(102, 20);
            this.dtpSchedule.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time to Download";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(295, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 141);
            this.panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::SettlementFileProcess.Properties.Resources.Log_Out_24x24;
            this.btnExit.Location = new System.Drawing.Point(18, 57);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "E&xit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SettlementFileProcess.Properties.Resources.Save_24x24;
            this.btnSave.Location = new System.Drawing.Point(18, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettlementProcessConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 141);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpbSettlement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettlementProcessConfiguration";
            this.Text = "File Download Configuration";
            this.gpbSettlement.ResumeLayout(false);
            this.gpbSettlement.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSettlement;
        private System.Windows.Forms.DateTimePicker dtpSchedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
    }
}

