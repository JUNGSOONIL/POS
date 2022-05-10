namespace WindowsFormsApp1
{
    partial class Login
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.button_log = new System.Windows.Forms.Button();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "PW";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "ID";
            // 
            // textBox_result
            // 
            this.textBox_result.Enabled = false;
            this.textBox_result.Location = new System.Drawing.Point(59, 146);
            this.textBox_result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(213, 28);
            this.textBox_result.TabIndex = 18;
            // 
            // button_log
            // 
            this.button_log.Location = new System.Drawing.Point(246, 28);
            this.button_log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(86, 49);
            this.button_log.TabIndex = 17;
            this.button_log.Text = "로그인";
            this.button_log.UseVisualStyleBackColor = true;
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(83, 98);
            this.textBox_PW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.PasswordChar = '*';
            this.textBox_PW.Size = new System.Drawing.Size(140, 25);
            this.textBox_PW.TabIndex = 16;
            this.textBox_PW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_PW_KeyDown);
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(83, 42);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(140, 25);
            this.textBox_ID.TabIndex = 15;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(246, 89);
            this.button_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(86, 49);
            this.button_close.TabIndex = 21;
            this.button_close.Text = "닫기";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 198);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_log);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.textBox_ID);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button button_log;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Button button_close;
    }
}