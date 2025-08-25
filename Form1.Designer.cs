namespace projectVp
{
    partial class Form1
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom;
            textBox1.Location = new Point(350, 282);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom;
            textBox2.Location = new Point(349, 315);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            textBox2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = SystemColors.Highlight;
            button1.Location = new Point(353, 357);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(251, 285);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 3;
            label1.Text = "USERNAME :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(249, 315);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 4;
            label2.Text = "PASSWORD :";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_jqigo2jqigo2jqig;
            pictureBox1.Location = new Point(308, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 198);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
