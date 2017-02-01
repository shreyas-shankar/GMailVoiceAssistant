namespace VirtualAssistant
{
    partial class ComposeMailForm
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
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.toBox = new System.Windows.Forms.TextBox();
            this.fromBox = new System.Windows.Forms.TextBox();
            this.subjectBox = new System.Windows.Forms.TextBox();
            this.bodyBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(28, 9);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(26, 13);
            this.toLabel.TabIndex = 0;
            this.toLabel.Text = "To :";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(18, 43);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(36, 13);
            this.fromLabel.TabIndex = 1;
            this.fromLabel.Text = "From :";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(8, 73);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(49, 13);
            this.subjectLabel.TabIndex = 2;
            this.subjectLabel.Text = "Subject :";
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Location = new System.Drawing.Point(17, 113);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(37, 13);
            this.bodyLabel.TabIndex = 3;
            this.bodyLabel.Text = "Body :";
            // 
            // toBox
            // 
            this.toBox.Location = new System.Drawing.Point(60, 9);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(413, 20);
            this.toBox.TabIndex = 4;
            // 
            // fromBox
            // 
            this.fromBox.Location = new System.Drawing.Point(60, 40);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(413, 20);
            this.fromBox.TabIndex = 5;
            // 
            // subjectBox
            // 
            this.subjectBox.Location = new System.Drawing.Point(60, 73);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(413, 20);
            this.subjectBox.TabIndex = 6;
            // 
            // bodyBox
            // 
            this.bodyBox.Location = new System.Drawing.Point(60, 113);
            this.bodyBox.Multiline = true;
            this.bodyBox.Name = "bodyBox";
            this.bodyBox.Size = new System.Drawing.Size(413, 324);
            this.bodyBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ComposeMailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 487);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bodyBox);
            this.Controls.Add(this.subjectBox);
            this.Controls.Add(this.fromBox);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.toLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ComposeMailForm";
            this.Load += new System.EventHandler(this.ComposeMailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.TextBox toBox;
        private System.Windows.Forms.TextBox fromBox;
        private System.Windows.Forms.TextBox subjectBox;
        private System.Windows.Forms.TextBox bodyBox;
        private System.Windows.Forms.Button button1;
    }
}