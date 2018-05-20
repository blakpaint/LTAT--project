namespace User
{
    partial class frmUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.lbIP = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.btnConn = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNoise = new System.Windows.Forms.Button();
            this.btnKey = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.MessList = new System.Windows.Forms.ListBox();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.BackColor = System.Drawing.Color.Transparent;
            this.lbIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbIP.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIP.Location = new System.Drawing.Point(653, 48);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(2, 26);
            this.lbIP.TabIndex = 58;
            this.lbIP.Visible = false;
            // 
            // tbKey
            // 
            this.tbKey.Enabled = false;
            this.tbKey.Location = new System.Drawing.Point(155, 395);
            this.tbKey.Multiline = true;
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(427, 37);
            this.tbKey.TabIndex = 56;
            this.tbKey.Visible = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.Crimson;
            this.lbName.Location = new System.Drawing.Point(332, 40);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 40);
            this.lbName.TabIndex = 55;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.Visible = false;
            // 
            // btnConn
            // 
            this.btnConn.BackColor = System.Drawing.Color.Transparent;
            this.btnConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConn.ForeColor = System.Drawing.Color.Blue;
            this.btnConn.Location = new System.Drawing.Point(519, 44);
            this.btnConn.Margin = new System.Windows.Forms.Padding(4);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(102, 37);
            this.btnConn.TabIndex = 2;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = false;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(281, 48);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 31);
            this.tbName.TabIndex = 1;
            this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 34);
            this.label1.TabIndex = 52;
            this.label1.Text = "Connect As :";
            // 
            // btnNoise
            // 
            this.btnNoise.BackColor = System.Drawing.Color.Transparent;
            this.btnNoise.Enabled = false;
            this.btnNoise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoise.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoise.ForeColor = System.Drawing.Color.Indigo;
            this.btnNoise.Location = new System.Drawing.Point(603, 395);
            this.btnNoise.Margin = new System.Windows.Forms.Padding(4);
            this.btnNoise.Name = "btnNoise";
            this.btnNoise.Size = new System.Drawing.Size(119, 37);
            this.btnNoise.TabIndex = 6;
            this.btnNoise.Text = "Noise";
            this.btnNoise.UseVisualStyleBackColor = false;
            this.btnNoise.Click += new System.EventHandler(this.btnNoise_Click);
            // 
            // btnKey
            // 
            this.btnKey.BackColor = System.Drawing.Color.Transparent;
            this.btnKey.Enabled = false;
            this.btnKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey.ForeColor = System.Drawing.Color.Blue;
            this.btnKey.Location = new System.Drawing.Point(44, 394);
            this.btnKey.Margin = new System.Windows.Forms.Padding(4);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(104, 37);
            this.btnKey.TabIndex = 5;
            this.btnKey.Text = "Key";
            this.btnKey.UseVisualStyleBackColor = false;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.Teal;
            this.btnSend.Location = new System.Drawing.Point(601, 453);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(121, 38);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Enabled = false;
            this.txtInput.ForeColor = System.Drawing.Color.Gray;
            this.txtInput.Location = new System.Drawing.Point(44, 439);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(538, 53);
            this.txtInput.TabIndex = 3;
            this.txtInput.Text = "Say something...";
            this.txtInput.Click += new System.EventHandler(this.txtInput_Click);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // MessList
            // 
            this.MessList.Enabled = false;
            this.MessList.FormattingEnabled = true;
            this.MessList.ItemHeight = 16;
            this.MessList.Location = new System.Drawing.Point(44, 119);
            this.MessList.Name = "MessList";
            this.MessList.Size = new System.Drawing.Size(678, 260);
            this.MessList.TabIndex = 60;
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 60000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(805, 522);
            this.Controls.Add(this.MessList);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNoise);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUser";
            this.Text = "Secret Message";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUser_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoise;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ListBox MessList;
        private System.Windows.Forms.Timer MainTimer;
    }
}

