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
            this.TextureLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IconSpriteBox = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SlotSizeW = new System.Windows.Forms.TextBox();
            this.SlotSizeH = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IconSizeH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IconSizeW = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CFGNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InventoryIconLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FrameBox = new System.Windows.Forms.NumericUpDown();
            this.MaxStacksBox = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SpriteBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconSpriteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxStacksBox)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.SpriteFactory.Location = new System.Drawing.Point(119, 358);
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
            this.SpriteBox.Location = new System.Drawing.Point(141, 358);
            this.SpriteBox.Name = "SpriteBox";
            this.SpriteBox.Size = new System.Drawing.Size(178, 189);
            this.SpriteBox.TabIndex = 1;
            this.SpriteBox.TabStop = false;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(325, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 213);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.MaxStacksBox);
            this.groupBox1.Controls.Add(this.InventoryIconLabel);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.CFGNameBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.SlotSizeW);
            this.groupBox1.Controls.Add(this.SlotSizeH);
            this.groupBox1.Controls.Add(this.NameBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IconSizeW);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FrameBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.IconSizeH);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // IconSpriteBox
            // 
            this.IconSpriteBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconSpriteBox.Location = new System.Drawing.Point(0, 0);
            this.IconSpriteBox.Name = "IconSpriteBox";
            this.IconSpriteBox.Size = new System.Drawing.Size(72, 72);
            this.IconSpriteBox.TabIndex = 19;
            this.IconSpriteBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Icon PNG";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(68, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Select...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "in pixels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Slot Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Icon Size";
            // 
            // SlotSizeW
            // 
            this.SlotSizeW.Location = new System.Drawing.Point(68, 151);
            this.SlotSizeW.Name = "SlotSizeW";
            this.SlotSizeW.Size = new System.Drawing.Size(40, 20);
            this.SlotSizeW.TabIndex = 4;
            // 
            // SlotSizeH
            // 
            this.SlotSizeH.Location = new System.Drawing.Point(128, 151);
            this.SlotSizeH.Name = "SlotSizeH";
            this.SlotSizeH.Size = new System.Drawing.Size(40, 20);
            this.SlotSizeH.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(114, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "X";
            // 
            // IconSizeH
            // 
            this.IconSizeH.Location = new System.Drawing.Point(128, 125);
            this.IconSizeH.Name = "IconSizeH";
            this.IconSizeH.Size = new System.Drawing.Size(40, 20);
            this.IconSizeH.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "in inventories";
            // 
            // IconSizeW
            // 
            this.IconSizeW.Location = new System.Drawing.Point(68, 125);
            this.IconSizeW.Name = "IconSizeW";
            this.IconSizeW.Size = new System.Drawing.Size(40, 20);
            this.IconSizeW.TabIndex = 11;
            this.IconSizeW.TextChanged += new System.EventHandler(this.IconSizeW_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Stacks";
            // 
            // CFGNameBox
            // 
            this.CFGNameBox.Location = new System.Drawing.Point(68, 44);
            this.CFGNameBox.Name = "CFGNameBox";
            this.CFGNameBox.Size = new System.Drawing.Size(95, 20);
            this.CFGNameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CFG Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(68, 17);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(95, 20);
            this.NameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // InventoryIconLabel
            // 
            this.InventoryIconLabel.AutoSize = true;
            this.InventoryIconLabel.Location = new System.Drawing.Point(147, 101);
            this.InventoryIconLabel.MinimumSize = new System.Drawing.Size(96, 0);
            this.InventoryIconLabel.Name = "InventoryIconLabel";
            this.InventoryIconLabel.Size = new System.Drawing.Size(96, 13);
            this.InventoryIconLabel.TabIndex = 20;
            this.InventoryIconLabel.Text = "default.png";
            this.InventoryIconLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Frame";
            // 
            // FrameBox
            // 
            this.FrameBox.Location = new System.Drawing.Point(68, 99);
            this.FrameBox.Name = "FrameBox";
            this.FrameBox.Size = new System.Drawing.Size(68, 20);
            this.FrameBox.TabIndex = 22;
            // 
            // MaxStacksBox
            // 
            this.MaxStacksBox.Location = new System.Drawing.Point(68, 180);
            this.MaxStacksBox.Name = "MaxStacksBox";
            this.MaxStacksBox.Size = new System.Drawing.Size(68, 20);
            this.MaxStacksBox.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.IconSpriteBox);
            this.panel2.Location = new System.Drawing.Point(169, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(76, 76);
            this.panel2.TabIndex = 21;
            // 
            // CFGTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SpriteFactory);
            this.Controls.Add(this.SpriteBox);
            this.Name = "CFGTabControl";
            this.Size = new System.Drawing.Size(679, 674);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SpriteBox.ResumeLayout(false);
            this.SpriteBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconSpriteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxStacksBox)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CFGNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SlotSizeH;
        private System.Windows.Forms.TextBox SlotSizeW;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox IconSpriteBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox IconSizeH;
        private System.Windows.Forms.TextBox IconSizeW;
        private System.Windows.Forms.Label InventoryIconLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown FrameBox;
        private System.Windows.Forms.NumericUpDown MaxStacksBox;
        private System.Windows.Forms.Panel panel2;
    }
}
