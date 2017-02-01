namespace VirtualAssistant
{
    partial class WikiSearchForm
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
            this.WikiTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // WikiTextBox
            // 
            this.WikiTextBox.Location = new System.Drawing.Point(12, 12);
            this.WikiTextBox.Name = "WikiTextBox";
            this.WikiTextBox.Size = new System.Drawing.Size(681, 465);
            this.WikiTextBox.TabIndex = 0;
            this.WikiTextBox.Text = "";
            // 
            // WikiSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 489);
            this.Controls.Add(this.WikiTextBox);
            this.Name = "WikiSearchForm";
            this.Text = "WikiSearchForm";
            this.Load += new System.EventHandler(this.WikiSearchForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox WikiTextBox;

    }
}