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
			textBox_IPAddress = new TextBox();
			button_Join = new Button();
			label_IP = new Label();
			SuspendLayout();
			// 
			// textBox_IPAddress
			// 
			textBox_IPAddress.Location = new Point(59, 93);
			textBox_IPAddress.Name = "textBox_IPAddress";
			textBox_IPAddress.Size = new Size(180, 23);
			textBox_IPAddress.TabIndex = 0;
			// 
			// button_Join
			// 
			button_Join.Location = new Point(111, 122);
			button_Join.Name = "button_Join";
			button_Join.Size = new Size(75, 23);
			button_Join.TabIndex = 1;
			button_Join.Text = "Join";
			button_Join.UseVisualStyleBackColor = true;
			button_Join.Click += button_Join_Click;
			// 
			// label_IP
			// 
			label_IP.AutoSize = true;
			label_IP.Location = new Point(139, 75);
			label_IP.Name = "label_IP";
			label_IP.Size = new Size(20, 15);
			label_IP.TabIndex = 2;
			label_IP.Text = "IP:";
			// 
			// JoinMenu
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(298, 211);
			Controls.Add(label_IP);
			Controls.Add(button_Join);
			Controls.Add(textBox_IPAddress);
			Name = "JoinMenu";
			Text = "Join";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox_IPAddress;
		private Button button_Join;
		private Label label_IP;
	}
}