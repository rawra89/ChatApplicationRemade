namespace ChatApplicationRemade
{
	partial class MainMenu
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button_Create = new Button();
			button_Join = new Button();
			textBox_Greeting = new Label();
			SuspendLayout();
			// 
			// button_Create
			// 
			button_Create.Location = new Point(133, 104);
			button_Create.Name = "button_Create";
			button_Create.Size = new Size(75, 23);
			button_Create.TabIndex = 0;
			button_Create.Text = "Create";
			button_Create.UseVisualStyleBackColor = true;
			button_Create.Click += button_Create_Click;
			// 
			// button_Join
			// 
			button_Join.Location = new Point(214, 104);
			button_Join.Name = "button_Join";
			button_Join.Size = new Size(75, 23);
			button_Join.TabIndex = 1;
			button_Join.Text = "Join";
			button_Join.UseVisualStyleBackColor = true;
			button_Join.Click += button_Join_Click;
			// 
			// textBox_Greeting
			// 
			textBox_Greeting.AutoSize = true;
			textBox_Greeting.Location = new Point(170, 72);
			textBox_Greeting.Name = "textBox_Greeting";
			textBox_Greeting.Size = new Size(0, 15);
			textBox_Greeting.TabIndex = 2;
			// 
			// MainMenu
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(423, 230);
			Controls.Add(textBox_Greeting);
			Controls.Add(button_Join);
			Controls.Add(button_Create);
			Name = "MainMenu";
			Text = "Form1";
			Load += MainMenu_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button_Create;
		private Button button_Join;
		private Label textBox_Greeting;
	}
}