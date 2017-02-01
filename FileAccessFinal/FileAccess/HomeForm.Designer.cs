namespace VirtualAssistant
{
    partial class HomeForm
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
            this.TextInterfaceBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextInterfaceBox
            // 
            this.TextInterfaceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextInterfaceBox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.TextInterfaceBox.Location = new System.Drawing.Point(16, 15);
            this.TextInterfaceBox.Margin = new System.Windows.Forms.Padding(4);
            this.TextInterfaceBox.Multiline = true;
            this.TextInterfaceBox.Name = "TextInterfaceBox";
            this.TextInterfaceBox.Size = new System.Drawing.Size(415, 504);
            this.TextInterfaceBox.TabIndex = 0;
            // 
            // HomeForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(448, 534);
            this.Controls.Add(this.TextInterfaceBox);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HomeForm";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextInterfaceBox;
    }
}

