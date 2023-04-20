namespace KAGIDE
{
    partial class ConfigForm
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
            this.cfgNameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.spriteFactory = new System.Windows.Forms.CheckBox();
            this.spriteFactoryPanel = new System.Windows.Forms.Panel();
            this.spritePath = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.spriteBox = new System.Windows.Forms.PictureBox();
            this.frameWidth = new System.Windows.Forms.TextBox();
            this.frameHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spriteFactoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cfgNameField
            // 
            this.cfgNameField.Location = new System.Drawing.Point(13, 13);
            this.cfgNameField.Name = "cfgNameField";
            this.cfgNameField.Size = new System.Drawing.Size(100, 20);
            this.cfgNameField.TabIndex = 0;
            this.cfgNameField.Text = "default";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ".cfg";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(13, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(713, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // spriteFactory
            // 
            this.spriteFactory.AutoSize = true;
            this.spriteFactory.Location = new System.Drawing.Point(13, 110);
            this.spriteFactory.Name = "spriteFactory";
            this.spriteFactory.Size = new System.Drawing.Size(53, 17);
            this.spriteFactory.TabIndex = 4;
            this.spriteFactory.Text = "Sprite";
            this.spriteFactory.UseVisualStyleBackColor = true;
            this.spriteFactory.CheckedChanged += new System.EventHandler(this.spriteFactory_CheckedChanged);
            // 
            // spriteFactoryPanel
            // 
            this.spriteFactoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spriteFactoryPanel.Controls.Add(this.label3);
            this.spriteFactoryPanel.Controls.Add(this.label2);
            this.spriteFactoryPanel.Controls.Add(this.frameHeight);
            this.spriteFactoryPanel.Controls.Add(this.frameWidth);
            this.spriteFactoryPanel.Controls.Add(this.spritePath);
            this.spriteFactoryPanel.Controls.Add(this.button3);
            this.spriteFactoryPanel.Enabled = false;
            this.spriteFactoryPanel.Location = new System.Drawing.Point(13, 134);
            this.spriteFactoryPanel.Name = "spriteFactoryPanel";
            this.spriteFactoryPanel.Size = new System.Drawing.Size(281, 137);
            this.spriteFactoryPanel.TabIndex = 5;
            // 
            // spritePath
            // 
            this.spritePath.AutoSize = true;
            this.spritePath.Location = new System.Drawing.Point(85, 9);
            this.spritePath.Name = "spritePath";
            this.spritePath.Size = new System.Drawing.Size(60, 13);
            this.spritePath.TabIndex = 1;
            this.spritePath.Text = "default.png";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Select...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // spriteBox
            // 
            this.spriteBox.Location = new System.Drawing.Point(614, 13);
            this.spriteBox.Name = "spriteBox";
            this.spriteBox.Size = new System.Drawing.Size(174, 165);
            this.spriteBox.TabIndex = 6;
            this.spriteBox.TabStop = false;
            // 
            // frameWidth
            // 
            this.frameWidth.Location = new System.Drawing.Point(4, 33);
            this.frameWidth.Name = "frameWidth";
            this.frameWidth.Size = new System.Drawing.Size(32, 20);
            this.frameWidth.TabIndex = 2;
            this.frameWidth.Text = "16";
            // 
            // frameHeight
            // 
            this.frameHeight.Location = new System.Drawing.Point(62, 33);
            this.frameHeight.Name = "frameHeight";
            this.frameHeight.Size = new System.Drawing.Size(32, 20);
            this.frameHeight.TabIndex = 3;
            this.frameHeight.Text = "16";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Frame Size";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.spriteBox);
            this.Controls.Add(this.spriteFactoryPanel);
            this.Controls.Add(this.spriteFactory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cfgNameField);
            this.Name = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.spriteFactoryPanel.ResumeLayout(false);
            this.spriteFactoryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cfgNameField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox spriteFactory;
        private System.Windows.Forms.Panel spriteFactoryPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label spritePath;
        private System.Windows.Forms.PictureBox spriteBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox frameHeight;
        private System.Windows.Forms.TextBox frameWidth;
    }
}