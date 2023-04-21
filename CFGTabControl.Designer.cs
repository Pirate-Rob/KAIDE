namespace KAGIDE
{
    partial class CFGTabControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SpriteFactory = new System.Windows.Forms.CheckBox();
            this.SpriteBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TextureLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SpriteBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::KAGIDE.Properties.Resources.Cancel;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 209);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SpriteFactory
            // 
            this.SpriteFactory.AutoSize = true;
            this.SpriteFactory.Location = new System.Drawing.Point(3, 3);
            this.SpriteFactory.Name = "SpriteFactory";
            this.SpriteFactory.Size = new System.Drawing.Size(53, 17);
            this.SpriteFactory.TabIndex = 0;
            this.SpriteFactory.Text = "Sprite";
            this.SpriteFactory.UseVisualStyleBackColor = true;
            this.SpriteFactory.CheckedChanged += new System.EventHandler(this.SpriteFactory_CheckedChanged);
            // 
            // SpriteBox
            // 
            this.SpriteBox.Controls.Add(this.TextureLabel);
            this.SpriteBox.Controls.Add(this.button1);
            this.SpriteBox.Location = new System.Drawing.Point(25, 3);
            this.SpriteBox.Name = "SpriteBox";
            this.SpriteBox.Size = new System.Drawing.Size(178, 189);
            this.SpriteBox.TabIndex = 1;
            this.SpriteBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextureLabel
            // 
            this.TextureLabel.AutoSize = true;
            this.TextureLabel.Location = new System.Drawing.Point(87, 24);
            this.TextureLabel.Name = "TextureLabel";
            this.TextureLabel.Size = new System.Drawing.Size(60, 13);
            this.TextureLabel.TabIndex = 1;
            this.TextureLabel.Text = "default.png";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(209, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 213);
            this.panel1.TabIndex = 2;
            // 
            // CFGTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SpriteFactory);
            this.Controls.Add(this.SpriteBox);
            this.Name = "CFGTabControl";
            this.Size = new System.Drawing.Size(668, 463);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SpriteBox.ResumeLayout(false);
            this.SpriteBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox SpriteFactory;
        private System.Windows.Forms.GroupBox SpriteBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label TextureLabel;
        private System.Windows.Forms.Panel panel1;
    }
}
