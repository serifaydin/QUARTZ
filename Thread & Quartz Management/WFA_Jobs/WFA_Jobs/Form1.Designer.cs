namespace WFA_Jobs
{
    partial class Form1
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
            this.chcThreandJobs = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblThreadState = new System.Windows.Forms.Label();
            this.lblThreadPriority = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblThreadManageId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStateColor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chcThreandJobs
            // 
            this.chcThreandJobs.CheckOnClick = true;
            this.chcThreandJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcThreandJobs.FormattingEnabled = true;
            this.chcThreandJobs.Location = new System.Drawing.Point(12, 13);
            this.chcThreandJobs.Name = "chcThreandJobs";
            this.chcThreandJobs.Size = new System.Drawing.Size(296, 616);
            this.chcThreandJobs.TabIndex = 0;
            this.chcThreandJobs.SelectedIndexChanged += new System.EventHandler(this.chcThreandJobs_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LawnGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.Location = new System.Drawing.Point(414, 235);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(291, 100);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStop.Location = new System.Drawing.Point(414, 113);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(291, 88);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStateColor);
            this.groupBox1.Controls.Add(this.lblThreadManageId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblThreadPriority);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblThreadState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(314, 436);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 193);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thread Job Detail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thread State :";
            // 
            // lblThreadState
            // 
            this.lblThreadState.AutoSize = true;
            this.lblThreadState.Location = new System.Drawing.Point(178, 48);
            this.lblThreadState.Name = "lblThreadState";
            this.lblThreadState.Size = new System.Drawing.Size(113, 17);
            this.lblThreadState.TabIndex = 4;
            this.lblThreadState.Text = "Thread State :";
            // 
            // lblThreadPriority
            // 
            this.lblThreadPriority.AutoSize = true;
            this.lblThreadPriority.Location = new System.Drawing.Point(178, 94);
            this.lblThreadPriority.Name = "lblThreadPriority";
            this.lblThreadPriority.Size = new System.Drawing.Size(113, 17);
            this.lblThreadPriority.TabIndex = 6;
            this.lblThreadPriority.Text = "Thread State :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thread Priority :";
            // 
            // lblThreadManageId
            // 
            this.lblThreadManageId.AutoSize = true;
            this.lblThreadManageId.Location = new System.Drawing.Point(178, 143);
            this.lblThreadManageId.Name = "lblThreadManageId";
            this.lblThreadManageId.Size = new System.Drawing.Size(113, 17);
            this.lblThreadManageId.TabIndex = 8;
            this.lblThreadManageId.Text = "Thread State :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Thread Manage ID :";
            // 
            // btnStateColor
            // 
            this.btnStateColor.Enabled = false;
            this.btnStateColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStateColor.Location = new System.Drawing.Point(325, 71);
            this.btnStateColor.Name = "btnStateColor";
            this.btnStateColor.Size = new System.Drawing.Size(105, 63);
            this.btnStateColor.TabIndex = 3;
            this.btnStateColor.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 659);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chcThreandJobs);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chcThreandJobs;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThreadState;
        private System.Windows.Forms.Label lblThreadManageId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblThreadPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStateColor;
    }
}

