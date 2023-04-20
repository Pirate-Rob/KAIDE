namespace KAGIDE
{
    partial class SettingsForm
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
            this.textBoxDefaultFile = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelSelectedFile = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDefaultFile
            // 
            this.textBoxDefaultFile.AutoSize = true;
            this.textBoxDefaultFile.Location = new System.Drawing.Point(131, 56);
            this.textBoxDefaultFile.Name = "textBoxDefaultFile";
            this.textBoxDefaultFile.Size = new System.Drawing.Size(72, 13);
            this.textBoxDefaultFile.TabIndex = 0;
            this.textBoxDefaultFile.Text = "KAG directory";
            this.textBoxDefaultFile.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelSelectedFile
            // 
            this.labelSelectedFile.AutoSize = true;
            this.labelSelectedFile.Location = new System.Drawing.Point(193, 102);
            this.labelSelectedFile.Name = "labelSelectedFile";
            this.labelSelectedFile.Size = new System.Drawing.Size(35, 13);
            this.labelSelectedFile.TabIndex = 3;
            this.labelSelectedFile.Text = "label2";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(252, 45);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click_1);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelSelectedFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDefaultFile);
            this.Name = "SettingsForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textBoxDefaultFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelSelectedFile;
        private System.Windows.Forms.Button buttonBrowse;
    }
}