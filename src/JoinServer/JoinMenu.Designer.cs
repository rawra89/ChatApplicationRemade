namespace ChatApplicationRemade.src
{
	partial class JoinMenu
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
            this.textBox_IPAddress = new System.Windows.Forms.TextBox();
            this.button_Join = new System.Windows.Forms.Button();
            this.label_IP = new System.Windows.Forms.Label();
            this.BGW_ChatroomJoiner = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBox_IPAddress
            // 
            this.textBox_IPAddress.Location = new System.Drawing.Point(59, 93);
            this.textBox_IPAddress.Name = "textBox_IPAddress";
            this.textBox_IPAddress.Size = new System.Drawing.Size(180, 23);
            this.textBox_IPAddress.TabIndex = 0;
            // 
            // button_Join
            // 
            this.button_Join.Location = new System.Drawing.Point(111, 122);
            this.button_Join.Name = "button_Join";
            this.button_Join.Size = new System.Drawing.Size(75, 23);
            this.button_Join.TabIndex = 1;
            this.button_Join.Text = "Join";
            this.button_Join.UseVisualStyleBackColor = true;
            this.button_Join.Click += new System.EventHandler(this.button_Join_Click_1);
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(139, 75);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(20, 15);
            this.label_IP.TabIndex = 2;
            this.label_IP.Text = "IP:";
            // 
            // BGW_ChatroomJoiner
            // 
            this.BGW_ChatroomJoiner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_ChatroomJoiner_DoWork);
            // 
            // JoinMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 211);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.button_Join);
            this.Controls.Add(this.textBox_IPAddress);
            this.Name = "JoinMenu";
            this.Text = "Join";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private TextBox textBox_IPAddress;
		private Button button_Join;
		private Label label_IP;
        private System.ComponentModel.BackgroundWorker BGW_ChatroomJoiner;
    }
}